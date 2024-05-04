namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] personArray = new Person[]
            {
                new Person(1, "Ariel", "Znakowski"),
                new Person(2, "Bartosz", "Yeti"),
                new Person(3, "Cezary", "Xerowski"),
                new Person(4, "Daniel", "Walecki")
            };
            Transaction[] transactionArray = new Transaction[]
            {
                new Transaction(1, "Accordion", 100, 1),
                new Transaction(2, "Bread", 3, 2),
                new Transaction(3, "Cello", 400, 3),
                new Transaction(4, "DVD", 50, 2),
                new Transaction(5, "Emser salt", 10, 1),
                new Transaction(6, "Fiddle", 20, 1)
            };
            Winner[] winnerArray = new Winner[]
            {
                new Winner("Brazil", new[] {1958, 1962, 1970, 1994, 2002}),
                new Winner("Germany", new[] {1954, 1974, 1990, 2014}),
                new Winner("Italy", new[]{1934, 1938, 1982, 2006})
            };

            IEnumerable<Person> peopleW;
            peopleW = personArray.Where(x => x.PersonID.Equals(1));
            Print(peopleW);

            IEnumerable<(string name, string surname)> peopleS;
            peopleS = personArray.Select(x => (x.Name, x.Surname));
            Print(peopleS);

            var peopleC = personArray.Count();
            Console.WriteLine(peopleC);

            var peopleO = personArray.OrderBy(x => x.Surname).ThenBy(x => x.Name);
            Print(peopleO);

            var combinedP = personArray.Join(transactionArray, x1 => x1.PersonID, x2 => x2.ClientID,
                (x1, x2) => (x1.Name, x1.Surname, x2.Item, x2.Price));
            Print(combinedP);

            Console.WriteLine();

            var combinedT = transactionArray.Join(personArray, x1 => x1.ClientID, x2 => x2.PersonID,
                (x1, x2) => (x2.Name, x2.Surname, x1.Item, x1.Price));
            Print(combinedT);

            Console.WriteLine();

            var groupJoinP = personArray.GroupJoin(transactionArray, x1 => x1.PersonID, x2 => x2.ClientID,
                (person, transactions) => new { person.Name, person.Surname, Tra = transactions });

            foreach(var elem in groupJoinP)
            {
                Console.WriteLine(elem.Name + " " + elem.Surname);
                foreach(var t in elem.Tra)
                {
                    Console.WriteLine("\t" + t);
                }
            }

            Console.WriteLine();

            var manyYears = winnerArray.Where(x => x.Country == "Germany").SelectMany(x => x.Years);
            foreach(var year in manyYears)
            {
                Console.WriteLine(year);
            }

            Console.WriteLine();

            var combinedG = transactionArray.GroupBy(t => t.ClientID, (client) => (client.Item, client.Price));
            foreach(var g in combinedG)
            {
                Console.WriteLine("Count " + g.Count());
                Console.WriteLine("Min " + g.Min(g => g.Price));
                Console.WriteLine("Max " + g.Max(g => g.Price));
            }

            Console.WriteLine();

            var anonymousTypeO = new { Name = "ŁKS", Year = 1908 };
            Console.WriteLine(anonymousTypeO);

            Stack<int> myStack = new Stack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            Stack<int>.Enumerator enumerator = myStack.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        static void Print<T>(IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
