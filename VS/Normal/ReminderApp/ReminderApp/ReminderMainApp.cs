using System;
using System.Windows.Forms;

namespace ReminderApp
{
    public partial class ReminderMainApp : Form
    {
        private readonly HelperFile helperFile;
        public ReminderMainApp()
        {
            InitializeComponent();
            helperFile = new HelperFile();
            
            Reminder reminder = GetReminderData();

            if (reminder != null && reminder.Setting?.StartUp == true)
            {
                StartTheReminderApp(reminder);
            }
            else
            {
                this.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTheReminder_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == "")
            { 
                MessageBox.Show($"Reminder Message is empty.",
                       this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtReminderInterval.Text == "")
            { 
                MessageBox.Show($"Reminder Interval is empty.",
                      this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Reminder reminder = new Reminder()
                {
                    Id = new Random().Next(),
                    ReminderTime = Convert.ToInt32(txtReminderInterval.Text),
                    ReminderMessage = txtMessage.Text,
                    Setting = new Setting()
                    {
                        StartUp = cbIsStartUp.Checked ,
                        NotifcationSound = cmbReminderNotifcation.Checked
                    }
                };


                if (!(reminder.ReminderTime >= 1 && reminder.ReminderTime <= 60))
                {
                    MessageBox.Show($"Reminder Interval should be greater than 1 minute & Less than 60 mintues.",
                          this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                helperFile.SetStartup(cbIsStartUp.Checked, this.Text);
                
                string jsonFileName = $"Reminder_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.json";
                string jsonFilePath = $"{helperFile.FolderPath}{jsonFileName}";

                if (helperFile.SaveTheJsonFile(helperFile.CreateTheJsonFile(reminder), jsonFilePath))
                {
                    MessageBox.Show($"Json File has been Saved. \n Click on \"Start Reminder\" button to get notified every {reminder.ReminderTime} mins. ",
                        this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Json File not Saved.",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                 
            }
        }

        private void btnStartTheReminder_Click(object sender, EventArgs e)
        {
            Reminder reminder = GetReminderData();
            if (reminder != null)
            {
                StartTheReminderApp(reminder);
            }
            else
            {
                MessageBox.Show("Reminder Data not yet added.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtReminderInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void restoreReminderAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Will Restore Your Application 
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Will Close Your Application 
            reminderTimer.Stop();
            TimerNotifier.Dispose();
            MessageNotifier.Dispose();
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Hide The Form when it's minimized
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void Use_Notify()
        {
            //MessageNotifier.Icon = Properties.Resources.Reminder;
            MessageNotifier.ContextMenuStrip = cms_ReminderStrip;
            MessageNotifier.BalloonTipText = "Reminder App has been Started";
            MessageNotifier.BalloonTipTitle = "Reminder App";
            MessageNotifier.ShowBalloonTip(5);
        }

        private void Use_Notify_Timer(Reminder reminder)
        {            
            TimerNotifier.Visible = true;
            TimerNotifier.Icon = Properties.Resources.Reminder;            
            TimerNotifier.BalloonTipText = $"{reminder.ReminderMessage } \n Next Message will be shown in {reminder.ReminderTime} mins";
            TimerNotifier.BalloonTipTitle = "Reminder App";
            TimerNotifier.ShowBalloonTip(10);

            if (reminder.Setting?.NotifcationSound == true)
            {
                helperFile.PlayNotificationSound(Properties.Resources.LoudBeep);
            }           
        }

        private void reminderTimer_Tick(object sender, EventArgs e)
        {
            Reminder reminder = GetReminderData();
            if (reminder != null)
            {
                Use_Notify_Timer(reminder);
                TimerNotifier.Visible = false;
            }
            else
            {
                reminderTimer.Stop();
                reminderTimer.Enabled = false;
                MessageBox.Show("Reminder Data not yet added.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Show();
            }
            
        }

        private Reminder GetReminderData()
        {
            string latestJsonFile = helperFile.GetLatestFile();
            if (!String.IsNullOrEmpty(latestJsonFile))
            {
                string jsonString = helperFile.ReadTheJsonFile(latestJsonFile);
                return helperFile.ConvertJsonStringToObject<Reminder>(jsonString);
            }           

            return null;
        }

        private string GetMSToMinutes(double reminderTime)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(reminderTime);
            return  string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
        }

        public static double ConvertMinutesToMilliseconds(double minutes)
        {
            return TimeSpan.FromMinutes(minutes).TotalMilliseconds;
        }

        public void StartTheReminderApp(Reminder reminder)
        {
            reminderTimer.Stop();
            reminderTimer.Enabled = true;
           
            reminderTimer.Interval = (int)ConvertMinutesToMilliseconds(reminder.ReminderTime);

            reminderTimer.Start();

            Use_Notify();
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
