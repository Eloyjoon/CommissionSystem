using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommisionSystem.WebApplication.Data
{
    public class CommisionContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet <Role> Roles { get; set; }
        public DbSet <RolePolicy> RolePolicies { get; set; }
        public DbSet <Policy> Policies { get; set; }
        public DbSet <UserPolicy> UserPolicies { get; set; }

        public CommisionContext(DbContextOptions<CommisionContext> options):base( options)
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
                new { ID = 1,FirstName="Admin",LastName="Admin",UserName="admin",Password="123", RoleID = 1,HasAccessToProductSearchReport=true,HasAccessToQuote=true,Status=true });

            modelBuilder.Entity<User>().HasData(
                new { ID = 2, FirstName = "Alireza", LastName = "Sabouei", UserName = "ali", Password = "123", RoleID = 3, HasAccessToProductSearchReport = true, HasAccessToQuote = false, Status = true });

            #endregion

            #region Seed User Policies

            modelBuilder.Entity<UserPolicy>().HasData(
                new { ID = 1, UserID=1, PolicyID = 1 });
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

            #endregion

            modelBuilder.Entity<RolePolicy>().HasData(
                new { ID = 1, RoleID = 1, Policy = "CreateUser"});


            base.OnModelCreating(modelBuilder);
        }
    }
}
