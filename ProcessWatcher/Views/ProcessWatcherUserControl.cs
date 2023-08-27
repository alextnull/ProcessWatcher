using NLog;
using ProcessWatcher.Classes.Extensions;
using ProcessWatcher.Classes.EventArguments;
using ProcessWatcher.Classes.Managers;
using ProcessWatcher.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ProcessWatcher.Views
{
    /// <summary>
    /// Представление для отображения списка процессов.
    /// </summary>
    public partial class ProcessWatcherUserControl : UserControl
    {
        /// <summary>
        /// Менеджер для отслеживания за процессами.
        /// </summary>
        private ProcessWatcherManager _processWatcherManager;

        /// <summary>
        /// Список процессов.
        /// </summary>
        private BindingList<ProcessViewModel> _processes;

        /// <summary>
        /// Логгер.
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Инициализирует новый экземляр класса <see cref="ProcessWatcherUserControl"/>.
        /// </summary>
        public ProcessWatcherUserControl()
        {
            InitializeComponent();
            _logger = LogManager.GetCurrentClassLogger();
            _processes = new BindingList<ProcessViewModel>();
            _processesDataGrid.DataSource = _processes;
            _processWatcherManager = new ProcessWatcherManager(10);
            _processWatcherManager.ProcessStarted += ProcessWatcherManager_ProcessStarted;
            _processWatcherManager.ProcessStopped += ProcessWatcherManager_ProcessStopped;
            _processWatcherManager.ProcessesLoaded += ProcessWatcherManager_ProcessesLoaded;
            _processWatcherManager.ProcessesWatchingChanged += ProcessWatcherManager_ProcessesWatchingChanged;    
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            _processWatcherManager?.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Загружает спискок процессов.
        /// </summary>
        private void LoadProcesses()
        {
            _processes.Clear();
            _processWatcherManager.LoadProcesses();
        }

        /// <summary>
        /// Обновляет доступность элементов управления при изменении состояния отслеживания процессов.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void ProcessWatcherManager_ProcessesWatchingChanged(object sender, ProcessesWatchingChangedEventArgs e)
        {
            if (!IsHandleCreated)
                return;
            _startButton.Invoke(() => 
                _startButton.Enabled = !e.IsWatching);
            _stopButton.Invoke(() => 
                _stopButton.Enabled = e.IsWatching);
        }

        /// <summary>
        /// Запускает отслеживание запуска и остановки процессов, после загрузки списка запущенных процессов.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void ProcessWatcherManager_ProcessesLoaded(object sender, EventArgs e)
        {
            _processWatcherManager.Start();
        }

        /// <summary>
        /// Обновляет список процессов, при появлении процесса.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void ProcessWatcherManager_ProcessStarted(object sender, ProcessStartedEventArgs e)
        {
            if (e.Process is null)
                return;
            _logger.Log(LogLevel.Info, $"Добавление процесса с Id={e.Process.ProcessId} в список процессов");
            _processesDataGrid.Invoke(() => _processes.Add(e.Process));
        }

        /// <summary>
        /// Обновляет список процессов, при удаление процесса.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void ProcessWatcherManager_ProcessStopped(object sender, ProcessStoppedEventArgs e)
        {
            var process = _processes.FirstOrDefault(x => x.ProcessId == e.ProcessId);
            if (process is null)
                return;
            _logger.Log(LogLevel.Info, $"Удаление процесса с Id={e.ProcessId} из списка процессов");
            _processesDataGrid.Invoke(() => _processes.Remove(process));
        }

        /// <summary>
        /// Загружает спискок запущенных процессов.
        /// </summary>
        private void ProcessWatcherUserControl_Load(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        /// <summary>
        /// Запускает отслеживание запуска и остановки процессов.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            _logger.Log(LogLevel.Info, "Запрос пользователя для включения обновления списка процессов");
            LoadProcesses();
            _processWatcherManager.Start();
        }

        /// <summary>
        /// Останавливает отслеживание запуска и остановки процессов.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            _logger.Log(LogLevel.Info, "Запрос пользователя для отключения обновления списка процессов");
            _processWatcherManager.Stop();
        }

        /// <summary>
        /// Перенаправляет на страницу подробностей о процессе.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void ProcessesDataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var row = _processesDataGrid.Rows[e.RowIndex];
                var process = (ProcessViewModel)row.DataBoundItem;
                _logger.Log(LogLevel.Info, $"Запрос пользователя на просмотр подробной информации о процессе с Id={process.ProcessId}");
                ControlViewerManager.SwitchTo(new ProcessWatcherItemUserControl(process));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex);
            }
        }
    }
}
