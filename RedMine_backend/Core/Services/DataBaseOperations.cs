using DataBaseManager.DataBaseManager;
using RedMine_backend.Core.DataBase;

namespace RedMine_backend.Core.Services
{
    public class DataBaseOperations
    {
        public async Task<IResult> QueryEveryData()
        {
            try
            {
                using (var querry = new RedmineContext())
                {
                    foreach (var item in querry.)
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
