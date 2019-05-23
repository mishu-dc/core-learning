using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Entities
{
    public class Certification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string  IssueingAuthority { get; set; }
        public DateTime CertificationDate { get; set; }
        public int Serial { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
