﻿// <auto-generated />
using System;
using CommissionSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommissionSystem.Data.Migrations
{
    [DbContext(typeof(CommisionContext))]
    [Migration("20211217192605_TestForSeedData")]
    partial class TestForSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommissionSystem.Data.Policy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

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
                        },
                        new
                        {
                            ID = 7,
                            DisplayName = "Dashboard",
                            Name = "Dashboard"
                        });
                });

            modelBuilder.Entity("CommissionSystem.Data.Quote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssigneeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PersonInCharge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuoteStatusID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AssigneeID");

                    b.HasIndex("CreatorID");

                    b.HasIndex("QuoteStatusID");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("CommissionSystem.Data.QuoteItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Commission")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("QuoteID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalPriceInRials")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitPriceInRials")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("QuoteID");

                    b.ToTable("QuoteItem");
                });

            modelBuilder.Entity("CommissionSystem.Data.QuoteStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("QuoteStatus");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Open",
                            Title = "Open"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Draft",
                            Title = "Draft"
                        },
                        new
                        {
                            ID = 3,
                            Name = "WaitingToConfirm",
                            Title = "Waiting To Confirm"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Finalized",
                            Title = "Finalized"
                        });
                });

            modelBuilder.Entity("CommissionSystem.Data.Role", b =>
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
                            AccessLevel = 30,
                            RoleName = "Super Admin"
                        },
                        new
                        {
                            ID = 2,
                            AccessLevel = 20,
                            RoleName = "Supervisor"
                        },
                        new
                        {
                            ID = 3,
                            AccessLevel = 10,
                            RoleName = "Expert"
                        });
                });

            modelBuilder.Entity("CommissionSystem.Data.User", b =>
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
                            RoleID = 3,
                            Status = true,
                            UserName = "ali"
                        });
                });

            modelBuilder.Entity("CommissionSystem.Data.UserBrand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserBrands");
                });

            modelBuilder.Entity("CommissionSystem.Data.UserPolicy", b =>
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
                        },
                        new
                        {
                            ID = 7,
                            PolicyID = 7,
                            UserID = 1
                        });
                });

            modelBuilder.Entity("CommissionSystem.Data.Quote", b =>
                {
                    b.HasOne("CommissionSystem.Data.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommissionSystem.Data.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommissionSystem.Data.QuoteStatus", "QuoteStatus")
                        .WithMany()
                        .HasForeignKey("QuoteStatusID");

                    b.Navigation("Assignee");

                    b.Navigation("Creator");

                    b.Navigation("QuoteStatus");
                });

            modelBuilder.Entity("CommissionSystem.Data.QuoteItem", b =>
                {
                    b.HasOne("CommissionSystem.Data.Quote", "Quote")
                        .WithMany("QuoteItems")
                        .HasForeignKey("QuoteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("CommissionSystem.Data.User", b =>
                {
                    b.HasOne("CommissionSystem.Data.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommissionSystem.Data.User", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorID");

                    b.Navigation("Role");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("CommissionSystem.Data.UserBrand", b =>
                {
                    b.HasOne("CommissionSystem.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CommissionSystem.Data.UserPolicy", b =>
                {
                    b.HasOne("CommissionSystem.Data.Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommissionSystem.Data.User", "User")
                        .WithMany("UserPolicies")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CommissionSystem.Data.Quote", b =>
                {
                    b.Navigation("QuoteItems");
                });

            modelBuilder.Entity("CommissionSystem.Data.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CommissionSystem.Data.User", b =>
                {
                    b.Navigation("UserPolicies");
                });
#pragma warning restore 612, 618
        }
    }
}
