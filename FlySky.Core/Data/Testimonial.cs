using System;
using System.Collections.Generic;

namespace FlySky.Core.Data
{
    public partial class Testimonial
    {
        public decimal Testimonialid { get; set; }
        public string? Message { get; set; }
        public string? Status { get; set; }
        public decimal? Userid { get; set; }

        public virtual Useracount? User { get; set; }
    }
}
