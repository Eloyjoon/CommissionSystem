﻿// <auto-generated />
using System;
using CommissionSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommissionSystem.WebApplication.Migrations
{
    [DbContext(typeof(CommisionContext))]
    [Migration("20211028063506_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommissionSystem.WebApplication.Data.Role", b =>
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

            modelBuilder.Entity("CommissionSystem.WebApplication.Data.RolePolicy", b =>
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

            modelBuilder.Entity("CommissionSystem.WebApplication.Data.User", b =>
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

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.Property<int?>("SupervisorID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("SupervisorID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CommissionSystem.WebApplication.Data.RolePolicy", b =>
                {
                    b.HasOne("CommissionSystem.WebApplication.Data.Role", "Role")
                        .WithMany("RolePolicies")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CommissionSystem.WebApplication.Data.User", b =>
                {
                    b.HasOne("CommissionSystem.WebApplication.Data.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID");

                    b.HasOne("CommissionSystem.WebApplication.Data.User", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorID");

                    b.Navigation("Role");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("CommissionSystem.WebApplication.Data.Role", b =>
                {
                    b.Navigation("RolePolicies");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
