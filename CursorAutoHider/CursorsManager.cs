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
            var destPosition = new System.Drawing.Point(screenSize.Width / 2, screenSize.Height / 2);
            var mousePosition = System.Windows.Forms.Cursor.Position;

            int stepsCount = 10;

            var step = new System.Drawing.Point((destPosition.X - mousePosition.X) / stepsCount, (destPosition.Y - mousePosition.Y) / stepsCount);

            for(int i=0; i<=stepsCount; i++)
            {
                mousePosition.Offset(step);
                System.Threading.Thread.Sleep(3);
                User32.SetCursorPos(mousePosition.X, mousePosition.Y);
            }


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
