using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommisionSystem.WebApplication.Data;
using CommisionSystem.WebApplication.Models.ViewModels;
using CommisionSystem.WebApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommisionSystem.WebApplication.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly CommisionContext commisionContext;

        public UserService(CommisionContext commisionContext)
        {
            this.commisionContext = commisionContext;
        }
        public async Task<User> GetUser(string username, string password)
        {
            return await commisionContext.Users
                .Include(a=>a.Role)
                .ThenInclude(a=>a.RolePolicies)
                .FirstOrDefaultAsync(a => a.UserName == username && a.Password == password);
        }
        public async Task<List<ReadUserModel>> ListOfUsers()
        {
            var result =await commisionContext.Users
                .Where(a=>a.Role.AccessLevel<4)//Less than Super Admin
                .Include(a => a.Role)
                .ThenInclude(a => a.RolePolicies)
                .ToListAsync();

            return result.Select(a=>a.ToReadUserModel()).ToList();
        }

        public async Task<List<ReadPolicyModel>> ListOfPolicies()
        {
            var result = await commisionContext.Policies
                .ToListAsync();

            return result
                .Select(a => new ReadPolicyModel() 
                    { 
                        PolicyID=a.ID,
                        Title=a.DisplayName
                    }
                ).ToList();
        }
        public async Task CreateUser(CreateUserModel input)
        {
            try
            {
                Data.User user = new Data.User()
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    UserName = input.UserName,
                    Password = input.Password,
                    RoleID = input.RoleID,
                    Status=true
                };

                await commisionContext.Users.AddAsync(user);

               await  commisionContext.SaveChangesAsync();
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        public async Task<IEnumerable<Role>> ListOfRoles()
        {
            var result = commisionContext.Roles.Where(a => !a.RoleName.ToLower().Contains("super")).AsEnumerable();
            return result;
        }
        public async Task ChangeStatus(int userID,bool enabled)
        {
            commisionContext.Users.First(a => !a.Role.RoleName.ToLower().Contains("super") && a.ID == userID).Status=enabled;
            commisionContext.SaveChanges();
        }
    }
}
