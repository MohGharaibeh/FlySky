using System;
using System.Collections.Generic;

namespace FlySky.Core.Data
{
    public partial class Contact
    {
        public decimal Contactid { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }
        public string? Image { get; set; }
        public string? Subject { get; set; }
        public DateTime? Senddate { get; set; }
    }
}
