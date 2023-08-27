using System;
using System.Management;
using System.Threading;
using NLog;
using ProcessWatcher.Classes.EventArguments;
using ProcessWatcher.Models;

namespace ProcessWatcher.Classes.Managers
{
    /// <summary>
    /// Отслеживает запуск, остановку процессов.
    /// </summary>
    public class ProcessWatcherManager : IDisposable
    {
        /// <summary>
        /// Прослушиватель событий запуска процессов.
        /// </summary>
        private readonly ManagementEventWatcher _processStartWatch;

        /// <summary>
        /// Прослушиватель событий остановки процессов.
        /// </summary>
        private readonly ManagementEventWatcher _processStopWatch;

        /// <summary>
        /// Логгер.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Возвращает состояние остлеживания, <see langword="true"/> если отслеживание запущено, иначе <see langword="false"/>.
        /// </summary>
        private bool _isWatching;

        /// <summary>
        /// Инициализирует новый экземляр класса <see cref="ProcessWatcherManager"/> с заданным интервалом отслеживания.
        /// </summary>
        /// <param name="intervalSeconds">Интервал отслеживания (секунды).</param>
        /// <exception cref="ArgumentOutOfRangeException">Выдаётся в случае, если заданный интервал меньше или равен нулю.</exception>
        public ProcessWatcherManager(int intervalSeconds)
        {
            if (intervalSeconds <= 0)
                throw new ArgumentOutOfRangeException(nameof(intervalSeconds));
            Interval = intervalSeconds;
            _logger = LogManager.GetCurrentClassLogger();
            _processStartWatch = new ManagementEventWatcher($"SELECT * FROM __InstanceCreationEvent WITHIN {intervalSeconds} WHERE TargetInstance ISA 'Win32_Process'");
            _processStopWatch = new ManagementEventWatcher($"SELECT * FROM __InstanceDeletionEvent WITHIN {intervalSeconds} WHERE TargetInstance ISA 'Win32_Process'");
        }

        /// <summary>
        /// Происходит, когда запускается новый процесс.
        /// </summary>
        public event EventHandler<ProcessStartedEventArgs> ProcessStarted;

        /// <summary>
        /// Происходит, когда останавливается процесс.
        /// </summary>

        public event EventHandler<ProcessStoppedEventArgs> ProcessStopped;

        /// <summary>
        /// Происходит, когда список текущих выполняемых процессов полностью загружен.
        /// </summary>
        public event EventHandler<EventArgs> ProcessesLoaded;

        /// <summary>
        /// Происходит, когда состояние отслеживания процессов изменено.
        /// </summary>
        public event EventHandler<ProcessesWatchingChangedEventArgs> ProcessesWatchingChanged;

        /// <summary>
        /// Возвращает текущий интервал отслеживания (секунды).
        /// </summary>
        public int Interval { get; }

        /// <summary>
        /// Возвращает состояние остлеживания, <see langword="true"/> если отслеживание запущено, иначе <see langword="false"/>.
        /// </summary>
        public bool IsWatching
        {
            get
            {
                return _isWatching;
            }
            set
            {
                _isWatching = value;
                ProcessesWatchingChanged?.Invoke(this, new ProcessesWatchingChangedEventArgs(value));
            }
        }

        /// <summary>
        /// Запускает отслеживание запуска и остановки процессов.
        /// </summary>
        public void Start()
        {
            try
            {
                try
                {
                    _logger.Log(LogLevel.Info, "Включение отслеживания запуска процессов");
                    _processStartWatch.EventArrived += ProcessStartWatch_EventArrived;
                    _processStartWatch.Start();
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex);
                }

                try
                {
                    _logger.Log(LogLevel.Info, "Включение отслеживания остановки процессов");
                    _processStopWatch.EventArrived += ProcessStopWatch_EventArrived;
                    _processStopWatch.Start();
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex);
                }
            }
            finally
            {
                IsWatching = true;
            }
        }

        /// <summary>
        /// Останавливает отслеживание запуска и остановки процессов.
        /// </summary>
        public void Stop()
        {
            try
            {
                try
                {
                    _logger.Log(LogLevel.Info, "Отключение отслеживания запуска процессов");
                    _processStartWatch.EventArrived -= ProcessStartWatch_EventArrived;
                    _processStartWatch.Stop();
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex);
                }

                try
                {
                    _logger.Log(LogLevel.Info, "Отключение отслеживания остановки процессов");
                    _processStopWatch.EventArrived -= ProcessStopWatch_EventArrived;
                    _processStopWatch.Stop();
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex);
                }
            }
            finally
            {
                IsWatching = false;
            }
        }

        /// <summary>
        /// Загружает список процессов в отдельном потоке.
        /// </summary>
        public void LoadProcesses()
        {
            try
            {
                var loadThread = new Thread(LoadProcessesFromWmi);
                loadThread.Start();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex);
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Stop();
            ProcessStarted = null;
            ProcessStopped = null;
            ProcessesLoaded = null;
            ProcessesWatchingChanged = null;
            _processStartWatch.Dispose();
            _processStopWatch.Dispose();
        }

        /// <summary>
        /// Загружает список процессов, уведомляет о каждом запущеном процессе и об завершении загрузки. 
        /// </summary>
        private void LoadProcessesFromWmi()
        {
            try
            {
                _logger.Log(LogLevel.Info, "Получение списка запущенных процессов");
                var managementScope = new ManagementScope(@"\root\CIMV2");
                var query = new ObjectQuery("SELECT * FROM Win32_Process");
                using (var searcher = new ManagementObjectSearcher(managementScope, query))
                using (var processes = searcher.Get())
                {
                    foreach (var process in processes)
                    {
                        try
                        {
                            if (ProcessStarted is null)
                                continue;
                            var processViewModel = new ProcessViewModel(process);
                            ProcessStarted.Invoke(this, new ProcessStartedEventArgs(processViewModel));
                        }
                        finally
                        {
                            process.Dispose();
                        }
                    }
                }
                ProcessesLoaded?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex);
            }
        }

        /// <summary>
        /// Уведомляет об остановленном процессе. Данный метод выполняется в отдельном потоке.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void ProcessStopWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject process = null;
            try
            {
                process = (ManagementBaseObject)e.NewEvent["TargetInstance"];
                if (process is null || ProcessStopped is null)
                    return;
                var processId = process["ProcessId"] as uint?;
                if (!processId.HasValue)
                    return;
                ProcessStopped.Invoke(this, new ProcessStoppedEventArgs(processId.Value));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex);
            }
            finally
            {
                process?.Dispose();
            }
        }

        /// <summary>
        /// Уведомляет об запущенном процессе. Данный метод выполняется в отдельном потоке.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void ProcessStartWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject process = null;
            try
            {
                process = (ManagementBaseObject)e.NewEvent["TargetInstance"];
                if (process is null || ProcessStarted is null)
                    return;
                var processViewModel = new ProcessViewModel(process);
                ProcessStarted.Invoke(this, new ProcessStartedEventArgs(processViewModel));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex);
            }
            finally
            {
                process?.Dispose();
            }
        }
    }
}
