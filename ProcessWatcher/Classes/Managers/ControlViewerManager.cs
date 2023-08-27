using ProcessWatcher.Classes.Exceptions;
using System;
using System.Windows.Forms;

namespace ProcessWatcher.Classes.Managers
{
    /// <summary>
    /// Менеджер навигации.
    /// </summary>
    public static class ControlViewerManager
    {
        /// <summary>
        /// Панель на которой отображается текущее представление.
        /// </summary>
        private static Panel _panel;

        /// <summary>
        /// Указывает бы ли инициализирован менеджер навигации.
        /// </summary>
        private static bool _isInitialized;

        /// <summary>
        /// Инициализирует менеджер навигации с помощью заданной панели.
        /// </summary>
        /// <param name="panel">Панель для отображение представлений.</param>
        public static void Initialize(Panel panel)
        {
            _panel = panel ?? throw new ArgumentNullException(nameof(panel));
            _isInitialized = true;
        }

        /// <summary>
        /// Отображает переданное представление.
        /// </summary>
        /// <param name="userControl">Представление.</param>
        /// <exception cref="NotInitializedException">Выдаётся в случае, если менеджер навигации был не инициализирован.</exception>
        /// <exception cref="ArgumentNullException">Выдаётся в случае, если переданной представление отсутствует.</exception>
        public static void SwitchTo(UserControl userControl)
        {
            if (!_isInitialized)
                throw new NotInitializedException();
            if (userControl is null)
                throw new ArgumentNullException(nameof(userControl));
            foreach (UserControl control in _panel.Controls)
                control.Dispose();
            _panel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            _panel.Controls.Add(userControl);
        }
    }
}
