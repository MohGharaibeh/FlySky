using System;
using System.Collections.Generic;

namespace FlySky.Core.Data
{
    public partial class Virtualbank
    {
        public decimal Virtualbankid { get; set; }
        public decimal? Balance { get; set; }
        public string? Iban { get; set; }
        public decimal? Cvv { get; set; }
        public string? Exdate { get; set; }
    }
}
