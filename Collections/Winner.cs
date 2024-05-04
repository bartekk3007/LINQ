using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Winner
    {
        public string Country {  get; set; }
        public int[] Years { get; set; }
        public Winner(string country, int[] years)
        {
            Country = country;
            Years = years;
        }
        public override string ToString()
        {
            return $"{Country} {Years[0]}";
        }
    }
}
