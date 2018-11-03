using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PacDrive.Web.Entities
{
    public class UserClaim
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string ClaimValue { get; set; }
        public string ClaimType { get; set; }
    }
}