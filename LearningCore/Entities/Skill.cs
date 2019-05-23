using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsHighlighted { get; set; }
        public int Serial { get; set; }
        public string Link { get; set; }
        public int? YearsOfExperience { get; set; }
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
    }
}
