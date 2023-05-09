using ClothingStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.ClassHelper
{
    public class UserData
    {
        public static User CurrentUser { get; set; }
        public static Employee CurrentEmployee { get; set; }
        public static Client CurrentClient { get; set; }
    }
}
