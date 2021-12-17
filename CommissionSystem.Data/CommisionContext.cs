using Microsoft.EntityFrameworkCore;

namespace CommissionSystem.Data
{
    public class CommisionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<UserPolicy> UserPolicies { get; set; }
        public DbSet<UserBrand> UserBrands { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteStatus> QuoteStatuses { get; set; }

        public CommisionContext(DbContextOptions<CommisionContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Policies

            modelBuilder.Entity<Policy>().HasData(
                new { ID = 1, Name = "ReadProducts", DisplayName = "Read Products" });

            modelBuilder.Entity<Policy>().HasData(
                new { ID = 2, Name = "ReadBrands", DisplayName = "Read Brands" });

            modelBuilder.Entity<Policy>().HasData(
                new { ID = 3, Name = "ReadUsers", DisplayName = "Read Users" });

            modelBuilder.Entity<Policy>().HasData(
                new { ID = 4, Name = "DisableUserAccount", DisplayName = "Disable User Account" });

            modelBuilder.Entity<Policy>().HasData(
                new { ID = 5, Name = "EnableUserAccount", DisplayName = "Enable User Account" });

            modelBuilder.Entity<Policy>().HasData(
                new { ID = 6, Name = "AddUserAccount", DisplayName = "Add User Account" });

            modelBuilder.Entity<Policy>().HasData(
                new { ID = 7, Name = "Dashboard", DisplayName = "Dashboard" });

            #endregion

            #region Seed Roles

            modelBuilder.Entity<Role>().HasData(
                new { ID = 1, RoleName = "Super Admin", AccessLevel = 30 });


            modelBuilder.Entity<Role>().HasData(
                new { ID = 2, RoleName = "Supervisor", AccessLevel = 20 });

            modelBuilder.Entity<Role>().HasData(
                new { ID = 3, RoleName = "Expert", AccessLevel = 10 });

            #endregion

            #region Seed Users

            modelBuilder.Entity<User>().HasData(
                new { ID = 1, FirstName = "Admin", LastName = "Admin", UserName = "admin", Password = "123", RoleID = 1, HasAccessToProductSearchReport = true, HasAccessToQuote = true, Status = true });

            modelBuilder.Entity<User>().HasData(
                new { ID = 2, FirstName = "Alireza", LastName = "Sabouei", UserName = "ali", Password = "123", RoleID = 3, HasAccessToProductSearchReport = true, HasAccessToQuote = false, Status = true });

            #endregion

            #region Seed User Policies

            modelBuilder.Entity<UserPolicy>().HasData(
                new { ID = 1, UserID = 1, PolicyID = 1 });
            modelBuilder.Entity<UserPolicy>().HasData(
                new { ID = 2, UserID = 1, PolicyID = 2 });
            modelBuilder.Entity<UserPolicy>().HasData(
                new { ID = 3, UserID = 1, PolicyID = 3 });
            modelBuilder.Entity<UserPolicy>().HasData(
                new { ID = 4, UserID = 1, PolicyID = 4 });
            modelBuilder.Entity<UserPolicy>().HasData(
                new { ID = 5, UserID = 1, PolicyID = 5 });
            modelBuilder.Entity<UserPolicy>().HasData(
                new { ID = 6, UserID = 1, PolicyID = 6 });
            modelBuilder.Entity<UserPolicy>().HasData(
                 new { ID = 7, UserID = 1, PolicyID = 7 });

            #endregion

            #region Seed Quote Statuses

            modelBuilder.Entity<QuoteStatus>().HasData(
                new { ID = 1, Name = "Open", Title = "Open" });


            modelBuilder.Entity<QuoteStatus>().HasData(
                new { ID = 2, Name = "Draft", Title = "Draft" });

            modelBuilder.Entity<QuoteStatus>().HasData(
                new { ID = 3, Name = "WaitingToConfirm", Title = "Waiting To Confirm" });

            modelBuilder.Entity<QuoteStatus>().HasData(
                new { ID = 4, Name = "Finalized", Title = "Finalized" });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
