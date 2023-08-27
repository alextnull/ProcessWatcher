using System;

namespace ProcessWatcher.Classes.Exceptions
{
    /// <summary>
    /// Представляет ошибку, когда доступ к элементам управления был осуществлён до инициализации.
    /// </summary>
    public class NotInitializedException : Exception
    {
    }
}
