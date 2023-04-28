using BlockKing.Data.Domain.UserSetting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlockKing.Data.Domain
{
    /// <summary>
    /// Day is used as a holder for blocks on an specific date. It contains all planningblocks with a duedate of that d
    /// </summary>
    
    public partial class Day : IDbEntity //TODO only initializable via an user
    {
        public int Id { get; private set; }
        public User User { get; private set; }
        public DateOnly Date { get; private set; }
        public int AvailableTime { get; private set; }
        public SortedList<int, Block> Planning { get; private set; }
        public SortedList<int, Block> Work { get; private set; }

        public string Name { get => Date.ToString("dddd", User.WeekSetting.CultureInfo ?? new("en-US")); }
        public double DaysFromNow { get => (Date.ToDateTime(TimeOnly.MinValue) - DateTime.Now).TotalDays; }
        public DayOfWeek DayOfWeek { get => Date.DayOfWeek; }
        public int WeekNumber { get => GetWeek(); }

        public Day() 
        {
        }
        
        public Day(DateOnly date, User user)
        {
            Date = date;
            User = user;
        }

        /// <summary>
        /// Returns the first day of the week and the weeknumber according to users preferred first day of week
        /// </summary>

        private int GetWeek()
        {
            CultureInfo UserCulture = User.WeekSetting.PreferredFirstDay switch
            {
                WeekSetting.FirstDay.Sunday => new("en-US"),
                WeekSetting.FirstDay.Monday => new("en-GB"),
                _ => User.WeekSetting.CultureInfo ?? new("en-US"),
            };

            var Cal = UserCulture.Calendar;
            var CalWR = UserCulture.DateTimeFormat.CalendarWeekRule;
            var FirstWeekDay = UserCulture.DateTimeFormat.FirstDayOfWeek;

            return Cal.GetWeekOfYear(Date.ToDateTime(TimeOnly.MinValue), CalWR, FirstWeekDay);
        }
    }
}