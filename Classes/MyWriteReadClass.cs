using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba15.Classes
{
    static public class MyWriteReadClass
    {
        static public void WriteInTextFile(string str)
        {
            StreamWriter s = File.AppendText(@"D:\laba15db\LINQ-results.txt");
            s.WriteLine(str);
            s.Close();
        }


    }
}
