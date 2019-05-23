using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCore.Data;
using LearningCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LearningCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        ApplicationDbContext DbContext;
        public ProfileController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetProfile(string email)
        {
            if (email == null)
            {
                return BadRequest(new { status = "error", message = "Invalid email address" });
            }

            Profile profile = DbContext.Profile
                                .Include(p => p.Achievements)
                                .Include(p => p.Certifications)
                                .Include(p => p.Educations)
                                .Include(p => p.Experiences)
                                .Include(p => p.Projects)
                                .Include(p => p.Publications)
                                .Include(p => p.Skills)
                                .FirstOrDefault(p => p.Email.ToLower().Equals(email.ToLower()));

            if (profile == null)
            {
                return NotFound(new { status = "error", message =string.Format("No profile found with email address: {0}", email) });
            }

            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult> PopulateProfile(string email)
        {
            if (email == null)
            {
                return BadRequest(new { status = "error", message = "Invalid email address" });
            }

            Profile profile = DbContext.Profile
                .FirstOrDefault(p => p.Email.ToLower().Equals(email.ToLower()));

            if (profile != null)
            {
                return BadRequest(new { status = "error", message = string.Format("Profile already exists with email address: {0} ", email) });
            }

            profile = this.Populate(email);

            DbContext.Profile.Add(profile);
            await DbContext.SaveChangesAsync();

            return Ok(new { status = "success" });
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProfile(string email)
        {
            if (email == null)
            {
                return BadRequest(new { status = "error", message = "Invalid email address." });
            }

            Profile profile = DbContext.Profile
                .FirstOrDefault(p => p.Email.ToLower().Equals(email.ToLower()));

            if (profile == null)
            {
                return NotFound(new { status = "error", message = string.Format("No profile found with email address: {0}", email) });
            }

            DbContext.Remove(profile);
            await DbContext.SaveChangesAsync();

            return Ok(new { status = "success" });
        }

        private Profile Populate(string email)
        {
            Profile profile = new Profile();

            profile.Email = email;
            profile.FirstName = "Faisal";
            profile.LastName = "Ahmed";
            profile.Address = "Annandale, VA 22003";
            profile.Designation = "Software Engineer - MCSD: App Builder";
            profile.DOB = Convert.ToDateTime("24-Aug-1983");
            profile.GitHubLink = "https://github.com/mishu-dc";
            profile.LeetCodeLink = "https://leetcode.com/mishu_dc/";
            profile.LinkedinLink = "https://www.linkedin.com/in/faisal-ahmed-se";
            profile.Phone = "+1-57-409-8514";
            profile.Summary = "Full-stack software developer with 12+ years of experience in web development using C#.net, Asp.net MVC , Asp.net Web API, Entity Framework, React and Angular. Web Automation using Selenium WebDriver and Cucumber. My focus of engineering is full-stack development with Back-End in C#, Asp.net MVC, Asp.net Web API and with UI in Javascript, Angular, React etc.";

            profile.Projects.AddRange(this.PopulateProjects());
            profile.Skills.AddRange(this.PopulateSkills());
            profile.Experiences.AddRange(this.PopulateExperiences());
            profile.Educations.AddRange(this.PopulateEducations());
            profile.Achievements.AddRange(this.PopulateAchievements());
            profile.Certifications.AddRange(this.PopulateCertifications());
            profile.Publications.AddRange(this.PopulatePublication());

            return profile;
        }

        private List<Project> PopulateProjects()
        {
            List<Project> projects = new List<Project>();

            Project project = new Project();
            project.Title = "Asp.Net MVC";
            project.Description = "ASP.NET MVC App developed using Asp.net MVC 5,Entity Framework 6, Repository Pattern, Web API 2, Ninject, Log4Net, Bootstrap 3, Gijgo";
            project.GitHubLink = "https://github.com/mishu-dc/BlueBook";
            project.Serial = 1;
            project.DemoLink = "https://mvc.faisalahmed.us/";

            projects.Add(project);

            project = new Project();
            project.Title = "Asp.Net Web API";
            project.Description = "ASP.NET WEB API developed using Asp.net MVC 5,Entity Framework 6, Repository Pattern, Web API 2, Ninject, Log4Net, Bootstrap 3";
            project.GitHubLink = "https://github.com/mishu-dc/BlueBook";
            project.Serial = 2;
            project.DemoLink = "https://webapi.faisalahmed.us/";

            projects.Add(project);

            project = new Project();
            project.Title = "React";
            project.Description = "React App developed using React, React Bootstrap 3.0, React Router and Redux";
            project.GitHubLink = "https://github.com/mishu-dc/react-bluebook";
            project.Serial = 3;
            project.DemoLink = "https://react.faisalahmed.us/";

            projects.Add(project);

            project = new Project();
            project.Title = "Angular";
            project.Description = "Angular App developed using Angular 6 and Bootstrap 4.0";
            project.GitHubLink = "https://github.com/mishu-dc/angular-bluebook";
            project.Serial = 4;
            project.DemoLink = "https://angular.faisalahmed.us/";

            projects.Add(project);

            return projects;
        }

        private List<Skill> PopulateSkills()
        {
            List<Skill> skills = new List<Skill>();
            Skill skill = null;

            string[] skillNames = new string[]
            {
                "C#.net", "Asp.net MVC", "Asp.net Web API","NHibernate", "Entity Framework",
                "Java", "Selenium Webdriver", "HTML", "CSS", "Java Script", "jQuery" , "React" , "Angular",
                "Git", "SVN", "SQL Server", "Oracle", "Visual Studio, VS Code","Agile, Waterfall","Jira, Confluence"
            };

            bool[] isHighlited = new bool[]
            {
                true,true,true,true, true,false,false,false,false,false,false,true,true,true,false,true,false,true,false,false
            };

            int[] yearsOfExperience = new int[]
            {
                10,5,3,4,3,4,4,10,10,5,5,1,1,3,8,8,4,7,4,4
            };

            for (int i = 0; i < skillNames.Length; i++)
            {
                skill = new Skill();
                skill.Description = skillNames[i];
                skill.IsHighlighted = isHighlited[i];
                skill.Serial = i + 1;
                skill.YearsOfExperience = yearsOfExperience[i];

                skills.Add(skill);
            }

            return skills;
        }

        private List<Experience> PopulateExperiences()
        {
            List<Experience> experiences = new List<Experience>();

            experiences.Add(this.GetNeteExperience());
            experiences.Add(this.GetDrFirstExperience());
            experiences.Add(this.GetXpertLabBdExperience());
            experiences.Add(this.GetComputerEaseExperience());

            return experiences;
        }

        private Experience GetNeteExperience()
        {
            Experience exp = new Experience();

            string[] responsibilities = new string[] {
                "Design and develop new features and/or maintain existing applications developed on ASP.NET MVC.",
                "Develop code and supporting documentation.",
                "Analyze business needs, develop requirements, design, develop and test custom software solutions.",
                "Provide technical leadership and take multiple systems and cross system integration into account when designing and developing solutions.",
                "Work with client to understand and implement new requirements."
            };

            exp.CompanyLink = "https://nete.com/";
            exp.CompanyName = "NETE";
            exp.Designation = "Software Engineer - II";
            exp.IsCurrent = true;
            exp.StartDate = Convert.ToDateTime("20-May-2019");

            int serial = 1;
            foreach (string responsibility in responsibilities)
            {
                Responsibility res = new Responsibility();

                res.Description = responsibility;
                res.Serial = serial++;

                exp.Responsibilities.Add(res);
            }

            return exp;
        }

        private Experience GetDrFirstExperience()
        {
            Experience exp = new Experience();

            string[] responsibilities = new string[] {
                "Projects: Electronic Prior Authorization, Patient Real Time Benefit Inquiry, Gaps in Care, Care Cost Estimator etc.",
                "Collaborate with developers, QA, product owner and scrum master to assess requirements, prioritize needs and produce high quality product.",
                "Technology Used: C#.net, Asp.Net MVC, Web API, Entity framework, SQL Server, React Js.",
                "Took the lead role in multiple UATs with Humana, Argus, United Health Group on behalf of DrFirst.",
                "Played the role of an acting application delivery manager for a short period of time.",
                "Participated in the myBenefitCheck project for Humana which was reported in Yahoo Finance in 2015. Details..."
            };

            exp.CompanyLink = "https://www.drfirst.com/";
            exp.CompanyName = "DrFirst";
            exp.Designation = "Software Engineer";
            exp.IsCurrent = false;
            exp.EndDate = Convert.ToDateTime("17-May-2019");
            exp.StartDate = Convert.ToDateTime("23-Dec-2014");

            int serial = 1;
            foreach (string responsibility in responsibilities)
            {
                Responsibility res = new Responsibility();

                res.Description = responsibility;
                res.Serial = serial++;

                exp.Responsibilities.Add(res);
            }

            return exp;
        }

        private Experience GetXpertLabBdExperience()
        {
            Experience exp = new Experience();

            string[] responsibilities = new string[] {
                "Projects: E-Commerce System, Mobile based Order Capturing System, Distribution Management System etc.",
                "Collaborate with developers, QA, product owner and scrum master to assess requirements, prioritize needs and produce high quality product.",
                "Mobile based Order Capturing System helped one renounced pharmaceutical company to double the number of invoices on month opening.",
                "Designing, developing and maintaining applications according to requirements using C#.net, Asp.Net MVC, Web API, SQL Server.",
                "Developed a Payroll Management System as a POC within a week to assist the sales team to provide a demo to a client.",
                "Re-factoring, fixing bugs and performance issues in existing systems."
            };

            exp.CompanyLink = "http://www.xpertlabbd.com/";
            exp.CompanyName = "XpertLab BD Ltd.";
            exp.Designation = "Software Engineer";
            exp.IsCurrent = false;
            exp.EndDate = Convert.ToDateTime("1-Sep-2014");
            exp.StartDate = Convert.ToDateTime("1-Sep-2011");

            int serial = 1;
            foreach (string responsibility in responsibilities)
            {
                Responsibility res = new Responsibility();

                res.Description = responsibility;
                res.Serial = serial++;

                exp.Responsibilities.Add(res);
            }

            return exp;
        }

        private Experience GetComputerEaseExperience()
        {
            Experience exp = new Experience();

            string[] responsibilities = new string[] {
                "Projects: Humane Resource Management, Payroll Management System, Distribution Management System.",
                "Collaborate with developers, QA, product owner and scrum master to assess requirements, prioritize needs and produce high quality product.",
                "Participated in different steps of SDLC.",
                "Designed and developed application based on requirements using C#.net, Asp.Net, SQL Server, SOAP Services, J2ME.",
                "Migrated legacy Visual Basic project To C#.net"
            };

            exp.CompanyLink = "http://www.celimited.com/";
            exp.CompanyName = "Computer Ease Ltd.";
            exp.Designation = "Programmer Analyst";
            exp.IsCurrent = false;
            exp.EndDate = Convert.ToDateTime("1-Mar-2010");
            exp.StartDate = Convert.ToDateTime("1-Sep-2006");

            int serial = 1;
            foreach (string responsibility in responsibilities)
            {
                Responsibility res = new Responsibility();

                res.Description = responsibility;
                res.Serial = serial++;

                exp.Responsibilities.Add(res);
            }

            return exp;
        }

        private List<Education> PopulateEducations()
        {
            List<Education> educations = new List<Education>();

            Education education = null;

            education = new Education();
            education.Degree = "Master of Science in Computer Science & Engineering (MSCSE)";
            education.PassingYear = 2013;
            education.Serial = 1;
            education.UniversityAddress = "Dhaka, Bangladesh";
            education.UniversityLink = "http://www.uiu.ac.bd/";
            education.UniversityName = "United International University.";

            educations.Add(education);

            education = new Education();
            education.Degree = "Bachelor of Science in Computer Science & Engineering (CSE)";
            education.PassingYear = 2006;
            education.Serial = 2;
            education.UniversityAddress = "Dhaka, Bangladesh";
            education.UniversityLink = "http://www.aust.edu/";
            education.UniversityName = "Ahsanullah University of Science and Technology.";

            educations.Add(education);

            return educations;
        }

        private List<Achievement> PopulateAchievements()
        {
            List<Achievement> achievements = new List<Achievement>();
            string[] descriptions = new string[]
            {
                "NINTH PLACE- THE ACM ASIA PROGRAMMING CONTEST - DHAKA SITE SEPTEMBER 23, 2005",
                "FOURTH PLACE- AIUB INTER-UNIVERSITY PROGRAMMING CONTEST AUGUST 06, 2005",
                "FIRST PLACE- INTRA-AUST PROGRAMMING CONTEST MAY 20, 2005"
            };

            Achievement achievement = null;

            for (int i = 0; i < descriptions.Length; i++)
            {
                achievement = new Achievement();

                achievement.Description = descriptions[i];
                achievement.Serial = i + 1;
                achievements.Add(achievement);
            }

            return achievements;
        }

        private List<Certification> PopulateCertifications()
        {
            List<Certification> certifications = new List<Certification>();

            string[] names = new string[] {
                "MCSD: APP BUILDER",
                "MCSA: WEB APPLICATIONS",
                "EXAM 483: PROGRAMMING IN C#",
                "EXAM 486: DEVELOPING ASP.NET MVC WEB APPLICATIONS",
                "EXAM 487: DEVELOPING MICROSOFT AZURE AND WEB SERVICES"
            };

            string[] dates = new string[] {
                "10 Mar 2019",
                "24 Feb 2019",
                "16 Nov 2017",
                "24 Feb 2019",
                "10 March 2019"
            };

            string[] links = new string[] {
                "https://www.youracclaim.com/badges/61da9d43-4037-4853-b469-44a14ccf18ae",
                "https://www.youracclaim.com/badges/19e9f8f0-212d-47ea-a9fd-417771db8408",
                "https://www.youracclaim.com/badges/8002a61e-adcb-439f-b7b0-18cc6c451c13",
                "https://www.youracclaim.com/badges/a5744999-f64b-4a9a-b10b-07d69c7ad3dc",
                "https://www.youracclaim.com/badges/4be776ff-3d09-412b-8669-8bf30bc39e80"
            };

            for (int i = 0; i < names.Length; i++)
            {
                Certification cert = new Certification();

                cert.Title = names[i];
                cert.Serial = i + 1;
                cert.Link = links[i];
                cert.IssueingAuthority = "Microsoft";
                cert.CertificationDate = Convert.ToDateTime(dates[i]);

                certifications.Add(cert);
            }

            return certifications;
        }

        private List<Publication> PopulatePublication()
        {
            List<Publication> publications = new List<Publication>();

            string[] titles = new string[] {
                "Incorporation of dynamic parameters in hybrid feature-based Bangla phoneme recognition using multilayer Neural Networks",
                "Hybrid Features for Neural Network-Based Bangla ASR Incorporrating Velocity Coefficients (?)",
                "Gender Effects Suppression in Bangla ASR by Designing Multiple HMM-Based Classifiers"
            };

            string[] links = new string[] {
                "https://ieeexplore.ieee.org/document/6164883?arnumber=6164883",
                "https://ieeexplore.ieee.org/document/6112900?arnumber=6112900",
                "https://ieeexplore.ieee.org/document/6112895?arnumber=6112895"
            };

            string[] descriptions = new string[] {
                "This paper presents a Neural Network-based Bangla phoneme recognition method for Automatic Speech Recognition (ASR). The method consists of three stages: at first stage, a multilayer neural network (MLN) converts acoustic features, mel frequency cepstral coefficients (MFCCs), into phoneme probabilities, where the second stage computes dynamic (velocity (Δ) and acceleration (ΔΔ)) parameters from the phoneme probabilities by using three point linear regression (LR). Finally, the phoneme probabilities, dynamic parameters, Δ and ΔΔ, and the input MFCCs, combined as hybrid features, are fed into a hidden Markov model (HMM) based classifier to obtain more accurate phoneme strings. From the experiments on Bangla speech corpus prepared by us, it is observed that the proposed method provides higher phoneme recognition performance than the existing method. Moreover, it requires a fewer mixture components in the HMMs.",
                "This paper presents a Neural Network-based Bangla phoneme recognition method for Automatic Speech Recognition (ASR). The method consists of three stages: at first stage, a multilayer neural network (MLN) converts acoustic features, mel frequency cepstral coefficients (MFCCs), into phoneme probabilities, where the second stage computes velocity (Δ) coefficients from the phoneme probabilities by using three point linear regression (LR). Finally, the phoneme probabilities, velocity (Δ) coefficients and the input MFCCs, combined as hybrid features, are fed into a hidden Markov model (HMM) based classifier to obtain more accurate phoneme strings. From the experiments on Bangla speech corpus prepared by us, it is observed that the proposed method provides higher phoneme recognition performance than the existing method. Moreover, it requires a fewer mixture components in the HMMs.",
                "Speaker-specific characteristics play an important role on the performance of Bangla (widely used as Bengali) automatic speech recognition (ASR). It is difficult to recognize speech affected by gender factors, especially when an ASR system contains only a single acoustic model. If there exists any suppression process that represses the decrease of differences in acoustic-likelihood among categories resulted from gender factors, a robust ASR system can be realized. In this paper, we have proposed a technique of gender effects suppression that composed of two hidden Markov model (HMM)-based classifiers and that focused on a gender factor. In an experiment on Bangla speech database prepared by us, the proposed system has provided a significant improvement of word correct rate, word accuracy and sentence correct rate in comparison with the method that incorporates only a single HMM-based classifier for both male and female speakers."
            };

            for (int i = 0; i < titles.Length; i++)
            {
                Publication publication = new Publication();

                publication.Description = descriptions[i];
                publication.Link = links[i];
                publication.Serial = i + 1;
                publication.Title = titles[i];

                publications.Add(publication);
            }

            return publications;
        }
    }
}