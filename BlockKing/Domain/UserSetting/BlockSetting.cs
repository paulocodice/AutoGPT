
namespace BlockKing.Data.Domain.UserSetting
{
    public class BlockSetting : UserSettingBase, IDbEntity
    {
        public int Id { get; private set; }
        /// <summary>
        /// Time in minutes of a standard working block
        /// </summary>
        public int BlockTime { get; private set; }
        /// <summary>
        /// Time in minutes for max margin of exceeding BlockTime
        /// </summary>
        public int BlockMargin { get; private set; }
        /// <summary>
        /// Time in minutes of a Short pause between each blocks
        /// </summary>
        public int ShortBreakTime { get; private set; }
        /// <summary>
        /// Time in minutes of a Long pause between multiple blocks
        /// </summary>
        public int LongBreakTime { get; private set; }
        /// <summary>
        /// Nth Number of breaks to be a long break
        /// </summary>
        public int LongBreakInterval { get; private set; }

        /// <summary>
        /// Blocksettings with default values
        /// </summary>
        /// <param name="user"></param>
        public BlockSetting() : this(DefaultSetting.BlockTime
                                      , DefaultSetting.BlockMargin
                                      , DefaultSetting.ShortBreakTime
                                      , DefaultSetting.LongBreakTime
                                      , DefaultSetting.LongBreakinterval)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockTime"></param>
        /// <param name="blockMargin"></param>
        /// <param name="shortBreakTime"></param>
        /// <param name="longBreakTime"></param>
        /// <param name="longBreakinterval"></param>
        public BlockSetting(int blockTime, int blockMargin, int shortBreakTime, int longBreakTime, int longBreakinterval)
        {
            BlockTime = blockTime;
            BlockMargin = blockMargin;
            ShortBreakTime = shortBreakTime;
            LongBreakTime = longBreakTime;
            LongBreakInterval = longBreakinterval;
        }

        /// <summary>
        /// Set BlockTime to given value in minutes
        /// </summary>
        /// <param name="blockTime">Time in minutes of a standard working block</param>
        public void SetBlockTime(int blockTime)
        {
            BlockTime = blockTime;
            //TODO recalc all days / workitems for planning
        }

        /// <summary>
        /// Set BlockMargin to given value in minutes
        /// </summary>
        /// <param name="blockMargin">Time in minutes for max margin of exceeding BlockTime</param>
        public void SetBlockMargin(int blockMargin)
        {
            BlockMargin = blockMargin;
        }

        /// <summary>
        /// Set shortBreakTime to given value in minutes
        /// </summary>
        /// <param name="ShortBreakTime">Time in minutes of a standard pause between working blocks</param>
        public void SetShortBreakTime(int shortBreakTime)
        {
            ShortBreakTime = shortBreakTime;
            //TODO update all short breakblocks for user
        }


        /// <summary>
        /// Set longBreakTime to given value in minutes
        /// </summary>
        /// <param name="longBreakTime">Time in minutes of a standard pause between multiple blocks</param>
        public void SetLongBreakTime(int longBreakTime)
        {
            LongBreakTime = longBreakTime;
            //TODO update all long breakblocks for user
        }

        /// <summary>
        /// Set every Nth break to be a long break
        /// </summary>
        /// <param name="interval"> N </param>
        public void SetLongBreakInterval(int interval)
        {
            LongBreakInterval = interval;
            //TODO Update all break blocks for user
        }
    }
}