using ProcessWatcher.Classes.Managers;
using ProcessWatcher.Models;
using System;
using System.Windows.Forms;

namespace ProcessWatcher.Views
{
    /// <summary>
    /// Представление для отображения подробностей о процессе.
    /// </summary>
    public partial class ProcessWatcherItemUserControl : UserControl
    {
        /// <summary>
        /// Инициализирует новый экземляр класса <see cref="ProcessWatcherItemUserControl"/> с заданной моделью процесса.
        /// </summary>
        /// <param name="processViewModel">Модель процесса.</param>
        public ProcessWatcherItemUserControl(ProcessViewModel processViewModel)
        {
            InitializeComponent();
            _creationClassNameTextBox.Text = processViewModel.CreationClassName;
            _captionTextBox.Text = processViewModel.Caption;
            _commandLineTextBox.Text = processViewModel.CommandLine;
            _creationDateTextBox.Text = processViewModel.CreationDate.ToString();
            _CSCreationClassNameTextBox.Text = processViewModel.CSCreationClassName;
            _CSNameTextBox.Text = processViewModel.CSName;
            _descriptionTextBox.Text = processViewModel.Description;
            _executablePathTextBox.Text = processViewModel.ExecutablePath;
            _executionStateTextBox.Text = processViewModel.ExecutionState.ToString();
            _handleTextBox.Text = processViewModel.Handle;
            _handleCountTextBox.Text = processViewModel.HandleCount.ToString();
            _installDateTextBox.Text = processViewModel.InstallDate.ToString();
            _kernelModeTimeTextBox.Text = processViewModel.KernelModeTime.ToString();
            _maximumWorkingSetSizeTextBox.Text = processViewModel.MaximumWorkingSetSize.ToString();
            _minimumWorkingSetSizeTextBox.Text = processViewModel.MinimumWorkingSetSize.ToString();
            _nameTextBox.Text = processViewModel.Name;
            _OSCreationClassNameTextBox.Text = processViewModel.OSCreationClassName;
            _OSNameTextBox.Text = processViewModel.OSName;
            _otherOperationCountTextBox.Text = processViewModel.OtherOperationCount.ToString();
            _otherTransferCountTextBox.Text = processViewModel.OtherTransferCount.ToString();
            _pageFaultsTextBox.Text = processViewModel.PageFaults.ToString();
            _pageFileUsageTextBox.Text = processViewModel.PageFileUsage.ToString();
            _parentProcessIdTextBox.Text = processViewModel.ParentProcessId.ToString();
            _peakPageFileUsageTextBox.Text = processViewModel.PeakPageFileUsage.ToString();
            _peakVirtualSizeTextBox.Text = processViewModel.PeakVirtualSize.ToString();
            _peakWorkingSetSizeTextBox.Text = processViewModel.PeakWorkingSetSize.ToString();
            _priorityTextBox.Text = processViewModel.Priority.ToString();
            _privatePageCountTextBox.Text = processViewModel.PrivatePageCount.ToString();
            _processIdTextBox.Text = processViewModel.ProcessId.ToString();
            _quotaNonPagedPoolUsageTextBox.Text = processViewModel.QuotaNonPagedPoolUsage.ToString();
            _quotaPagedPoolUsageTextBox.Text = processViewModel.QuotaPagedPoolUsage.ToString();
            _quotaPeakNonPagedPoolUsageTextBox.Text = processViewModel.QuotaPeakNonPagedPoolUsage.ToString();
            _quotaPeakPagedPoolUsageTextBox.Text = processViewModel.QuotaPeakPagedPoolUsage.ToString();
            _readOperationCountTextBox.Text = processViewModel.ReadOperationCount.ToString();
            _readTransferCountTextBox.Text = processViewModel.ReadTransferCount.ToString();
            _sessionIdTextBox.Text = processViewModel.SessionId.ToString();
            _statusTextBox.Text = processViewModel.Status;
            _terminationDate.Text = processViewModel.TerminationDate.ToString();
            _threadCountTextBox.Text = processViewModel.ThreadCount.ToString();
            _userModeTimeTextBox.Text = processViewModel.UserModeTime.ToString();
            _virtualSizeTextBox.Text = processViewModel.VirtualSize.ToString();
            _windowsVersionTextBox.Text = processViewModel.WindowsVersion;
            _workingSetSizeTextBox.Text = processViewModel.WorkingSetSize.ToString();
            _writeOperationCountTextBox.Text = processViewModel.WriteOperationCount.ToString();
            _writeTransferCountTextBox.Text = processViewModel.WriteTransferCount.ToString();
        }

        /// <summary>
        /// Вовзращает на страницу со списком процессов.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            ControlViewerManager.SwitchTo(new ProcessWatcherUserControl());
        }
    }
}