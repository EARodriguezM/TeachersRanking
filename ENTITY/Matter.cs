using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class Matter
    {
        public Matter()
        {
            Career = new HashSet<Career>();
            Teacher = new HashSet<Teacher>();
            Review = new HashSet<Review>();
        }

        public string MatterId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Career> Career { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
