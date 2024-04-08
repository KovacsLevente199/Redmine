using DataBaseManager.DataBaseManager;
using Microsoft.EntityFrameworkCore;
using RedMine_backend.Core.DataBase;
using System.Text.Json;
using System.Xml;

namespace RedMine_backend.Core.Services
{
    public class DataBaseOperations
    {
        public List<ProjectsDto> QueryByProject()
        {
            try
            {
                using (var context = new RedmineContext())
                {

                   var result = context.Projects
                        .Select(item => new ProjectsDto
                        {
                            Name = item.Name
                        })
                        .ToList();

                    return result;
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
                using (var context = new RedmineContext())
                {
                    var result = from a in context.Projects
                                 join b in context.Tasks on a.ID equals b.ProjectID
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

        public string DtoToJSON(List<ProjectsDto> Dto)
        {
            return JsonSerializer.Serialize(Dto);
        }
    }
}
