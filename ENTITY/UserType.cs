using System;
using System.Collections.Generic;

namespace ENTITY
{
    public partial class UserType
    {
        public UserType()
        {
            CommonUser = new HashSet<CommonUser>();
        }

        public char UserTypeId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<CommonUser> CommonUser { get; set; }
    }
}
