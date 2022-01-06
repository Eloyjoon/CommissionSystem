using CommissionSystem.Business.Product;
using CommissionSystem.Data;
using CommissionSystem.Data.Sepidar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.Business.User
{
    public class UserService : IUserService
    {
        private readonly CommisionContext commisionContext;
        private readonly SepidarContext sepidarContext;

        public UserService(CommisionContext commisionContext, SepidarContext sepidarContext)
        {
            this.commisionContext = commisionContext;
            this.sepidarContext = sepidarContext;
        }
        public async Task<UserDto> GetUser(string username, string password)
        {
            var result = await commisionContext.Users
                .Include(a => a.Role)
                .Include(a => a.UserPolicies)
                .ThenInclude(a => a.Policy)
                .Select(a => new UserDto(a))
                .FirstOrDefaultAsync(a => a.UserName == username && a.Password == password);

            if (result == null)
                return null;
            else
                return result;
        }
        public async Task<UserDto> GetUser(int userID)
        {
            var result = await commisionContext.Users
                .Include(a => a.Role)
                .Include(a => a.UserPolicies)
                .ThenInclude(a => a.Policy)
                .Select(a => new UserDto(a))
                .FirstOrDefaultAsync(a => a.ID == userID);

            return result;
        }
        public async Task<List<BrandDto>> GetUserBrands(int userID)
        {
            var brandIDs = await commisionContext.UserBrands
                .Where(a => a.UserID == userID)
                .Select(a => a.BrandID)
                .ToListAsync();

            var brands = await sepidarContext.Brands
                .OnlyBrands()
                .Where(a => brandIDs.Contains(a.ID))
                .Select(a => new BrandDto(a))
                .ToListAsync();

            return brands;

        }
        public async Task<List<PolicyDto>> GetUserPolicy(int userID)
        {
            var policies = await commisionContext.UserPolicies
                .Where(a => a.UserID == userID)
                .Select(a => a.Policy)
                .Select(a=>new PolicyDto(a))
                .ToListAsync();

            return policies;
        }
        public async Task<UserDto> Exist(string username)
        {
            var user = await commisionContext.Users
                .Include(a => a.Role)
                .Include(a => a.UserPolicies)
                .ThenInclude(a => a.Policy)
                .Select(a=>new UserDto(a))
                .FirstOrDefaultAsync(a => a.UserName == username);

            return user;
        }
        public async Task<List<UserDto>> ListOfUsers()
        {
            var result = await commisionContext.Users
                .Include(a => a.Role)
                .Select(a=>new UserDto(a))
                .ToListAsync();

            return result;
        }
        public async Task<IEnumerable<PolicyDto>> ListOfPolicies()
        {
            var result = await commisionContext.Policies
                .Select(a=>new PolicyDto(a))
                .ToListAsync();

            return result;
        }
        public async Task CreateUser(UserDto input, List<int> policyIDs, List<int> brandIDs)
        {
            try
            {
                Data.User user = new Data.User()
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    UserName = input.UserName,
                    Password = input.Password,
                    RoleID = input.Role.ID,
                    Status = true
                };

                await commisionContext.Users.AddAsync(user);

                if (policyIDs != null)
                {
                    foreach (var policy in policyIDs)
                    {
                        UserPolicy userPolicy = new UserPolicy()
                        {
                            PolicyID = policy,
                            User = user
                        };

                        await commisionContext.UserPolicies.AddAsync(userPolicy);
                    }
                }

                if (brandIDs != null)
                {
                    foreach (var brand in brandIDs)
                    {
                        UserBrand userBrand = new UserBrand()
                        {
                            BrandID = brand,
                            User = user
                        };

                        await commisionContext.UserBrands.AddAsync(userBrand);
                    }
                }

                await commisionContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<IEnumerable<RoleDto>> ListOfRoles()
        {
            var result = await commisionContext.Roles
                .Select(a=>new RoleDto(a))
                .ToListAsync();

            return result;
        }
        public async Task ChangeStatus(int userID, bool enabled)
        {
            commisionContext.Users.First(a => a.ID == userID).Status = enabled;
            commisionContext.SaveChanges();
        }
        public async Task SyncUsers()
        {
            //using (var context = new PrincipalContext(ContextType.Domain, "hurmengroup.local"))
            //{
            //    using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
            //    {
            //        foreach (var result in searcher.FindAll())
            //        {
            //            DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
            //            if (de.Properties["givenName"].Value == null || de.Properties["sn"].Value == null || de.Properties["samAccountName"].Value == null)
            //                continue;
            //            var uName = de.Properties["samAccountName"].Value.ToString();
            //            if (commisionContext.Users.Any(a => a.UserName == uName))
            //                continue;

            //            User user = new User()
            //            {
            //                FirstName = de.Properties["givenName"].Value.ToString(),
            //                LastName = de.Properties["sn"].Value.ToString(),
            //                HasAccessToProductSearchReport = false,
            //                HasAccessToQuote = true,
            //                Password = "123",
            //                RoleID = 3,
            //                Status = false,
            //                UserName = de.Properties["samAccountName"].Value.ToString()
            //            };



            //            commisionContext.Users.Add(user);
            //            commisionContext.SaveChanges();
            //        }
            //    }
            //}
            //return null;
        }
        public async Task EditUser(UserDto input, List<int> brandIDs, List<int> policyIDs)
        {
            var user = commisionContext.Users
                .First(a => a.ID == input.ID);
            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.Password = input.Password;
            user.RoleID = input.Role.ID;
            commisionContext.Entry(user).State = EntityState.Modified;
            commisionContext.SaveChanges();

            var dbBrands = commisionContext.UserBrands.Where(a => a.UserID == user.ID).ToList();
            foreach (var item in dbBrands)
            {
                if (!brandIDs.Contains(item.BrandID))
                    commisionContext.Entry(item).State = EntityState.Deleted;
            }

            var dbPolicies = commisionContext.UserPolicies.Where(a => a.UserID == user.ID).ToList();
            foreach (var item in dbPolicies)
            {
                if (!policyIDs.Contains(item.PolicyID))
                    commisionContext.Entry(item).State = EntityState.Deleted;
            }

            foreach (var item in brandIDs)
            {
                if (!commisionContext.UserBrands.Any(a => a.UserID == user.ID && a.BrandID == item))
                {
                    UserBrand userBrand = new UserBrand()
                    {
                        BrandID = item,
                        UserID = user.ID
                    };

                    commisionContext.Add(userBrand);

                }
            }

            foreach (var item in policyIDs)
            {
                if (!commisionContext.UserPolicies.Any(a => a.UserID == user.ID && a.PolicyID == item))
                {
                    UserPolicy userPolicy = new UserPolicy()
                    {
                        PolicyID = item,
                        UserID = user.ID
                    };

                    commisionContext.Add(userPolicy);

                }
            }

            commisionContext.SaveChanges();
        }
    }
}
