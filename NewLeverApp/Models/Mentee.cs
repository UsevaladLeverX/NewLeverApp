using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NewLeverApp.Models
{
    public partial class Mentee
    {
        public int MenteeId { get; set; }
        public int? LevelId { get; set; }
        public string MenteeName { get; set; }
        public int Age { get; set; }

        public virtual Level Level { get; set; }
    }
}
