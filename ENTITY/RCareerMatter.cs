using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class RCareerMatter
    {
        public string CareerId { get; set; }
        public string MatterId { get; set; }
        public bool Status { get; set; }

        public virtual Career Career { get; set; }
        public virtual Matter Matter { get; set; }
    }
}
