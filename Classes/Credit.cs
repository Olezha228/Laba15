using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba15
{
    [Serializable]
    public class Credit
    {
        public int Sum { get; set; }

        public int Days { get; set; }

        public string TypeOfCredit { get; set; }


        // constructors
        public Credit(int sum, int days, string typeOfCredit)
        {
            Sum = sum;
            Days = days;
            TypeOfCredit = typeOfCredit;
        }
        
        public Credit()
        {
            Random rnd = new Random();
            Sum = rnd.Next(1000, 10000000);
            Days = rnd.Next(10, 1000);
            TypeOfCredit = ClassForRandom.CreditTypes[rnd.Next(0, ClassForRandom.CreditTypes.Length)];
        }



        // methods
        public override string ToString()
        {
            return $"Сумма: {Sum}; Срок: {Days} дней; Тип: {TypeOfCredit};";
        }

        public override bool Equals(object obj)
        {
            Credit cr = (Credit)obj;

            return (cr.Sum == Sum) && (cr.Days == Days) && (cr.TypeOfCredit.Equals(TypeOfCredit));
        }
    }
}
