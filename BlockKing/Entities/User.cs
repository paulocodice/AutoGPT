using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlockKing.Data.Entities
{
    public class User
    {
        /// <summary>
        /// List of settings belonging to the user. Basetype is Usersettings, every setting needs an user te be set.
        /// </summary>
        public IEnumerable<UserSetting> Settings { get; private set; }

        public User() : this(new List<UserSetting>()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public User(IEnumerable<UserSetting> settings)
        {
            Settings = settings;

            // Add all given UserSettings to the Settings parameter
            foreach (var setting in settings)
            {
                setting.SetUser(this);
                Settings = Settings.Append(setting).Where(t => t.GetType().);
            }

            // Create an instance of the missing UserSettings
            CreateMissingUserSettings();
        }

        public void CreateMissingUserSettings()
        {
            // Get a list of subclasses of the Usersettings
            List<UserSetting> UsersettingsList = new();
            foreach (Type type in Assembly.GetAssembly(typeof(UserSetting)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(UserSetting))))
            {
                UsersettingsList.Add((UserSetting)Activator.CreateInstance(type));
            }

            // Add the missing UserSettings to the Settings property of the user
            foreach (var setting in UsersettingsList.Except(Settings))
            {
                setting.SetUser(this);
                Settings = Settings.Append(setting);
            }
        }
    }
}
