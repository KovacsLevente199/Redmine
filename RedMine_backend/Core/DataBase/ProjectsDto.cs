﻿using System.ComponentModel.DataAnnotations;

namespace RedMine_backend.Core.DataBase
{
    public class ProjectsDto
    {
        public int ID { get; set; }
        public string Name { set; get; }
        public int TypeID { get; set; }
        public string Description { get; set; }
    }

    public class ProjectTypeDto
    {
        public int ID { get; set; }
        string Name { set; get; }
    }
    
    public class ProjectIDDto
    {
        public int ProjectID { get; set; }
    }
    public class ProjectType
    {
        public int TypeID { get; set; }
    }
}
