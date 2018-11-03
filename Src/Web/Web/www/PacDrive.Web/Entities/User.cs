using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PacDrive.Web.Domain;

namespace PacDrive.Web.Entities
{
    public class User : Entity<long>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumbedConfirmed { get; set; }
        public virtual ICollection<UserLogin> Logins { get; set; }
        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }

    }
}