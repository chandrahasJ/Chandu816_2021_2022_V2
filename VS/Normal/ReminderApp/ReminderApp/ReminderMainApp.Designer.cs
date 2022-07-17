
namespace ReminderApp
{
    partial class ReminderMainApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReminderMainApp));
            this.MessageNotifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms_ReminderStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreReminderAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTheReminder = new System.Windows.Forms.Button();
            this.btnStartTheReminder = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtReminderInterval = new System.Windows.Forms.TextBox();
            this.reminderTimer = new System.Windows.Forms.Timer(this.components);
            this.cbIsStartUp = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSoundShow = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cmbReminderNotifcationSound = new System.Windows.Forms.CheckBox();
            this.lblSoundHide = new System.Windows.Forms.Label();
            this.cms_ReminderStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessageNotifier
            // 
            this.MessageNotifier.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.MessageNotifier.ContextMenuStrip = this.cms_ReminderStrip;
            this.MessageNotifier.Icon = ((System.Drawing.Icon)(resources.GetObject("MessageNotifier.Icon")));
            this.MessageNotifier.Visible = true;
            // 
            // cms_ReminderStrip
            // 
            this.cms_ReminderStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_ReminderStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreReminderAppToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.cms_ReminderStrip.Name = "cms_ReminderStrip";
            this.cms_ReminderStrip.Size = new System.Drawing.Size(229, 52);
            // 
            // restoreReminderAppToolStripMenuItem
            // 
            this.restoreReminderAppToolStripMenuItem.Name = "restoreReminderAppToolStripMenuItem";
            this.restoreReminderAppToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.restoreReminderAppToolStripMenuItem.Text = "Restore Reminder App";
            this.restoreReminderAppToolStripMenuItem.Click += new System.EventHandler(this.restoreReminderAppToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Time Interval (mins):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Add Message : ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnAddTheReminder
            // 
            this.btnAddTheReminder.Location = new System.Drawing.Point(52, 239);
            this.btnAddTheReminder.Name = "btnAddTheReminder";
            this.btnAddTheReminder.Size = new System.Drawing.Size(143, 42);
            this.btnAddTheReminder.TabIndex = 2;
            this.btnAddTheReminder.Text = "Add The Timer";
            this.btnAddTheReminder.UseVisualStyleBackColor = true;
            this.btnAddTheReminder.Click += new System.EventHandler(this.btnAddTheReminder_Click);
            // 
            // btnStartTheReminder
            // 
            this.btnStartTheReminder.Location = new System.Drawing.Point(224, 239);
            this.btnStartTheReminder.Name = "btnStartTheReminder";
            this.btnStartTheReminder.Size = new System.Drawing.Size(143, 42);
            this.btnStartTheReminder.TabIndex = 3;
            this.btnStartTheReminder.Text = "Start Reminder";
            this.btnStartTheReminder.UseVisualStyleBackColor = true;
            this.btnStartTheReminder.Click += new System.EventHandler(this.btnStartTheReminder_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(180, 54);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(224, 22);
            this.txtMessage.TabIndex = 4;
            // 
            // txtReminderInterval
            // 
            this.txtReminderInterval.Location = new System.Drawing.Point(182, 21);
            this.txtReminderInterval.Name = "txtReminderInterval";
            this.txtReminderInterval.Size = new System.Drawing.Size(224, 22);
            this.txtReminderInterval.TabIndex = 5;
            this.txtReminderInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReminderInterval_KeyPress);
            // 
            // reminderTimer
            // 
            this.reminderTimer.Tick += new System.EventHandler(this.reminderTimer_Tick);
            // 
            // cbIsStartUp
            // 
            this.cbIsStartUp.AutoSize = true;
            this.cbIsStartUp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIsStartUp.Location = new System.Drawing.Point(48, 88);
            this.cbIsStartUp.Name = "cbIsStartUp";
            this.cbIsStartUp.Size = new System.Drawing.Size(149, 21);
            this.cbIsStartUp.TabIndex = 6;
            this.cbIsStartUp.Text = "Active at Start-Up :";
            this.cbIsStartUp.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txtReminderInterval);
            this.groupBox1.Controls.Add(this.cbIsStartUp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAddTheReminder);
            this.groupBox1.Controls.Add(this.txtMessage);
            this.groupBox1.Controls.Add(this.btnStartTheReminder);
            this.groupBox1.Location = new System.Drawing.Point(21, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 295);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reminder Settings Data";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblSoundShow);
            this.panel1.Controls.Add(this.btnPlay);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.cmbReminderNotifcationSound);
            this.panel1.Location = new System.Drawing.Point(7, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 112);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sound Filename :";
            // 
            // lblSoundShow
            // 
            this.lblSoundShow.AutoSize = true;
            this.lblSoundShow.Location = new System.Drawing.Point(177, 74);
            this.lblSoundShow.Name = "lblSoundShow";
            this.lblSoundShow.Size = new System.Drawing.Size(0, 17);
            this.lblSoundShow.TabIndex = 10;
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Image = global::ReminderApp.Properties.Resources.Play_Png;
            this.btnPlay.Location = new System.Drawing.Point(307, 11);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(79, 52);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Image = global::ReminderApp.Properties.Resources.Browse_Png;
            this.btnBrowse.Location = new System.Drawing.Point(208, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(81, 51);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbReminderNotifcationSound
            // 
            this.cmbReminderNotifcationSound.AutoSize = true;
            this.cmbReminderNotifcationSound.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmbReminderNotifcationSound.Location = new System.Drawing.Point(7, 11);
            this.cmbReminderNotifcationSound.Name = "cmbReminderNotifcationSound";
            this.cmbReminderNotifcationSound.Size = new System.Drawing.Size(184, 21);
            this.cmbReminderNotifcationSound.TabIndex = 7;
            this.cmbReminderNotifcationSound.Text = "Play Notification Sound :";
            this.cmbReminderNotifcationSound.UseVisualStyleBackColor = true;
            this.cmbReminderNotifcationSound.CheckedChanged += new System.EventHandler(this.cmbReminderNotifcation_CheckedChanged);
            // 
            // lblSoundHide
            // 
            this.lblSoundHide.AutoSize = true;
            this.lblSoundHide.Location = new System.Drawing.Point(373, 306);
            this.lblSoundHide.Name = "lblSoundHide";
            this.lblSoundHide.Size = new System.Drawing.Size(0, 17);
            this.lblSoundHide.TabIndex = 11;
            this.lblSoundHide.Visible = false;
            // 
            // ReminderMainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 326);
            this.Controls.Add(this.lblSoundHide);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReminderMainApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reminder App";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.cms_ReminderStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon MessageNotifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTheReminder;
        private System.Windows.Forms.Button btnStartTheReminder;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtReminderInterval;
        private System.Windows.Forms.ContextMenuStrip cms_ReminderStrip;
        private System.Windows.Forms.ToolStripMenuItem restoreReminderAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer reminderTimer;
        private System.Windows.Forms.CheckBox cbIsStartUp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cmbReminderNotifcationSound;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSoundShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSoundHide;
    }
}

