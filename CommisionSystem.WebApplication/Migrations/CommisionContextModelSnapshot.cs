﻿// <auto-generated />
using System;
using CommisionSystem.WebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommisionSystem.WebApplication.Migrations
{
    [DbContext(typeof(CommisionContext))]
    partial class CommisionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.Policy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Policies");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DisplayName = "Read Products",
                            Name = "ReadProducts"
                        },
                        new
                        {
                            ID = 2,
                            DisplayName = "Read Brands",
                            Name = "ReadBrands"
                        },
                        new
                        {
                            ID = 3,
                            DisplayName = "Read Users",
                            Name = "ReadUsers"
                        },
                        new
                        {
                            ID = 4,
                            DisplayName = "Disable User Account",
                            Name = "DisableUserAccount"
                        },
                        new
                        {
                            ID = 5,
                            DisplayName = "Enable User Account",
                            Name = "EnableUserAccount"
                        },
                        new
                        {
                            ID = 6,
                            DisplayName = "Add User Account",
                            Name = "AddUserAccount"
                        });
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AccessLevel = 4,
                            RoleName = "Super Admin"
                        },
                        new
                        {
                            ID = 2,
                            AccessLevel = 3,
                            RoleName = "Admin"
                        },
                        new
                        {
                            ID = 3,
                            AccessLevel = 2,
                            RoleName = "Supervisor"
                        },
                        new
                        {
                            ID = 4,
                            AccessLevel = 1,
                            RoleName = "Expert"
                        });
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.RolePolicy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Policy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("RolePolicies");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Policy = "CreateUser",
                            RoleID = 1
                        });
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasAccessToProductSearchReport")
                        .HasColumnType("bit");

                    b.Property<bool>("HasAccessToQuote")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("SupervisorID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("SupervisorID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FirstName = "Admin",
                            HasAccessToProductSearchReport = true,
                            HasAccessToQuote = true,
                            LastName = "Admin",
                            Password = "123",
                            RoleID = 1,
                            Status = true,
                            UserName = "admin"
                        },
                        new
                        {
                            ID = 2,
                            FirstName = "Alireza",
                            HasAccessToProductSearchReport = true,
                            HasAccessToQuote = false,
                            LastName = "Sabouei",
                            Password = "123",
                            RoleID = 4,
                            Status = true,
                            UserName = "ali"
                        });
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.UserPolicy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PolicyID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PolicyID");

                    b.HasIndex("UserID");

                    b.ToTable("UserPolicies");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            PolicyID = 1,
                            UserID = 1
                        },
                        new
                        {
                            ID = 2,
                            PolicyID = 2,
                            UserID = 1
                        },
                        new
                        {
                            ID = 3,
                            PolicyID = 3,
                            UserID = 1
                        },
                        new
                        {
                            ID = 4,
                            PolicyID = 4,
                            UserID = 1
                        },
                        new
                        {
                            ID = 5,
                            PolicyID = 5,
                            UserID = 1
                        },
                        new
                        {
                            ID = 6,
                            PolicyID = 6,
                            UserID = 1
                        });
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.Policy", b =>
                {
                    b.HasOne("CommisionSystem.WebApplication.Data.User", null)
                        .WithMany("UserPolicies")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.RolePolicy", b =>
                {
                    b.HasOne("CommisionSystem.WebApplication.Data.Role", "Role")
                        .WithMany("RolePolicies")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.User", b =>
                {
                    b.HasOne("CommisionSystem.WebApplication.Data.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommisionSystem.WebApplication.Data.User", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorID");

                    b.Navigation("Role");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.UserPolicy", b =>
                {
                    b.HasOne("CommisionSystem.WebApplication.Data.Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommisionSystem.WebApplication.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.Role", b =>
                {
                    b.Navigation("RolePolicies");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.User", b =>
                {
                    b.Navigation("UserPolicies");
                });
#pragma warning restore 612, 618
        }
    }
}
