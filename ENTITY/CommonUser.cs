using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class CommonUser
    {
        public CommonUser()
        {
            Review = new HashSet<Review>();
        }

        public int CommonUserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public bool IsRegistered { get; set; }
        public char UserType { get; set; }

        public virtual UserType UserTypeNavigation { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
