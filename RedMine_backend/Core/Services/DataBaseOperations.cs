using DataBaseManager.DataBaseManager;
using Microsoft.EntityFrameworkCore;
using RedMine_backend.Core.DataBase;
using System.Text.Json;
using System.Xml;
using RedMine_backend.Core.Entities;

namespace RedMine_backend.Core.Services
{
    public class DataBaseOperations
    {
        public List<ProjectsDto> QueryInitialProject()
        {
            try
            {
                using (var context = new RedmineContext())
                {

                    var query = from ProjectObj in context.Projects
                                join TypeObj in context.ProjectTypes on ProjectObj.TypeID equals TypeObj.ID
                                select new ProjectsDto
                                {
                                    ID = ProjectObj.ID,
                                    Name = ProjectObj.Name,
                                    Description = ProjectObj.Description,
                                    TypeName = TypeObj.Name,
                                };

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Failed to load initial data");
                throw; 
            }
        }

        public List<TasksDto> QueryByAssigned(string ProjectName)
        {
            try
            {
                Console.WriteLine(ProjectName);
                using (var context = new RedmineContext())
                {
                    var result = from a in context.Projects
                                 join b in context.Tasks on a.ID equals b.ProjectID
                                 where a.Name == ProjectName
                                 select new TasksDto
                                 {
                                     Name = b.Name,
                                 };
                    return result.ToList<TasksDto>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Failed to load initial data");
                throw; 
            }
        }

        public List<ProjectsDto>FilterByType(string ProjType) {
            try
            {
                using (var context = new RedmineContext())
                {
                    var result = from a in context.Projects
                                 join TypeObj in context.ProjectTypes on a.TypeID equals TypeObj.ID
                                 where TypeObj.Name == ProjType
                                 select new ProjectsDto
                                 {
                                     ID = a.ID,
                                     Name = a.Name,
                                     Description = a.Description,
                                     TypeName = TypeObj.Name
                                 };
                    return result.ToList<ProjectsDto>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Failed to load initial data");
                throw;
            }
        }

        public void AddToDatabase(ProjectsDto NewDataBase) 
        {
            try
            {
                using (var context = new RedmineContext())
                {
                    Projects record = new Projects();
                    record.ID = NewDataBase.ID;
                    record.Name = NewDataBase.Name;
                    record.Description = NewDataBase.Description;
                    record.TypeID = NewDataBase.TypeID;
                    context.Projects.Add(record);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Failed to load initial data");
                throw;
            }
        }

        public  List<Developers> QueryUserByLogin(UserDataDto loginData)
        {
            try
            {
                using (var context = new RedmineContext())
                {

                    var query = from user in context.Developers
                                where (loginData.UserName == user.Name) && (loginData.Password == user.Password)
                                select new Developers
                                {
                                    ID = user.ID,
                                    Name = user.Name,
                                    Email = user.Email
                                };

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Failed to load initial data");
                throw;
            }
        }
    }
}
