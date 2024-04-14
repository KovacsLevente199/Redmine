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
        public async Task<List<ProjectsDto>> QueryInitialProject()
        {
            try
            {
                using (var context = new RedmineContext())
                {

                    var result = from ProjectObj in context.Projects
                                join TypeObj in context.ProjectTypes on ProjectObj.TypeID equals TypeObj.ID
                                select new ProjectsDto
                                {
                                    ID = ProjectObj.ID,
                                    Name = ProjectObj.Name,
                                    Description = ProjectObj.Description,
                                    TypeName = TypeObj.Name
                                };

                    return await result.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Failed to load initial data");
                throw; 
            }
        }

        public async Task<List<TasksDto>> QueryByAssigned(int ProjectID)
        {
            try
            {
                using (var context = new RedmineContext())
                {
                    var result = from a in context.Projects
                                 join b in context.Tasks on a.ID equals b.ProjectID
                                 where a.ID == ProjectID
                                 select new TasksDto
                                 {
                                     Name = b.Name,
                                 };
                    return await result.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Failed to load initial data");
                throw; 
            }
        }

        public async Task<List<ProjectsDto>>FilterByType(int ProjType) {
            try
            {
                using (var context = new RedmineContext())
                {
                    var result = from a in context.Projects
                                 join TypeObj in context.ProjectTypes on a.TypeID equals TypeObj.ID
                                 where a.TypeID == ProjType
                                 select new ProjectsDto
                                 {
                                     ID = a.ID,
                                     Name = a.Name,
                                     Description = a.Description,
                                     TypeName = TypeObj.Name
                                 };
                    return await result.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Failed to load initial data");
                throw;
            }
        }

        public async Task<int> AddToDatabase(ProjectParametesDto NewDataBase) 
        {
            if (IsProjectExists(NewDataBase.Name).Result)
            {
                return 1;
            }
            try
            {
                using (var context = new RedmineContext())
                {
                    Projects record = new Projects();
                    record.Name = NewDataBase.Name;
                    record.Description = NewDataBase.Description;
                    record.TypeID = NewDataBase.TypeID;
                    context.Projects.Add(record);
                    await context.SaveChangesAsync(); 
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Failed to load initial data");
                throw;
            }
        }

        public  async Task<int> IsLoginValid(UserDataDto loginData)
        {
            try
            {
                using (var context = new RedmineContext())
                {
                    bool result = await context.Developers.AnyAsync(x => (x.Name == loginData.UserName) && (x.Password == loginData.Password));
                    if(result)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Error from IsProjectExissts");
                throw;
            }
        }

        public async Task<bool> IsProjectExists(string projectName)
        {
            try
            {
                using (var context = new RedmineContext())
                {
                    bool result = await context.Projects.AnyAsync(x => x.Name == projectName);
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "Error from IsProjectExissts");
                throw;
            }
        }
    }
}
