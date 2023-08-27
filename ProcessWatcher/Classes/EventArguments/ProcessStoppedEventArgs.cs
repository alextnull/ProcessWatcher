using System;

namespace ProcessWatcher.Classes.EventArguments
{
    /// <summary>
    /// Аргументы события остановки процесса.
    /// </summary>
    public class ProcessStoppedEventArgs : EventArgs
    {
        /// <summary>
        /// Инициализирует новый экземляр класса <see cref="ProcessStoppedEventArgs"/> с заданным идентификатором процесса.
        /// </summary>
        /// <param name="processId">Идентификатор процесса.</param>
        public ProcessStoppedEventArgs(uint processId)
        {
            ProcessId = processId;
        }

        /// <summary>
        /// Идентификатор процесса.
        /// </summary>
        public uint ProcessId { get; }
    }
}
