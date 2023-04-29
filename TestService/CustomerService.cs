using ClothingStore.TestModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothingStore.TestService
{
    public static class CustomerService
    {
        public static List<Customer> Customers { get; set; }

        static int nextID = 3;

        static CustomerService()
        {
            Customers = new List<Customer> 
            {
                new Customer{ CustomerID = 1, FName = "Вячеслав", LName="Находнов", Patronymic="Сергеевич", BirthDate = DateTime.Parse("06.11.2004"), Email = "slava.nah91@gmail.com", Phone = "89686645398", Password = "12345", Gender = Gender.GenderTitle.Мужской },
                new Customer{ CustomerID = 2, FName = "Алексей", LName="Петченко", Patronymic="Валерьевич", BirthDate = DateTime.Parse("02.09.2005"), Email = "drony@gmail.com", Phone = "89624234322", Password = "54321", Gender = Gender.GenderTitle.Мужской }
            };
        }

        public static List<Customer> GetAll() => Customers;

        public static Customer Get(int id) => Customers.FirstOrDefault(c => c.CustomerID == id);

        public static void Add(Customer customer)
        {
            customer.CustomerID = nextID++;
            Customers.Add(customer);
        }

        public static void Update(Customer customer) 
        {
            var index = Customers.FindIndex(c => c.CustomerID == customer.CustomerID);
            if (index == -1) return;

            Customers[index] = customer;
        }

        public static void Delete(int id)
        {
            var customer = Get(id);
            if (customer is null) return;

            Customers.Remove(customer);
        }
    }
}
