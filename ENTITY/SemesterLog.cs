using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class SemesterLog
    {
        public SemesterLog()
        {
            Review = new HashSet<Review>();
            Score = new HashSet<Score>();
        }

        public byte SemesterLogId { get; set; }
        public char Semester { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public bool Status { get; set; }

        public virtual RTeacherMatter RTeacherMatter { get; set; }
        public virtual ICollection<Score> Score{ get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
