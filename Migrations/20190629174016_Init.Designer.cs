﻿// <auto-generated />
using System;
using ManageSchool.AspNetCore.NewDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManageSchool.AspNetCore.NewDb.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20190629174016_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("ManageSchool.AspNetCore.NewDb.Models.Class", b =>
                {
                    b.Property<Guid?>("ClassId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName");

                    b.Property<string>("Location");

                    b.HasKey("ClassId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("ManageSchool.AspNetCore.NewDb.Models.DisplayStudent", b =>
                {
                    b.Property<Guid?>("ClassId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ClassId1");

                    b.Property<string>("ClassName");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<double>("GPA");

                    b.Property<string>("StudentId");

                    b.Property<string>("StudentName");

                    b.HasKey("ClassId");

                    b.HasIndex("ClassId1");

                    b.HasIndex("StudentId");

                    b.ToTable("Display");
                });

            modelBuilder.Entity("ManageSchool.AspNetCore.NewDb.Models.Registered", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Error");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("ManageSchool.AspNetCore.NewDb.Models.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ClassId");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<double>("GPA");

                    b.Property<string>("StudentName");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ManageSchool.AspNetCore.NewDb.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("ManageSchool.AspNetCore.NewDb.Models.DisplayStudent", b =>
                {
                    b.HasOne("ManageSchool.AspNetCore.NewDb.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId1");

                    b.HasOne("ManageSchool.AspNetCore.NewDb.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("ManageSchool.AspNetCore.NewDb.Models.Student", b =>
                {
                    b.HasOne("ManageSchool.AspNetCore.NewDb.Models.Class", "Class")
                        .WithMany("Student")
                        .HasForeignKey("ClassId");
                });
#pragma warning restore 612, 618
        }
    }
}