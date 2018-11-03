using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PacDrive.Web.Domain;

namespace PacDrive.Web.Entities
{
    public class Role : Entity<long>
    {
        public string Name { get; set; }
        public virtual ICollection<UserRole> Users { get; set; }
    }
}