using ProcessWatcher.Models;
using System;

namespace ProcessWatcher.Classes.EventArguments
{
    /// <summary>
    /// Аргументы события запуска процесса.
    /// </summary>
    public class ProcessStartedEventArgs : EventArgs
    {
        /// <summary>
        /// Инициализирует новый экземляр класса <see cref="ProcessStartedEventArgs"/> с заданной моделью процесса.
        /// </summary>
        /// <param name="process">Модель процесса.</param>
        public ProcessStartedEventArgs(ProcessViewModel process)
        {
            Process = process;
        }

        /// <summary>
        /// Модель процесса.
        /// </summary>
        public ProcessViewModel Process { get; }
    }
}
