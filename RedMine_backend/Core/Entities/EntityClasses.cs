using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedMine_backend.Core.Entities
{
    public class Managers
    {
        [Key]
        public int ID { get; set; }
        public Tasks Tasks { get; set; }    
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //Javítani kell majd hashelni kell!!
        public string Password { get; set; }
    }

    public class Developers
    {
        [Key]
        public int ID { get; set; }
        public ProjectDevelopers ProjectDevelopers { get; set; }
        public string Name { set; get; }
        [EmailAddress]
        public string Email { get; set; }
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
        public Tasks Tasks { get; set; }
        public string Name { set; get; }
        [ForeignKey("ProjectTypes")]
        public int TypeID { get; set; }
        public ProjectTypes ProjectTypes { get; set; }
        public string Description { get; set; }
    }

    public class ProjectDevelopers
    {
        public int ID { get; set; }
        [ForeignKey("Developers")]
        public int DeveloperID { get; set; }
        public Developers Developers { get; set; }
        [ForeignKey("Projects")]
        public int ProjectID { get; set; }
        public Projects Projects { get; set; }
    }

    public class ProjectTypes
    {
        [Key]
        public int ID { get; set; }
        public string Name { set; get; }
    }
}
