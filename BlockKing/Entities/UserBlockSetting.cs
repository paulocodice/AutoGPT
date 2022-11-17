namespace BlockKing.Data.Entities
{
    public class UserBlockSetting : UserSetting, IDbEntity
    {
        public int Id { get; private set; }
        public int BlockTime { get; private set; }
        public int BlockMargin { get; private set; }
        public int PauseTime { get; private set; }
        public int PauseMargin { get; private set; }

        public UserBlockSetting() : this(new User()) { }

        public UserBlockSetting(User user) : this(20, 5, 5, 5, user) { }

        public UserBlockSetting(int blockTime, int blockMargin, int pauseTime, int pauseMargin, User user)
        {
            BlockTime = blockTime;
            BlockMargin = blockMargin;
            PauseTime = pauseTime;
            PauseMargin = pauseMargin;
            SetUser(user);
        }

        public void SetBlockTime(int blockTime)
        {
            this.BlockTime = blockTime;
        }

        public void SetBlockMargin(int blockMargin)
        {
            this.BlockMargin = blockMargin;
        }

        public void SetPauseTime(int pauseTime)
        {
            this.PauseTime = pauseTime;
        }

        public void SetPauseMargin(int pauseMargin)
        {
            this.SetPauseMargin(pauseMargin);
        }
    }
}