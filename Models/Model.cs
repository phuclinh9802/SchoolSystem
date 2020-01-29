using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ManageSchool.AspNetCore.NewDb.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        { }
        public DbSet<Registered> Register { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<DisplayStudent> Display { get; set; }
        public DbSet<Test> Test { get; set; }
    }
    public class Registered     {         public Guid Id { get; set; }         [DisplayName("User Name: ")]         [Required(ErrorMessage = "This field is required!")]         public string UserName { get; set; }         [DisplayName("Password: ")]         [Required(ErrorMessage = "This field is required!")]         [DataType(DataType.Password)]         public string Password { get; set; }
        public string Error { get; set; }
     }
    public class Class
    {
        [Key]
        public Guid? ClassId { get; set; }
        public string ClassName { get; set; }
        public string Location { get; set; }

        public IList<Student> Student { get; set; }

    }
    public class ClassModel
    {
        public Guid? ClassId { get; set; }
        public string ClassName { get; set; }
        public string Location { get; set; }
    }
    public class Student
    {
        [Key]
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        public double GPA { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Guid? ClassId { get; set; }
        public Class Class { get; set; }

    }
    public class EntireModel
    {
        
        public Guid? ClassId { get; set; }
        public string ClassName { get; set; }
        public string Location { get; set; }
        public int NumberStudents { get; set; }
    }
    public class DisplayClass
    {
        public string ClassName { get; set; }
        public string Location { get; set; }
        public int NumberStudents { get; set; }
    }
    public class DisplayStudent
    {
        [Key]
        public Guid? ClassId { get; set; }
        public string StudentName { get; set; }
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        public double GPA { get; set; }
        public string Email { get; set; }
        public string ClassName { get; set; }

        public Student Student { get; set; }
        public Class Class { get; set; }

    }
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }



}
