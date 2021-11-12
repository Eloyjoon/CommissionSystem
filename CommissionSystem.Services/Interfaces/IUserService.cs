using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommissionSystem.Data;

namespace CommissionSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<Entities.User>> ListOfUsers();
        Task<IEnumerable<Entities.Policy>> ListOfPolicies();
        Task<Entities.User> GetUser(string username, string password);
        Task<Entities.User> GetUser(int userID);
        Task<List<Entities.Brand>> GetUserBrands(int userID);
        Task<List<Entities.Policy>> GetUserPolicy(int userID);
        Task<Entities.User> Exist(string username);
        Task CreateUser(Entities.User input,List<int> policyIDs,List<int> brandIDs);
        Task EditUser(Entities.User input, List<int> brands, List<int> policies);
        Task<IEnumerable<Entities.Role>> ListOfRoles();
        Task ChangeStatus(int userID, bool enabled);
        Task SyncUsers();
    }
}
