using System.ComponentModel.DataAnnotations;

namespace RedMine_backend.Core.DataBase
{
    public class DevelopersDto
    {
        public int ID { get; set; }
        public string Name { set; get; }
        public string Email { get; set; }
    }

    public class ProjectDevelopersDto
    {
        public int ID { get; set; }
        public int DeveloperID { get; set; }
        public int ProjectID { get; set; }
    }
}
