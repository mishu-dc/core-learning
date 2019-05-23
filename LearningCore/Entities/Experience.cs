using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Entities
{
    public class Experience
    {
        public Experience()
        {
            Responsibilities = new List<Responsibility>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public string CompanyLink { get; set; }
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
        public List<Responsibility> Responsibilities { get; set; }
    }
}
