using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public byte TeacherId { get; set; }
        public int CommonUserId { get; set; }
        public string MatterId { get; set; }
        public byte SemesterId { get; set; }
        public string Content { get; set; }
        public byte Knowledge { get; set; }
        public byte Methodology { get; set; }
        public byte Naturalness { get; set; }
        public byte Attitude { get; set; }
        public byte MotivationProduce { get; set; }
        public byte MatterGuidelines { get; set; }
        public decimal WeightedAverage { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsAnonymous { get; set; }
        public bool FailAnyMatter { get; set; }
        public bool Status { get; set; }

        public virtual CommonUser CommonUser { get; set; }
        public virtual Matter Matter { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual SemesterLog Semester { get; set; }
    }
}
