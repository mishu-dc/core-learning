using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Entities
{
    public class Education
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string UniversityName { get; set; }
        public string UniversityLink { get; set; }
        public int? PassingYear { get; set; }
        public string UniversityAddress { get; set; }
        public int Serial { get; set; }
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
    }
}
