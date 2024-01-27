﻿namespace Week_3_lab_08_Time_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store the Time objects
            List<Time> times = new List<Time>()
            {
                new(9, 35),
                new(18, 5),
                new(20, 500),
                new(10),
                new()
            };

            // Display all the objects with the initial time format (Hour12)
            TimeFormat format = TimeFormat.Hour12;
            Console.WriteLine($"\nTime format is {format}");
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }

            // Change the format to Mil and display all the objects
            format = TimeFormat.Mil;
            Console.WriteLine($"\nSetting time format to {format}");
            Time.SetTimeFormat(format);
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }

            // Change the format to Hour24 and display all the objects
            format = TimeFormat.Hour24;
            Console.WriteLine($"\nSetting time format to {format}");
            Time.SetTimeFormat(format);
            foreach (Time t in times)
            {
                Console.WriteLine(t);
            }
        }

        public enum TimeFormat
        {
            Mil,
            Hour12,
            Hour24
        }

        public class Time
        {
            private static TimeFormat TIME_FORMAT = TimeFormat.Hour12;
            public int Hour { get; }
            public int Minute { get; }

            public Time(int hour = 0, int minute = 0)
            {
                Hour = (hour >= 0 && hour < 24) ? hour : 0;
                Minute = (minute >= 0 && minute < 60) ? minute : 0;
            }

            public override string ToString()
            {
                switch (TIME_FORMAT)
                {
                    case TimeFormat.Mil:
                        return $"{Hour:D2}{Minute:D2}";
                    case TimeFormat.Hour24:
                        return $"{Hour:D2}:{Minute:D2}";
                    case TimeFormat.Hour12:
                        return $"{Hour % 12:D2}:{Minute:D2} {(Hour < 12 ? "AM" : "PM")}";
                    default:
                        return base.ToString();
                }
            }

            public static void SetTimeFormat(TimeFormat timeFormat)
            {
                TIME_FORMAT = timeFormat;
            }
        }
    }
}
