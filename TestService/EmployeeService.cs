using ClothingStore.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothingStore.TestService
{
    public static class EmployeeService
    {
        public static List<Employee> Employees { get; set; }

        static int nextID = 3;

        static EmployeeService()
        {
            Employees = new List<Employee>
            {
                new Employee{ EmployeeID = 1, FName = "Михаил", LName="Пантелеев", Patronymic = "Александрович", BirthDate = DateTime.Parse("17.10.2004"), Email = "deadline@gmail.com", Phone = "89576594826", Password = "11111", Gender = Gender.GenderTitle.Мужской, RoleTitle = Employee.Role.Директор},
                new Employee{ EmployeeID = 2, FName = "Елизавета", LName="Маркова", Patronymic = "Александровна", BirthDate = DateTime.Parse("23.04.2004"), Email = "chtototam@gmail.com", Phone = "89745583965", Password = "22222", Gender = Gender.GenderTitle.Женский, RoleTitle = Employee.Role.Менеджер}
            };
        }

        public static List<Employee> GetAll() => Employees;

        public static Employee Get(int id) => Employees.FirstOrDefault(e => e.EmployeeID == id);

        public static void Add(Employee employee)
        {
            employee.EmployeeID = nextID++;
            Employees.Add(employee);
        }

        public static void Update(Employee employee) 
        {
            var index = Employees.FindIndex(e => e.EmployeeID == employee.EmployeeID);
            if (index == -1) return;

            Employees[index] = employee;
        }

        public static void Delete(int id)
        {
            var employee = Get(id);
            if (employee is null) return;

            Employees.Remove(employee);
        }
    }
}
