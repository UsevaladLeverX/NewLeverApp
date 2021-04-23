using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace NewLeverApp.Models
{
    public partial class Level
    {
        public Level()
        {
            Mentees = new HashSet<Mentee>();
        }

        public int LevelId { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Mentee> Mentees { get; set; }
    }
}
