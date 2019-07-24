using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class RTeacherMatter
    {
        public byte TeacherId { get; set; }
        public string MatterId { get; set; }
        public byte SemesterId { get; set; }
        public bool Status { get; set; }

        public virtual Matter Matter { get; set; }
        public virtual SemesterLog Semester { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
