using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            //Seed default roles
            if (!context.Roles.Any())
            {
                var adminRole = new Role { Name = "Admin" };
                var userRole = new Role { Name = "User" };
                context.Roles.AddRange(adminRole, userRole);
                context.SaveChanges();
            }

            //Seed default Users with their roles. We adding admin user only for now
            if (!context.Users.Any())
            {
                var pwHash = BCrypt.Net.BCrypt.HashPassword("P@ssword");
                var AdminUser = new User
                {
                    FullName = "AdminUser",
                    Email = "Admin@example.com",
                    PasswordHash = pwHash,

                };
               
                context.Users.Add(AdminUser);

                context.SaveChanges();


                var admin = context.Roles.Single(r => r.Name == "Admin");

                context.UserRoles.Add(new UserRole { UserId = AdminUser.Id, RoleId = admin.Id });

                context.SaveChanges();
            }

            //Seed Default employee data
            if (!context.Employees.Any())
            {
                var employees = new[]
                {
                    new Employee { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Department = "Sales", Position = "Sales Rep", Phone = "071-000-0001" },
                    new Employee { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Department = "HR", Position = "HR Manager", Phone = "071-000-0002" },
                    new Employee { FirstName = "Samuel", LastName = "Kane", Email = "sam.kane@example.com", Department = "IT", Position = "Developer", Phone = "071-000-0003" },
                    new Employee { FirstName = "Ayesha", LastName = "Patel", Email = "ayesha.patel@example.com", Department = "Finance", Position = "Accountant", Phone = "071-000-0004" },
                    new Employee { FirstName = "Liam", LastName = "Ngcobo", Email = "liam.ngcobo@example.com", Department = "Logistics", Position = "Driver", Phone = "071-000-0005" },
                    new Employee { FirstName = "Thandi", LastName = "Moyo", Email = "thandi.moyo@example.com", Department = "Support", Position = "Support", Phone = "071-000-0006" },
                    new Employee { FirstName = "Carlos", LastName = "Reyes", Email = "carlos.reyes@example.com", Department = "Marketing", Position = "Marketer", Phone = "071-000-0007" },
                    new Employee { FirstName = "Maya", LastName = "Singh", Email = "maya.singh@example.com", Department = "R&D", Position = "Researcher", Phone = "071-000-0008" },
                    new Employee { FirstName = "Ethan", LastName = "Brown", Email = "ethan.brown@example.com", Department = "IT", Position = "DevOps", Phone = "071-000-0009" },
                    new Employee { FirstName = "Zanele", LastName = "Khumalo", Email = "zanele.khumalo@example.com", Department = "Sales", Position = "Sales Rep", Phone = "071-000-0010" }
                };


                context.Employees.AddRange(employees);
                context.SaveChanges();
            }

        }
    }
}
