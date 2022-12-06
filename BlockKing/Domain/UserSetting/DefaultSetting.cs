using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static BlockKing.Data.Domain.UserSetting.WeekSetting;

namespace BlockKing.Data.Domain.UserSetting
{
    public static class DefaultSetting //TODO get these settings from config
    {
        //UserBlockSetting
        public static readonly int BlockTime = 20
                                  ,BlockMargin = 5
                                  ,ShortBreakTime = 5
                                  ,LongBreakTime = 10
                                  ,LongBreakinterval = 4;

        //WeekSetting
        public static readonly FirstDay PreferredFirstDay = FirstDay.Local;
        public static readonly bool SlidingWeekMode = false;
        public static readonly TimeSpan EveryDayAvailableTime = TimeSpan.FromHours(3);
        public static readonly CultureInfo CultureInfo = CultureInfo.CurrentCulture ?? new("en-US");
    }
}