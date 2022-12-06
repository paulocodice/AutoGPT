using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockKing.Data.Domain.UserSetting
{

    public class SubjectSetting : UserSettingBase, IDbEntity
    {
        public int Id { get; private set; }
        public List<Subject> Subjects { get; private set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SubjectSetting()
        {
            Subjects = new();
        }

        /// <summary>
        /// Add given subject to the subject settings
        /// </summary>
        /// <param name="subject">subject to add</param>
        public void AddSubject(Subject subject)
        {
            subject.SetSubjectSetting(this);
            Subjects.Add(subject);
        }

        /// <summary>
        /// Remove given subject from the subject settings
        /// </summary>
        /// <param name="subject">subject to remove</param>
        public bool RemoveSubject(Subject subject)
        {
            return Subjects.Remove(subject);
        }
    }
}
