using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp
{
    public class Setting
    {
        public bool StartUp { get; set; }
        public bool NotifcationSound { get; set; }
        public SettingAudio SettingAudio { get; set; }
    }

    public class SettingAudio
    {
        public string FilePath { get; set; }
    }
}
