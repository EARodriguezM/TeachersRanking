using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class Score
    {
        public int ScoreId { get; set; }
        public byte TeacherId { get; set; }
        public byte SemesterId { get; set; }
        public decimal Knowledge { get; set; }
        public decimal Methodology { get; set; }
        public decimal Naturalness { get; set; }
        public decimal Attitude { get; set; }
        public decimal MotivationProduce { get; set; }
        public decimal MatterGuidelines { get; set; }
        public decimal FinalScore { get; set; }

        public virtual SemesterLog Semester { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
