using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Person
    {
        public int PersonID {  get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public Person(int id, string name, string surname)
        {
            PersonID = id;
            Name = name;
            Surname = surname;
        }
        public override string ToString()
        {
            return $"{PersonID.ToString()}.\t{Name} {Surname}";
        }
    }
}
