using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee
{
    /// <summary>
    /// A portable moment in time down to the millisecond
    /// </summary>
    public class Instant
    {
        public Instant()
        {
            this.Initialize();
        }

        public Instant(DateTime value)
        {
            this.Initialize(value);
        }

        private void Initialize()
        {
            Initialize(DateTime.UtcNow);
        }

        private void Initialize(DateTime value)
        {
            this.Month = value.Month;
            this.Day = value.Day;
            this.Year = value.Year;
            this.Hour = value.Hour;
            this.Minute = value.Minute;
            this.Second = value.Second;
            this.Millisecond = value.Millisecond;
        }

        public static implicit operator DateTime(Instant instant)
        {
            return instant.ToDateTime();
        }

        public override string ToString()
        {
            return "{Month}/{Day}/{Year};{Hour}.{Minute}.{Second}.{Millisecond}".NamedFormat(this);
        }

        public static Instant FromString(string instantString)
        {
            int month;
            int day;
            int year;
            int hour;
            int minute;
            int second;
            int millisecond;
            Parse(instantString, out month, out day, out year, out hour, out minute, out second, out millisecond);

            return new Instant(new DateTime(year, month, day, hour, minute, second, millisecond));
        }

        private static void Parse(string instantString, out int month, out int day, out int year, out int hour, out int minute, out int second, out int millisecond)
        {
            string[] dateAndTime = instantString.DelimitSplit(";");
            if (dateAndTime.Length != 2)
            {
                Throw();
            }

            string dateString = dateAndTime[0];
            string timeString = dateAndTime[1];
            string[] monthDayYear = dateString.DelimitSplit("/");
            if (monthDayYear.Length != 3)
            {
                Throw();
            }

            string[] hourMinSecMil = timeString.DelimitSplit(".");
            if (hourMinSecMil.Length != 4)
            {
                Throw();
            }

            if (!int.TryParse(monthDayYear[0], out month))
            {
                Throw();
            }

            if (!int.TryParse(monthDayYear[1], out day))
            {
                Throw();
            }

            if (!int.TryParse(monthDayYear[2], out year))
            {
                Throw();
            }

            if (!int.TryParse(hourMinSecMil[0], out hour))
            {
                Throw();
            }

            if (!int.TryParse(hourMinSecMil[1], out minute))
            {
                Throw();
            }

            if (!int.TryParse(hourMinSecMil[2], out second))
            {
                Throw();
            }

            if (!int.TryParse(hourMinSecMil[3], out millisecond))
            {
                Throw();
            }
        }

        private static void Throw()
        {
            throw new ArgumentException("The specified string was not a recognized instant string");
        }

        public int DiffInMinutes(Instant value)
        {
            return DiffInMinutes(value.ToDateTime());
        }

        public int DiffInMinutes(DateTime value)
        {
            return TimeSpan.FromMilliseconds(DiffInMilliseconds(value)).Minutes;
        }

        /// <summary>
        /// Returns the difference between the current instant 
        /// and the specified value in milliseconds
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int DiffInMilliseconds(Instant value)
        {
            return DiffInMilliseconds(value.ToDateTime());
        }
        
        /// <summary>
        /// Returns the difference between the current instant 
        /// and the specified value in milliseconds
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int DiffInMilliseconds(DateTime value)
        {
            int diff = (int)this.ToDateTime().Subtract(value).TotalMilliseconds;
            if (diff < 0)
            {
                diff = diff * -1;
            }

            return diff;
        }

        public int DiffInSeconds(Instant value)
        {
            return DiffInSeconds(value.ToDateTime());
        }

        public int DiffInSeconds(DateTime value)
        {
            int diff = (int)this.ToDateTime().Subtract(value).TotalSeconds;
            if (diff < 0)
            {
                diff = diff * -1;
            }

            return diff;
        }

        public DateTime ToDate()
        {
            return ToDateTime().Date;
        }
        
        public DateTime ToDateTime()
        {
            return new DateTime(this.Year, this.Month, this.Day, this.Hour, this.Minute, this.Second, this.Millisecond);
        }

        public string ToJavascriptDate()
        {
            return "new Date({Year}, {Month}, {Day}, {Hour}, {Minute}, {Second}, {Millisecond});".NamedFormat(this);
        }

        public int Month
        {
            get;
            set;
        }

        public int Day
        {
            get;
            set;
        }

        public int Year
        {
            get;
            set;
        }

        public int Hour
        {
            get;
            set;
        }

        public int Minute
        {
            get;
            set;
        }

        public int Second
        {
            get;
            set;
        }
        public int Millisecond
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj.ToString());
        }
    }
}
