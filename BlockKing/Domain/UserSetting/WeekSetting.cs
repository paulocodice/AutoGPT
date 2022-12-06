using System.Globalization;

namespace BlockKing.Data.Domain.UserSetting
{


    public class WeekSetting : UserSettingBase, IDbEntity
    {
        public enum FirstDay { Local = -1, Sunday = 0, Monday = 1}

        public int Id { get; private set; }
        public FirstDay PreferredFirstDay { get; private set; }
        public bool SlidingWeekMode { get; private set; }
        public TimeSpan? EveryDayAvailableTime { get; private set; }
        public List<(DayOfWeek Weekday, TimeSpan AvailableDayTime)>? AvailableTime { get; private set;}
        public CultureInfo CultureInfo { get; private set; }

        /// <summary>
        /// Blocksettings with default values
        /// </summary>
        public WeekSetting() : this( DefaultSetting.PreferredFirstDay
                                    ,DefaultSetting.SlidingWeekMode
                                    ,DefaultSetting.EveryDayAvailableTime
                                    ,DefaultSetting.CultureInfo)
        {
        }

        public WeekSetting(FirstDay preferredFirstDay, bool slidingWeekMode, TimeSpan everyDayAvailableTime, CultureInfo cultureInfo)
        {
            PreferredFirstDay = preferredFirstDay;
            SlidingWeekMode = slidingWeekMode;
            EveryDayAvailableTime = everyDayAvailableTime;
            CultureInfo = cultureInfo;
            AvailableTime = new();
        }
    }
}