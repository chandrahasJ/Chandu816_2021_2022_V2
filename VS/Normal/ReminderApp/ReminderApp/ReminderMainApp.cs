using System;
using System.IO;
using System.Windows.Forms;

namespace ReminderApp
{
    public partial class ReminderMainApp : Form
    {
        private readonly HelperFile helperFile; 
        string AppName = "Reminder App";

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
                        NotifcationSound = cmbReminderNotifcationSound.Checked
                    }
                };


                if (!(reminder.ReminderTime >= 2 && reminder.ReminderTime <= 60))
                {
                    MessageBox.Show($"Reminder Interval should be greater than 1 minute & Less than 60 mintues.",
                          this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cmbReminderNotifcationSound.Checked == true)
                {
                    if (File.Exists(lblSoundHide.Text))
                    {
                        if (!(helperFile.GetWavFileDurationInSeconds(lblSoundHide.Text) <= 5.0))
                        {
                            MessageBox.Show($"Wav file's duration should be less than or equal to 5 seconds.",
                                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            try
                            {
                                string filePath = helperFile.WavFolderPath + "\\" + Path.GetFileName(lblSoundHide.Text);
                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath);
                                }

                                File.Copy(lblSoundHide.Text, filePath);
                                reminder.Setting.SettingAudio = new SettingAudio()
                                {
                                    FilePath = filePath
                                };
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Expection occured while saving the wav file. \n Error Message {ex.Message}",
                                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }                    
                }
                
                helperFile.SetStartup(cbIsStartUp.Checked, this.Text);
                
                string jsonFileName = $"Reminder_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.json";
                string jsonFilePath = $"{helperFile.JsonFolderPath}{jsonFileName}";

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
            MessageNotifier.BalloonTipTitle = AppName;
            MessageNotifier.ShowBalloonTip(5);
        }

        private void Use_Notify_Timer(Reminder reminder)
        {                  
            string Message = $"{reminder.ReminderMessage } \n Next Message will be shown in {reminder.ReminderTime} mins";             
            helperFile.ShowNotifyBalloon(AppName, Message, Properties.Resources.Reminder);
            if (reminder.Setting?.NotifcationSound == true)
            {
                if (reminder.Setting?.SettingAudio != null)
                {
                    helperFile.PlayNotificationSound(reminder.Setting?.SettingAudio.FilePath);
                }
                else
                {
                    helperFile.PlayNotificationSound(Properties.Resources.LoudBeep);
                }
            }           
        }

        private void reminderTimer_Tick(object sender, EventArgs e)
        {
            Reminder reminder = GetReminderData();
            if (reminder != null)
            {
                Use_Notify_Timer(reminder);
                
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Create a new OpenFileDialog.
            OpenFileDialog dlg = new OpenFileDialog();

            // Make sure the dialog checks for existence of the 
            // selected file.
            dlg.CheckFileExists = true;

            // Allow selection of .wav files only.
            dlg.Filter = "WAV files (*.wav)|*.wav";
            dlg.DefaultExt = ".wav";

            // Activate the file selection dialog.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file's path from the dialog.                 
                string fileName =  Path.GetFileName(dlg.FileName);
                string wavSeconds = helperFile.GetWavFileDurationInSeconds(dlg.FileName).ToString();
                this.lblSoundShow.Text = $"{fileName} ({wavSeconds} sec(s))";

                this.lblSoundHide.Text = dlg.FileName;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.lblSoundHide.Text))
            {
                helperFile.PlayNotificationSound(this.lblSoundHide.Text);
            }            
        }

        private void cmbReminderNotifcation_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbReminderNotifcationSound.Checked == true)
            {
                btnBrowse.Enabled = true;
                btnPlay.Enabled = true;                
            }
            else
            {
                btnBrowse.Enabled = false;
                btnPlay.Enabled = false;
            }
            this.lblSoundShow.Text = "";
            this.lblSoundHide.Text = "";
        }
    }
}
