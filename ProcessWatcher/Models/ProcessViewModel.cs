using System;
using System.Management;

namespace ProcessWatcher.Models
{
    /// <summary>
    /// Модель процесса, которая содержит данные из класса WMI Win32_Process.
    /// </summary>
    public class ProcessViewModel
    {
        /// <summary>
        /// Инициализирует новый экземляр класса <see cref="ProcessViewModel"/> данными из Win32_Process.
        /// </summary>
        /// <param name="processWin32">Экземпляр класса Win32_Process.</param>
        /// <exception cref="ArgumentNullException">Выдаётся, если экземпляр класса Win32_Process отсутствует.</exception>
        public ProcessViewModel(ManagementBaseObject processWin32)
        {
            if (processWin32 is null)
                throw new ArgumentNullException(nameof(processWin32));

            CreationClassName = processWin32[nameof(CreationClassName)] as string;
            Caption = processWin32[nameof(Caption)] as string;
            CommandLine = processWin32[nameof(CommandLine)] as string;
            CreationDate = processWin32[nameof(CreationDate)] as DateTime?;
            CSCreationClassName = processWin32[nameof(CSCreationClassName)] as string;
            CSName = processWin32[nameof(CSName)] as string;
            Description = processWin32[nameof(Description)] as string;
            ExecutablePath = processWin32[nameof(ExecutablePath)] as string;
            ExecutionState = processWin32[nameof(ExecutionState)] as ushort?;
            Handle = processWin32[nameof(Handle)] as string;
            HandleCount = processWin32[nameof(HandleCount)] as uint?;
            InstallDate = processWin32[nameof(InstallDate)] as DateTime?;
            KernelModeTime = processWin32[nameof(KernelModeTime)] as ulong?;
            MaximumWorkingSetSize = processWin32[nameof(MaximumWorkingSetSize)] as uint?;
            MinimumWorkingSetSize = processWin32[nameof(MinimumWorkingSetSize)] as uint?;
            Name = processWin32[nameof(Name)] as string;
            OSCreationClassName = processWin32[nameof(OSCreationClassName)] as string;
            OSName = processWin32[nameof(OSName)] as string;
            OtherOperationCount = processWin32[nameof(OtherOperationCount)] as ulong?;
            OtherTransferCount = processWin32[nameof(OtherTransferCount)] as ulong?;
            PageFaults = processWin32[nameof(PageFaults)] as uint?;
            PageFileUsage = processWin32[nameof(PageFileUsage)] as uint?;
            ParentProcessId = processWin32[nameof(ParentProcessId)] as uint?;
            PeakPageFileUsage = processWin32[nameof(PeakPageFileUsage)] as uint?;
            PeakVirtualSize = processWin32[nameof(PeakVirtualSize)] as ulong?;
            PeakWorkingSetSize = processWin32[nameof(PeakWorkingSetSize)] as uint?;
            Priority = processWin32[nameof(Priority)] as uint?;
            PrivatePageCount = processWin32[nameof(PrivatePageCount)] as ulong?;
            ProcessId = processWin32[nameof(ProcessId)] as uint?;
            QuotaNonPagedPoolUsage = processWin32[nameof(QuotaNonPagedPoolUsage)] as uint?;
            QuotaPagedPoolUsage = processWin32[nameof(QuotaPagedPoolUsage)] as uint?;
            QuotaPeakNonPagedPoolUsage = processWin32[nameof(QuotaPeakNonPagedPoolUsage)] as uint?;
            QuotaPeakPagedPoolUsage = processWin32[nameof(QuotaPeakPagedPoolUsage)] as uint?;
            ReadOperationCount = processWin32[nameof(ReadOperationCount)] as ulong?;
            ReadTransferCount = processWin32[nameof(ReadTransferCount)] as ulong?;
            SessionId = processWin32[nameof(SessionId)] as uint?;
            Status = processWin32[nameof(Status)] as string;
            TerminationDate = processWin32[nameof(TerminationDate)] as DateTime?;
            ThreadCount = processWin32[nameof(ThreadCount)] as uint?;
            UserModeTime = processWin32[nameof(UserModeTime)] as ulong?;
            VirtualSize = processWin32[nameof(VirtualSize)] as ulong?;
            WindowsVersion = processWin32[nameof(WindowsVersion)] as string;
            WorkingSetSize = processWin32[nameof(WorkingSetSize)] as ulong?;
            WriteOperationCount = processWin32[nameof(WriteOperationCount)] as ulong?;
            WriteTransferCount = processWin32[nameof(WriteTransferCount)] as ulong?;
        }

