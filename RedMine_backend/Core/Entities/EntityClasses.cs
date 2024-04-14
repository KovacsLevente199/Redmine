using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedMine_backend.Core.Entities
{
    public class Managers
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();

    }

    public class Developers
    {
        [Key]
        public int ID { get; set; }
        public ProjectDevelopers ProjectDevelopers { get; set; }
        public string Name { set; get; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { set; get; }
    }

    public class Tasks
    {
        [Key]
        public int ID { get; set; }
        public string Name { set; get; }
        public string Description { get; set; }
        [ForeignKey("Projects")]
        public int ProjectID { get; set; }
        public Projects Projects { get; set; }  
        [ForeignKey("Managers")]
        public int UserID { get; set; }
        public Managers Managers { get; set; }
        public DateTime DeadLine { get; set; }
    }

    public class Projects
    {
        
        [Key]
        public int ID { get; set; }
        [ForeignKey("ProjectDevelopers")]
        public ProjectDevelopers ProjectDevelopers { get; set; }

        public string Name { set; get; }
        [ForeignKey("ProjectTypes")]
        public int TypeID { get; set; }
        public ProjectTypes ProjectTypes { get; set; }
        public string Description { get; set; }

        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }

    public class ProjectDevelopers
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Developers")]
        public int DeveloperID { get; set; }
        public ICollection<Developers> Developers { get; set; } = new List<Developers>();
        [ForeignKey("Projects")]
        public int ProjectID { get; set; }
        public Projects Projects { get; set; }

    }

    public class ProjectTypes
    {
        [Key]
        public int ID { get; set; }
        public string Name { set; get; }
        public ICollection<Projects> Projects { get; set; } = new List<Projects>();
    }
}
