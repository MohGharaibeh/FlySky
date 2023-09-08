using System;
using System.Collections.Generic;

namespace FlySky.Core.Data
{
    public partial class Useracount
    {
        public Useracount()
        {
            Reservedflights = new HashSet<Reservedflight>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal Useracountid { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Image { get; set; }
        public DateTime? Birthdate { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Reservedflight> Reservedflights { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
