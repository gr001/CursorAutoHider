using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursorAutoHider
{
    sealed class CursorsManager
    {
        List<CursorWrapper> m_cursors = new List<CursorWrapper>();
        public static CursorsManager Instance { get; } = new CursorsManager();

        public bool IsCursorHidden { get { return m_cursors.Count != 0; } }

        public void HideCursors()
        {
            if (this.IsCursorHidden)
                return;

            var screenSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            User32.SetCursorPos(screenSize.Width / 2, screenSize.Height / 2);

            foreach (var item in Enum.GetValues(typeof(User32.OCR_SYSTEM_CURSORS)).Cast<User32.OCR_SYSTEM_CURSORS>())
            {
                var cursor = new CursorWrapper(item);
                m_cursors.Add(cursor);
                cursor.HideCursor();
            }
        }

        public void RestoreCursors()
        {
            foreach (var item in m_cursors)
                item.Dispose();

            m_cursors.Clear();
        }
    }
}
