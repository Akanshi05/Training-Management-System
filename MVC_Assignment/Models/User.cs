using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MVC_Assignment.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName{ get; set; }

        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [ScaffoldColumn(false)]
        [Compare("Password",ErrorMessage ="Passwords do not match")]
        public string ReTypePassword { get; set; }

        public string PhoneNo { get; set; }

        public Double Salary { get; set; }


        public Role UserRole { get; set; }

        public string ? ManagerName { get; set; }

        public bool IsActive { get; set; }
    }

    public enum Role
    {
        
        Manager = 1,
        Employee

    }
}
