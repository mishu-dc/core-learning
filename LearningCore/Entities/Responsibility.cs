using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Entities
{
    public class Responsibility
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Experience Experience { get; set; }
        public int ExperienceId { get; set; }
        public int Serial { get; set; }
    }
}
