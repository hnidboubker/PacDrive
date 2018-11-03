using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PacDrive.Web.Domain
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public TKey Creator { get; set; }
        public TKey Updator { get; set; }
    }
}