using System;

namespace EnumExample
{
    public enum WeekDays : byte
    {
        Monday = 1, Tuesday = 3, Wednesday = 5, Thursday = 7, Friday = 9
    }
    class Program
    {
        public static WeekDays MeetingDay { get; set; } = WeekDays.Monday;
        static void Main(string[] args)
        {
            Console.WriteLine("Default value of Meeting Day :> " + MeetingDay);
            //Error only values list under WeekDays can be assigned to MeetingDay property
            //MeetingDay = "Sunday" 
            MeetingDay = WeekDays.Thursday;
            Console.WriteLine("Rescheduling the Meeting Day :> " + MeetingDay);
            Console.ReadLine();
        }
    }
}
