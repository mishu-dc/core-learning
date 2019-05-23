using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DemoLink { get; set; }
        public string GitHubLink { get; set; }
        public int Serial { get; set; }
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
    }
}
