using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba15
{
    [Serializable]
    public class Borrower
    {
        public string Name { get; set; }

        public List<Credit> CreditList { get; set; } = new List<Credit>();


        // constructors

        public Borrower()
        {
            Name = ClassForRandom.Names[(new Random()).Next(0, ClassForRandom.Names.Length)]
                                        + " " + ClassForRandom.Surnames[(new Random()).Next(0, ClassForRandom.Surnames.Length)];
        }

        public Borrower(int creds)
        {
            Random rnd = new Random();
            Name = ClassForRandom.Names[rnd.Next(0, ClassForRandom.Names.Length)]
                                        + ClassForRandom.Surnames[rnd.Next(0, ClassForRandom.Surnames.Length)];

            for (int i = 0; i < creds; i++)
            {
                Credit cr = new Credit(rnd.Next(1000, 10000000), rnd.Next(10, 1000),
                    ClassForRandom.CreditTypes[rnd.Next(0, ClassForRandom.CreditTypes.Length)]);
                CreditList.Add(cr);
            }
        }

        // methods
        public override string ToString()
        {
            return $"Имя: {Name};";
        }

        public override bool Equals(object obj)
        {
            Borrower brwr = (Borrower)obj;
            bool ok = false;
            if (brwr.CreditList.Count == CreditList.Count)
            {
                ok = true;
                for (int i = 0; i < CreditList.Count; i++)
                {
                    ok = ok && (brwr.CreditList[i].Equals(CreditList[i]));
                }
            }

            return (brwr.Name == Name) && ok;
        }

        public void Add(Credit credit)
        {
            CreditList.Add(credit);
        }

        public void Add()
        {
            CreditList.Add(new Credit());
        }
    }

    //public class ForTheSakeOfINT
    //{
    //    public int CountAddBorrowers = 0;
    //}

    //public class IntToDelete
    //{
    //    public int number = 0;
    //}
}
