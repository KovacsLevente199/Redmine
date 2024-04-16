using System.ComponentModel.DataAnnotations;

namespace RedMine_backend.Core.DataBase
{
    public class TasksDto
    {
        public int ID { get; set; }
        public string Name { set; get; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public DateTime DeadLine { get; set; }
    }

    public class TasksParamDto
    {
        public int UserID { get; set;} 
    }
}
