using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BlockKing.Data.Domain.UserSetting;


//TODO: make softdelete possible in EF: https://blog.jetbrains.com/dotnet/2021/02/24/entity-framework-core-5-pitfalls-to-avoid-and-ideas-to-try/#Deleting_data

namespace BlockKing.Data.Domain
{
    public class User : IDbEntity 
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Mail { get; private set; }
        public BlockSetting BlockSetting{ get; private set; }
        public SubjectSetting SubjectSetting { get; private set; }
        public WeekSetting WeekSetting { get; private set; }
        public List<Day> Days { get; private set; }

        /// <summary>
        /// Create an empty (unnamed) user with the default settings
        /// </summary>
        public User() : this(null, null) 
        {
        }

        /// <summary>
        /// Create a user with the default settings. If both name and email adress != null it will be a named user. 
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="mail">Email adress of the user</param>
        public User(string? name , string? mail)
        {
            // either both values are set, or both will be null
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(mail))
            {
                Name = null; Mail = null;
            }
            else
            {
                 SetNameAndEmail(name, mail);
            }
           
            SetBlockSetting(new());
            SetSubjectSetting(new());
            SetWeekSetting(new());  

            Days = new List<Day>();
        }

        /// <summary>
        /// Set Blocksettings of this user
        /// </summary>
        /// <param name="blockSetting"></param>
        public void SetBlockSetting(BlockSetting blockSetting)
        {
            BlockSetting = blockSetting;
            BlockSetting.SetUser(this);
        }

        /// <summary>
        /// Set Subjectsettings of this user
        /// </summary>
        /// <param name="subjectSetting"></param>
        public void SetSubjectSetting(SubjectSetting subjectSetting)
        {
            SubjectSetting = subjectSetting;
            SubjectSetting.SetUser(this);
        }

        /// <summary>
        /// Set WeekSetting of this user
        /// </summary>
        /// <param name="weekSetting"></param>
        public void SetWeekSetting(WeekSetting weekSetting)
        {
            WeekSetting = weekSetting;
            WeekSetting.SetUser(this);
        }

        /// <summary>
        /// Set the name and email adress of the user
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <param name="mail">Email adress of the user</param>
        public void SetNameAndEmail(string name, string mail)
        {
            Name = name; 
            Mail = mail;
            //TODO Validate email
        }

        /// <summary>
        /// Add a new day to the user on the given date. If the day already exists it will not be overwritten.
        /// </summary>
        /// <param name="date">DateOnly parameter. Must be equal to- or greater than todays date</param>
        /// <returns>newly added Day if it does not already exist. Otherwise it returns the already existing day</returns>
        public Day AddDay(DateOnly date)
        {
            if (date <= DateOnly.FromDateTime(DateTime.Today))
            {
                throw new ArgumentException($"Must be equal to- or greater than todays date ( {DateOnly.FromDateTime(DateTime.Today)} )", nameof(date));
            }

            if (Days.Exists(x => x.Date == date))
            {
                return Days.Find(x => x.Date == date);
            }
            else
            {
                Day NewDay = new(date, this);
                Days.Add(NewDay);
                return NewDay;
            }
        }
    }   
}