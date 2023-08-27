using ProcessWatcher.Classes.Managers;
using System.Windows.Forms;

namespace ProcessWatcher
{
    /// <summary>
    /// Главная форма приложения.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземляр класса <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ControlViewerManager.Initialize(_controlViewerPanel);
        }

        /// <summary>
        /// Очищает ресурсы представлений.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Аргументы события.</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (UserControl control in _controlViewerPanel.Controls)
                control.Dispose();
        }
    }
}
