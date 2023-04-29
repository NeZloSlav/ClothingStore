using System;

namespace ClothingStore.TestModel
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Gender.GenderTitle Gender { get; set; }
        public Role RoleTitle { get; set; }

        public enum Role { Директор, Менеджер}
    }
}
