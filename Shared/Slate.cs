using System;
using System.Collections.Generic;

namespace SportsSimulator.Shared.Models
{
    public partial class Slate
    {
        public int SlateId { get; set; }
        public string Site { get; set; } = null!;
        public string Sport { get; set; } = null!;
        public string SlateTitle { get; set; } = null!;
        public DateTime SlateStart { get; set; }
    }
}
