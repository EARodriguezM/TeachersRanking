using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class Career
    {
        public Career()
        {
            Matter = new HashSet<Matter>();
        }

        public string CareerId { get; set; }
        public string Name { get; set; }
        public byte FacultyId { get; set; }
        public bool Status { get; set; }
        
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Matter> Matter { get; set; }
    }
}
