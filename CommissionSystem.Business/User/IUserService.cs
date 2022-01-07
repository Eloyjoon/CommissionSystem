using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommissionSystem.Business.Product;
using CommissionSystem.Data;
using CommissionSystem.Data.Sepidar;

namespace CommissionSystem.Business.User
{
    public interface IUserService
    {
        Task<List<UserDto>> ListOfUsers();
        Task<IEnumerable<PolicyDto>> ListOfPolicies();
        Task<UserDto> GetUser(string username, string password);
        Task<UserDto> GetUser(int userID);
        Task<List<BrandDto>> GetUserBrands(int userID);
        Task<List<PolicyDto>> GetUserPolicy(int userID);
        Task<UserDto> Exist(string username);
        Task CreateUser(CreateUserModel input, List<int> policyIDs, List<int> brandIDs);
        Task EditUser(EditUserModel input, List<int> brands, List<int> policies);
        Task<IEnumerable<RoleDto>> ListOfRoles();
        Task ChangeStatus(int userID, bool enabled);
        Task SyncUsers();
    }
}
