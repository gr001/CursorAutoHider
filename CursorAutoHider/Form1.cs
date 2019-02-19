using Gma.System.MouseKeyHook;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CursorAutoHider
{
    public partial class Form1 : Form
    {
        private IKeyboardMouseEvents m_GlobalHook;

        Timer m_timer;
        Timer m_checkProcessTimer = new Timer();
        Point? m_lastMousePosition;
        DateTime? m_lastTime;
        volatile bool m_mouseClicked;

        int m_distanceThreshold = 5;
        int m_timeThresholdS = 3;
        string m_watchedApplication = "O2TV.UWP";

        public Form1()
        {
            InitializeComponent();

            m_minimumDistanceUD.Value =
            m_distanceThreshold = Math.Max(1, AppSettings.Instance.DistanceThreshold);

            m_timeThresholdUD.Value =
            m_timeThresholdS = Math.Max(1, AppSettings.Instance.TimeThresholdS);

            m_watchedApplicationTb.Text =
            m_watchedApplication = AppSettings.Instance.WatchedApplication;

            m_checkProcessTimer.Interval = 1000;
            m_checkProcessTimer.Tick += CheckProcessTimer_Tick;
            m_checkProcessTimer.Start();

            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;

            this.FormClosed += Form1_FormClosed;
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            //m_logControl.Items.Add("Mouse clicked: " + e.Clicked);
            m_mouseClicked |= e.Clicked;
        }

        private void CheckProcessTimer_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_watchedApplication) || Process.GetProcessesByName(m_watchedApplication).Length > 0)
            {
                if (m_timer == null)
                {
                    m_lastTime = null;
                    m_lastMousePosition = null;

                    m_timer = new Timer();
                    m_timer.Interval = 300;
                    m_timer.Tick += Timer_Tick;
                    m_timer.Start();
                }
            }
            else if (m_timer != null)
            {
                m_timer.Stop();
                m_timer = null;
                ShowMouse();

                m_lastTime = null;
                m_lastMousePosition = null;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_checkProcessTimer != null)
                m_checkProcessTimer.Stop();

            if (m_timer != null)
                m_timer.Stop();

            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            CursorsManager.Instance.RestoreCursors();
        }

        private void ShowMouse()
        {
            CursorsManager.Instance.RestoreCursors();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var mousePosition = System.Windows.Forms.Cursor.Position;
            var now = DateTime.Now;

            if (m_lastMousePosition.HasValue)
            {
                double xdiff = (mousePosition.X - m_lastMousePosition.Value.X);
                double ydiff = (mousePosition.Y - m_lastMousePosition.Value.Y);
                double distSqr = xdiff * xdiff + ydiff * ydiff;

                if ((now - m_lastTime.Value).TotalSeconds > m_timeThresholdS)
                {
                    if (!m_mouseClicked && distSqr < m_distanceThreshold)
                        HideMouse();
                    else
                        ShowMouse();

                    m_mouseClicked = false;
                    m_lastTime = null;
                    m_lastMousePosition = null;
                }
                else if (distSqr > m_distanceThreshold)
                    ShowMouse();
            }
            else
            {
                m_lastTime = now;
                m_lastMousePosition = mousePosition;
            }
        }

        private void HideMouse()
        {
            CursorsManager.Instance.HideCursors();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                m_notifyIcon.Visible = true;
            }
        }

        private void NotifyIcon_Click(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            m_notifyIcon.Visible = false;
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            m_distanceThreshold = Math.Max(1, (int)m_minimumDistanceUD.Value);
            m_minimumDistanceUD.Value = m_distanceThreshold;

            m_timeThresholdS = Math.Max(1, (int)m_timeThresholdUD.Value);
            m_timeThresholdUD.Value = m_timeThresholdS;

            m_watchedApplication = m_watchedApplicationTb.Text;

            m_lastMousePosition = null;
            m_lastTime = null;

            AppSettings.Instance.DistanceThreshold = m_distanceThreshold;
            AppSettings.Instance.TimeThresholdS = m_timeThresholdS;
            AppSettings.Instance.WatchedApplication = m_watchedApplication;

            AppSettings.Instance.Save();
        }
    }
}
