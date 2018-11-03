using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PacDrive.Web.Entities
{
    public class UserLogin
    {
        public long UserId { get; set; }
        public string ProviderKey { get; set; }
        public string LoginProvider { get; set; }
    }
}