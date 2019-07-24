using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class Faculty
    {
        public Faculty()
        {
            Career = new HashSet<Career>();
        }

        public byte FacultyId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Career> Career { get; set; }
    }
}
