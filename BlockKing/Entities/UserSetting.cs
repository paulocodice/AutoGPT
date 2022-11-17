using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockKing.Data.Entities
{
    /// <summary>
    /// Abstract class for settings that are coupled to an user.
    /// </summary>
    public abstract class UserSetting
    {
        /// <summary>
        /// User the setting is coupled to
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Empty constructor for EF, do not use
        /// </summary>
        public UserSetting() : this(new User()) {}

        /// <summary>
        /// Create a UserSetting for the user passed in the argument
        /// </summary>
        /// <param name="user">User to couple the usersetting to</param>
        public UserSetting(User user)
        {
            SetUser(user);
        }

        /// <summary>
        /// Create a UserSetting for the user passed in the argument
        /// </summary>
        /// <param name="user">User to couple the usersetting to</param>
        public void SetUser(User user)
        {
            this.User = user;
        }


        // Overriding the equality comparer so that we can test which type of usersettings are already coupled to an user
        /// <summary>
        /// Compare usersettings by type
        /// </summary>
        public class UserSettingsEqualityComparer : IEqualityComparer<UserSetting>
        {
            public bool Equals(UserSetting x, UserSetting y)
            {
                return x.GetType() == y.GetType();
            }

            public int GetHashCode(UserSetting obj)
            {
                return obj.GetType().GetHashCode();
            }
        }
    }
}
