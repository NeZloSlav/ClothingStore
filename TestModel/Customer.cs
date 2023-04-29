using System;

namespace ClothingStore.TestModel
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; } 
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Gender.GenderTitle Gender { get; set; }

    }
}