        /// <summary>
        /// Имя класса или подкласса, используемого при создании экземпляра.
        /// </summary>
        public string CreationClassName { get; set; }

        /// <summary>
        /// Краткое описание объекта — однострочный текст.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Командная строка, используемая для запуска определенного процесса, если применимо.
        /// </summary>
        public string CommandLine { get; set; }

        /// <summary>
        /// Дата начала выполнения процесса.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Имя класса создания системы компьютеров с областью действия.
        /// </summary>
        public string CSCreationClassName { get; set; }

        /// <summary>
        /// Имя системы компьютеров для определения области.
        /// </summary>
        public string CSName { get; set; }

        /// <summary>
        /// Описание объекта.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Путь к исполняемому файлу процесса.
        /// </summary>
        public string ExecutablePath { get; set; }

        /// <summary>
        /// Текущее рабочее состояние процесса.
        /// </summary>
        public ushort? ExecutionState { get; set; }

        /// <summary>
        /// Идентификатор процесса.
        /// </summary>
        public string Handle { get; set; }

        /// <summary>
        /// Общее количество открытых дескрипторов, принадлежащих процессу.
        /// </summary>
        public uint? HandleCount { get; set; }

        /// <summary>
        /// Дата установки объекта. 
        /// </summary>
        public DateTime? InstallDate { get; set; }

        /// <summary>
        /// Время в режиме ядра в миллисекундах.
        /// </summary>
        public ulong? KernelModeTime { get; set; }

        /// <summary>
        /// Максимальный размер рабочего набора процесса. <br/>
        /// Рабочий набор процесса — это набор страниц памяти, видимых процессу в физической ОЗУ.
        /// </summary>
        public uint? MaximumWorkingSetSize { get; set; }

        /// <summary>
        /// Минимальный размер рабочего набора процесса. <br/>
        /// Рабочий набор процесса — это набор страниц памяти, видимых процессу в физической ОЗУ.
        /// </summary>
        public uint? MinimumWorkingSetSize { get; set; }

        /// <summary>
        /// Имя исполняемого файла, ответственного за процесс, эквивалентно свойству Имя процесса в диспетчере задач.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Имя класса создания операционной системы для определения области.
        /// </summary>
        public string OSCreationClassName { get; set; }

        /// <summary>
        /// Имя операционной системы области.
        /// </summary>
        public string OSName { get; set; }

        /// <summary>
        /// Количество выполненных операций ввода-вывода, которые не являются операциями чтения или записи.
        /// </summary>
        public ulong? OtherOperationCount { get; set; }

        /// <summary>
        /// Объем данных, передаваемых во время операций, которые не являются операциями чтения или записи.
        /// </summary>
        public ulong? OtherTransferCount { get; set; }

        /// <summary>
        /// Количество ошибок страниц, создаваемых процессом.
        /// </summary>
        public uint? PageFaults { get; set; }

        /// <summary>
        /// Объем пространства файла подкачки, используемый процессом в данный момент. <br/>
        /// Это значение согласуется со значением VMSize в диспетчере задач.
        /// </summary>
        public uint? PageFileUsage { get; set; }

        /// <summary>
        /// Уникальный идентификатор процесса, создающего процесс.
        /// </summary>
        public uint? ParentProcessId { get; set; }

