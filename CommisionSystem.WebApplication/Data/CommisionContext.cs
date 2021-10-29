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

        public CommisionContext(DbContextOptions<CommisionContext> options):base( options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Roles

            modelBuilder.Entity<Role>().HasData(
                new { ID = 1, RoleName = "Super Admin", AccessLevel = 4 });

            modelBuilder.Entity<Role>().HasData(
                new { ID = 2, RoleName = "Admin", AccessLevel = 3 });

            modelBuilder.Entity<Role>().HasData(
                new { ID = 3, RoleName = "Supervisor", AccessLevel = 2 });

            modelBuilder.Entity<Role>().HasData(
                new { ID = 4, RoleName = "Expert", AccessLevel = 1 });

            #endregion

            #region Seed Users

            modelBuilder.Entity<User>().HasData(
                new { ID = 1,FirstName="Admin",LastName="Admin",UserName="admin",Password="123", RoleID = 1,HasAccessToProductSearchReport=true,HasAccessToQuote=true,Status=true });

            modelBuilder.Entity<User>().HasData(
                new { ID = 2, FirstName = "Alireza", LastName = "Sabouei", UserName = "ali", Password = "123", RoleID = 4, HasAccessToProductSearchReport = true, HasAccessToQuote = false, Status = true });

            #endregion

            modelBuilder.Entity<RolePolicy>().HasData(
                new { ID = 1, RoleID = 1, Policy = "CreateUser"});


            base.OnModelCreating(modelBuilder);
        }
    }
}
