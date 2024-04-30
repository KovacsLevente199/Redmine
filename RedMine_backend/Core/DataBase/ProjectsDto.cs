using System.ComponentModel.DataAnnotations;

namespace RedMine_backend.Core.DataBase
{
    public class ProjectsDto
    {
        public int ID { get; set; }
        public string Name { set; get; }
        public int TypeID { get; set; }
        public string TypeName { set; get; }
        public string Description { get; set; }
    }

    public class ProjectTypeDto
    {
        public int ID { get; set; }
        public string Name { set; get; }
    }
    
    public class ProjectNameDto
    {
        public int ProjectID { get; set; }
    }
    public class ProjectType
    {
        public int TypeOfProject { get; set; }
    }

    public class ProjectParametersDto
    {
        public string Name { set; get; }
        public DateTime Deadline { set; get; }
        public int ProjectID { set; get; }
        public string Description { set; get; }
        public int DeveloperID { set; get; }
        public int UserID { set; get; }
    }
}
