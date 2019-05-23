using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCore.Entities
{
    public class Profile
    {
        public Profile()
        {
            Projects = new List<Project>();
            Skills = new List<Skill>();
            Experiences = new List<Experience>();
            Educations = new List<Education>();
            Achievements = new List<Achievement>();
            Certifications = new List<Certification>();
            Publications = new List<Publication>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Summary { get; set; }
        public DateTime DOB { get; set; }
        public string LinkedinLink { get; set; }
        public string FaceBookLink { get; set; }
        public string GitHubLink { get; set; }
        public string LeetCodeLink { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Project> Projects { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Education> Educations { get; set; }
        public List<Achievement> Achievements { get; set; }
        public List<Certification> Certifications { get; set; }
        public List<Publication> Publications { get; set; }
    }
}
