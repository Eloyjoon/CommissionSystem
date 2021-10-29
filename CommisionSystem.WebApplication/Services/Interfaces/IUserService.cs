using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommisionSystem.WebApplication.Data;
using CommisionSystem.WebApplication.Models.ViewModels;

namespace CommisionSystem.WebApplication.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<ReadUserModel>> ListOfUsers();
        Task<User> GetUser(string username, string password);
        Task CreateUser(CreateUserModel input);
        Task<IEnumerable<Role>> ListOfRoles();
        Task ChangeStatus(int userID,bool enabled);
    }
}