        /// <summary>
        /// Максимальный объем пространства в файлах подкачки, используемый в течение всего процесса.
        /// </summary>
        public uint? PeakPageFileUsage { get; set; }

        /// <summary>
        /// Максимальное виртуальное адресное пространство, которое процесс использует в любой момент времени.
        /// </summary>
        public ulong? PeakVirtualSize { get; set; }

        /// <summary>
        /// Максимальный размер рабочего набора процесса.
        /// </summary>
        public uint? PeakWorkingSetSize { get; set; }

        /// <summary>
        /// Планирование приоритета процесса в операционной системе. <br/>
        /// Чем выше значение, тем выше приоритет, получаемый процессом. <br/>
        /// Значения приоритета могут варьироваться от 0 (нуль), что является самым низким приоритетом, до 31, что является наивысшим приоритетом.
        /// </summary>
        public uint? Priority { get; set; }

        /// <summary>
        /// Текущее количество выделенных страниц, доступных только для процесса, представленного этим экземпляром Win32_Process.
        /// </summary>
        public ulong? PrivatePageCount { get; set; }

        /// <summary>
        /// Числовой идентификатор, используемый для отличия одного процесса от другого. <br/>
        /// Идентификаторы процессов допустимы от времени создания процесса до завершения процесса.
        /// </summary>
        public uint? ProcessId { get; set; }

        /// <summary>
        /// Квота использования непагрегированного пула для процесса.
        /// </summary>
        public uint? QuotaNonPagedPoolUsage { get; set; }

        /// <summary>
        /// Квота использования выстраивного пула для процесса.
        /// </summary>
        public uint? QuotaPagedPoolUsage { get; set; }

        /// <summary>
        /// Пиковая квота использования непагрегированного пула для процесса.
        /// </summary>
        public uint? QuotaPeakNonPagedPoolUsage { get; set; }

        /// <summary>
        /// Пиковая квота использования выстраивного пула для процесса.
        /// </summary>
        public uint? QuotaPeakPagedPoolUsage { get; set; }

        /// <summary>
        /// Количество выполненных операций чтения.
        /// </summary>
        public ulong? ReadOperationCount { get; set; }

        /// <summary>
        /// Объем считываемых данных.
        /// </summary>
        public ulong? ReadTransferCount { get; set; }

        /// <summary>
        /// Уникальный идентификатор, создаваемый операционной системой при создании сеанса. <br/>
        /// Сеанс охватывает период времени от входа до выхода из определенной системы.
        /// </summary>
        public uint? SessionId { get; set; }

        /// <summary>
        /// Состояние процесса.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Дата завершения процесса.
        /// </summary>
        public DateTime? TerminationDate { get; set; }

        /// <summary>
        /// Количество активных потоков в процессе.
        /// </summary>
        public uint? ThreadCount { get; set; }

        /// <summary>
        /// Время в пользовательском режиме в 100 единицах наносекунд.
        /// </summary>
        public ulong? UserModeTime { get; set; }

        /// <summary>
        /// Текущий размер виртуального адресного пространства, используемого процессом, а не физической или виртуальной памяти, фактически используемой процессом.
        /// </summary>
        public ulong? VirtualSize { get; set; }

        /// <summary>
        /// Версия Windows, в которой выполняется процесс.
        /// </summary>
        public string WindowsVersion { get; set; }

        /// <summary>
        /// Объем памяти в байтах, необходимый процессу для эффективного выполнения, для операционной системы, которая использует управление памятью на основе страниц.
        /// </summary>
        public ulong? WorkingSetSize { get; set; }

        /// <summary>
        /// Количество выполненных операций записи.
        /// </summary>
        public ulong? WriteOperationCount { get; set; }

        /// <summary>
        /// Объем записанных данных.
        /// </summary>
        public ulong? WriteTransferCount { get; set; }
    }
}
