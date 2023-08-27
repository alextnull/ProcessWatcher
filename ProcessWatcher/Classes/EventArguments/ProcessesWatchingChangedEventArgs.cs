using System;

namespace ProcessWatcher.Classes.EventArguments
{
    /// <summary>
    /// Аргументы события изменения состояния отслеживания процессов.
    /// </summary>
    public class ProcessesWatchingChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Инициализирует новый экземляр класса <see cref="ProcessesWatchingChangedEventArgs"/> текущим состоянием отслеживания.
        /// </summary>
        /// <param name="isWatching">Текущее состояние отслеживания.</param>
        public ProcessesWatchingChangedEventArgs(bool isWatching)
        {
            IsWatching = isWatching;
        }

        /// <summary>
        /// Состояние отслеживания.
        /// </summary>
        public bool IsWatching { get; }
    }
}
