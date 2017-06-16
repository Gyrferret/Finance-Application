using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    class ChapterTwo
    {
        static void WorkingWithStatements()
        {
            // declaration statments 
            int a = 2;
            int b = 3;
            int c;

            // expression statements 
            c = a + b;
            Console.WriteLine(c);

            // iteration statement
            while (c < 7)
            {
                c++;
            }

            // selection statement
            if ( c > 7)
            {
                c++;
            } 
        }
    }
}
