using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Database2024
{
    public class User
    {
        public string Name { get; set; }
        public uint Age { get; set; }
        public string Position { get; set; }
        public float Salary { get; set; }

        public User()
        {
            Clear();
        }
        private User(string name, uint age, string position, float salary)
        {
            Name = name;
            Age = age;
            Position = position;
            Salary = salary;
        }
        public User Copy() => new (Name, Age, Position, Salary);

        public void Clear()
        {
            Name = "";
            Age = 18;
            Position = "";
            Salary = 20000.01f;
        }
    }
}
