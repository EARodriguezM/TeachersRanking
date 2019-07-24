using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class Teacher
    {
        public Teacher()
        {
            Matter = new HashSet<Matter>();
            Review = new HashSet<Review>();
            Score = new HashSet<Score>();
        }

        public byte TeacherId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public bool IsUpcTeacher { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Matter> Matter { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Score> Score { get; set; }
    }
}
