using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
namespace ICSKorrektur
{
    class Logic
    {
        static string calenderFile = String.Empty;
        static Calendar calendar;
        public static bool Reminder { get; set; }
        public static int Offset { get; set; }

        internal static void RepairCalendar()
        {
            LoadCalender();
            SetEndDate();
            if (Reminder) SetAlarms();
            WriteCalendar();
            Finished();
        }

        internal static void LoadCalender()
        {
            GetFileName();
            ReadCalendar();
        }

        private static void Finished()
        {
            MessageBox.Show($"Die Datei {GetNewFilename()} wurde gespeichert.");
        }

        private static void SetEndDate()
        {
            if (calendar == null) return;
            foreach (var item in calendar.Events)
            {
                if (item.Start.Equals(item.End))
                    item.End = item.End.AddDays(1);
            }
        }

        private static void SetAlarms()
        {
            if (calendar == null) return;
            foreach (var item in calendar.Events)
            {
                if (item.Alarms.Count == 0)
                {
                    Alarm alarm = new Alarm();
                    Trigger trigger = new Trigger();
                    trigger.Duration = new TimeSpan(Offset, 0, 0);
                    alarm.Trigger = trigger;
                    alarm.Action = "DISPLAY";
                    item.Alarms.Add(alarm);
                }

            }
        }
        private static void WriteCalendar()
        {
            Ical.Net.Serialization.CalendarSerializer calendarSerializer = new Ical.Net.Serialization.CalendarSerializer(calendar);
            string temp = calendarSerializer.SerializeToString();
            if (!File.Exists(GetNewFilename()))
                File.WriteAllText(GetNewFilename(), temp);
            else
            {
                if (MessageBox.Show($"Achtung, die Zieldatei {GetNewFilename()} existiert bereits. Soll sie überschrieben werden?", "Datei überschreiben?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    File.WriteAllText(GetNewFilename(), temp);
            }
        }

        private static string GetNewFilename()
        {
            string fileNameNew = calenderFile.Remove(calenderFile.LastIndexOf('.'));
            fileNameNew += "_kor.ics";
            return fileNameNew;
        }

        private static void ReadCalendar()
        {
            if (calenderFile == String.Empty) return;
            string events = File.ReadAllText(calenderFile);
            calendar = Calendar.Load(events);
        }

        private static void GetFileName()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Bitte ics-Datei auswählen";
                ofd.Filter = "*.ics|*.ics";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    calenderFile = ofd.FileName;
                }
            }
        }

    }
}
