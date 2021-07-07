using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba15
{
    public static class ClassForRandom
    {
        public static string[] CreditTypes = new string[] { "banking", "commercial", "consumptive", "interstate" };

        public static string[] Names = new string[] { "Jack", "Trevor", "Joe", "Bill", "Tom", "Lamar", "Dan", "Swift",
                                                                 "Tyler", "Rob", "Stephan", "Ann", "Sophia" };

        public static string[] Surnames = new string[] { "Belichik", "Lawrence", "Chase", "Brady", "Willson", "Watson",
                                                                     "Young", "Jackson", "Washer", "Boll", "Williams" };
    }

    public class CreditType
    {
        public string TypeName { get; set; } = "";
    }
}
