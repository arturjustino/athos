using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athos.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string City { get; set; }

        public User()
        {
            ID = 0;
            Name = string.Empty;
            Gender = string.Empty;
            Department = string.Empty;
            City = string.Empty;
        }
    }
}
