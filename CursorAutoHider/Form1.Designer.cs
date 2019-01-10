namespace CursorAutoHider
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_minimumDistanceUD = new System.Windows.Forms.NumericUpDown();
            this.m_timeThresholdUD = new System.Windows.Forms.NumericUpDown();
            this.m_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.m_watchedApplicationTb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_minimumDistanceUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_timeThresholdUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Minimum distance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time threshold [s]";
            // 
            // m_minimumDistanceUD
            // 
            this.m_minimumDistanceUD.Location = new System.Drawing.Point(225, 47);
            this.m_minimumDistanceUD.Name = "m_minimumDistanceUD";
            this.m_minimumDistanceUD.Size = new System.Drawing.Size(120, 20);
            this.m_minimumDistanceUD.TabIndex = 4;
            this.m_minimumDistanceUD.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // m_timeThresholdUD
            // 
            this.m_timeThresholdUD.Location = new System.Drawing.Point(225, 92);
            this.m_timeThresholdUD.Name = "m_timeThresholdUD";
            this.m_timeThresholdUD.Size = new System.Drawing.Size(120, 20);
            this.m_timeThresholdUD.TabIndex = 5;
            this.m_timeThresholdUD.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // m_notifyIcon
            // 
            this.m_notifyIcon.BalloonTipText = "Automatically hides cursor when idle";
            this.m_notifyIcon.BalloonTipTitle = "Cursor auto hider";
            this.m_notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_notifyIcon.Icon")));
            this.m_notifyIcon.Text = "Cursor auto hider";
            this.m_notifyIcon.Visible = true;
            this.m_notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_Click);
            this.m_notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Apply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Watched application";
            // 
            // m_watchedApplicationTb
            // 
            this.m_watchedApplicationTb.Location = new System.Drawing.Point(225, 139);
            this.m_watchedApplicationTb.Name = "m_watchedApplicationTb";
            this.m_watchedApplicationTb.Size = new System.Drawing.Size(120, 20);
            this.m_watchedApplicationTb.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_watchedApplicationTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_timeThresholdUD);
            this.Controls.Add(this.m_minimumDistanceUD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.m_minimumDistanceUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_timeThresholdUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown m_minimumDistanceUD;
        private System.Windows.Forms.NumericUpDown m_timeThresholdUD;
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_watchedApplicationTb;
    }
}

