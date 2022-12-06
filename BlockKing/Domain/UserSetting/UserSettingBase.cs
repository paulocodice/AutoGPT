using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockKing.Data.Domain;

namespace BlockKing.Data.Domain.UserSetting
{
    /// <summary>
    /// Abstract class for settings that are coupled to an user.
    /// </summary>
    public abstract class UserSettingBase
    {
        /// <summary>
        /// User the setting is assigned to
        /// </summary>
        public User? User { get; private set; }

        /// <summary>
        /// Assign this UserSetting to the user passed in the parameter
        /// </summary>
        /// <param name="user">User to assign the usersetting to</param>
        internal void SetUser(User user)
        {
            User = user;
        }
    }
}
