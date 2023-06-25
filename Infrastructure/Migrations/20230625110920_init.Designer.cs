﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230625110920_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Entities.DepartmentEmployee", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DepartmentId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("DepartmentEmployees");
                });

            modelBuilder.Entity("Domain.Entities.DepartmentManager", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<int>("EmployeeId1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TODate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DepartmentId", "EmployeeId");

                    b.HasIndex("EmployeeId1");

                    b.ToTable("departmentManagers");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Salary", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<int>("EmployeeId1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId1");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("Domain.Entities.DepartmentEmployee", b =>
                {
                    b.HasOne("Domain.Entities.Department", "Department")
                        .WithMany("DepartmentEmployees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("departmentEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Entities.DepartmentManager", b =>
                {
                    b.HasOne("Domain.Entities.Department", "Department")
                        .WithMany("departmentManagers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("DepartmentManagers")
                        .HasForeignKey("EmployeeId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Entities.Salary", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("Salaries")
                        .HasForeignKey("EmployeeId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.Navigation("DepartmentEmployees");

                    b.Navigation("departmentManagers");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Navigation("DepartmentManagers");

                    b.Navigation("Salaries");

                    b.Navigation("departmentEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}
