﻿// <auto-generated />
using System;
using CommisionSystem.WebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommisionSystem.WebApplication.Migrations
{
    [DbContext(typeof(CommisionContext))]
    [Migration("20211028061432_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            ID = 4,
                            AccessLevel = 5,
                            RoleName = "Super Admin"
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
                        .HasForeignKey("RoleID");

                    b.HasOne("CommisionSystem.WebApplication.Data.User", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorID");

                    b.Navigation("Role");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("CommisionSystem.WebApplication.Data.Role", b =>
                {
                    b.Navigation("RolePolicies");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}