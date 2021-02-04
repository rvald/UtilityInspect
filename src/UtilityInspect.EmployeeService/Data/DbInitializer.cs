using System;
using System.Linq;
using UtilityInspect.EmployeeService.Models;

namespace UtilityInspect.EmployeeService.Data
{
    public class DbInitializer
    {
        public static void Initialize(EmployeeDbContext context)
        {

            if (context.Employees.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee
                {
                    EmployeeID = new Guid("6bb8a868-dba1-4f1a-93b7-24ebce87e243"),
                    FirstName = "Pepe",
                    LastName = "Pepito",
                    Role = "Field Tech"
                },

                new Employee
                {
                    EmployeeID = new Guid("b94afb54-a1cb-4313-8af3-b7511551b33b"),
                    FirstName = "Jose",
                    LastName = "Joseito",
                    Role = "Engineer"
                },

                new Employee
                {
                    EmployeeID = new Guid("ecfa6f80-3671-4911-aabe-63cc442c1ecf"),
                    FirstName = "Juan",
                    LastName = "Juanito",
                    Role = "Handyman"
                }

            };

            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }

            context.SaveChanges();
        }
    }
}