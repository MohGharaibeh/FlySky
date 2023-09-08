using System;
using System.Collections.Generic;

namespace FlySky.Core.Data
{
    public partial class Role
    {
        public Role()
        {
            Useracounts = new HashSet<Useracount>();
        }

        public decimal Roleid { get; set; }
        public string? Rolename { get; set; }

        public virtual ICollection<Useracount> Useracounts { get; set; }
    }
}
