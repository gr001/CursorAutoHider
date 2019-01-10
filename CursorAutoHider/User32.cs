using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CursorAutoHider
{
    public static class User32
    {
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern IntPtr CopyIcon(IntPtr hIcon);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string lpFileName);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("user32.dll")]
        public static extern bool SetSystemCursor(IntPtr hcur, uint id);

        [DllImport("user32")]
        public static extern bool DestroyCursor(IntPtr hcur);

        public enum OCR_SYSTEM_CURSORS : uint
        {
            /// <summary>
            /// Standard arrow and small hourglass
            /// </summary>
            OCR_APPSTARTING = 32650,
            /// <summary>
            /// Standard arrow
            /// </summary>
            OCR_NORMAL = 32512,
            /// <summary>
            /// Crosshair
            /// </summary>
            OCR_CROSS = 32515,
            /// <summary>
            /// Windows 2000/XP: Hand
            /// </summary>
            OCR_HAND = 32649,
            /// <summary>
            /// Arrow and question mark
            /// </summary>
            OCR_HELP = 32651,
            /// <summary>
            /// I-beam
            /// </summary>
            OCR_IBEAM = 32513,
            /// <summary>
            /// Slashed circle
            /// </summary>
            OCR_NO = 32648,
            /// <summary>
            /// Four-pointed arrow pointing north, south, east, and west
            /// </summary>
            OCR_SIZEALL = 32646,
            /// <summary>
            /// Double-pointed arrow pointing northeast and southwest
            /// </summary>
            OCR_SIZENESW = 32643,
            /// <summary>
            /// Double-pointed arrow pointing north and south
            /// </summary>
            OCR_SIZENS = 32645,
            /// <summary>
            /// Double-pointed arrow pointing northwest and southeast
            /// </summary>
            OCR_SIZENWSE = 32642,
            /// <summary>
            /// Double-pointed arrow pointing west and east
            /// </summary>
            OCR_SIZEWE = 32644,
            /// <summary>
            /// Vertical arrow
            /// </summary>
            OCR_UP = 32516,
            /// <summary>
            /// Hourglass
            /// </summary>
            OCR_WAIT = 32514
        }
    }
}
