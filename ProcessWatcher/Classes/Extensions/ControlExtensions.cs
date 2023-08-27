using System;
using System.Windows.Forms;

namespace ProcessWatcher.Classes.Extensions
{
    /// <summary>
    /// Расширения для элементов управления.
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Выполняет указанный делегат в том потоке, которому принадлежит базовый дескриптор окна элемента управления.
        /// </summary>
        /// <param name="control">Элемент управления.</param>
        /// <param name="method">Делегат, содержащий метод, который требуется вызывать в контексте потока элемента управления.</param>
        /// <returns>Значение, возвращаемое вызываемым делегатом, или значение null, если делегат не возвращает никакого значения.</returns>
        public static object Invoke(this Control control, Action method)
        {
            return control.Invoke(method);
        }
    }
}
