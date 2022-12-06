using BlockKing.Data.Domain.UserSetting;
using Wacton.Unicolour;

namespace BlockKing.Data.Domain
{
    public class Subject : IDbEntity
    {
        public int Id { get; private set; }
        public SubjectSetting? SubjectSetting { get; private set; }
        public string Description { get; private set; }
        public Unicolour Color { get; private set; }

        /// <summary>
        /// Create an empty subject
        /// </summary>
        public Subject() : this("", ColorHelper.RandomColor(), new SubjectSetting())
        {
        }

        /// <summary>
        /// Create a subject for the given subjectSetting
        /// </summary>
        /// <param name="subjectSetting"></param>
        public Subject(SubjectSetting subjectSetting) : this("", ColorHelper.RandomColor(), subjectSetting)
        {
            SubjectSetting = subjectSetting;
        }


        public Subject(string description, Unicolour color, SubjectSetting subjectSetting)
        {
            SetDescription(description);
            SetColor(color);
            SetSubjectSetting(subjectSetting);
        }

        /// <summary>
        /// Set subject description to given string
        /// </summary>
        /// <param name="description">Description of subject</param>
        public void SetDescription(string description)
        {
            Description = description;
        }

        /// <summary>
        /// Set subject Unicolour to given Unicolour
        /// </summary>
        /// <param name="Unicolour">Unicolour of subject</param>
        public void SetColor(Unicolour color)
        {
            Color = color;
        }

        /// <summary>
        /// Assign Subject to specific userSubjectSetting
        /// </summary>
        /// <param name="userSubjectSetting"></param>
        internal void SetSubjectSetting(SubjectSetting subjectSetting)
        {
            SubjectSetting = subjectSetting;
        }


    }
}

