using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursorAutoHider
{
    public sealed class CursorWrapper : IDisposable
    {
        public CursorWrapper(User32.OCR_SYSTEM_CURSORS cursorId)
        {
            m_cursorId = cursorId;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        User32.OCR_SYSTEM_CURSORS m_cursorId;
        IntPtr m_origCursor;
        bool m_isHidden = false;

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    RestoreCursor();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CursorWrapper() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        public void HideCursor()
        {
            if (m_isHidden)
                return;

            m_origCursor = User32.CopyIcon(User32.LoadCursor(IntPtr.Zero, (int)m_cursorId));

            using (System.Windows.Forms.Cursor emptyCursor = new System.Windows.Forms.Cursor(GetType(), "HiddenCursor.cur"))
            {
                var emptyCursorCopy = emptyCursor.CopyHandle();
                User32.SetSystemCursor(emptyCursorCopy, (uint)m_cursorId);
            }

            m_isHidden = true;
        }

        public void RestoreCursor()
        {
            if (m_isHidden)
            {
                User32.SetSystemCursor(m_origCursor, (uint)m_cursorId);
                m_isHidden = false;
            }
        }
    }
}
