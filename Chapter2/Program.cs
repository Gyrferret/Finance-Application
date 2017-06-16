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

        static void ValidExpressions()
        {
            int x, y;
            x = y = 0;
            Console.WriteLine(x);
            Console.WriteLine(y);

            // both are valid expressions, and both produce the same output. 
            int z;
            Console.WriteLine(z = 123);
            Console.WriteLine(z);

            // delimited comments
            Console.WriteLine(/*Ignore this text */ "Don't ignore this text");

            // ctrl+K + ctrl+C to comment out, ctrl+k + ctrl+u to undo
        }

        static void PreprocessingDirectives()
        {
            // Compilation symbols can be used to define debug actions
            /* 
             * #if DEBUG
             * Do.Work()
             * #endif
             * Normal.Work()
            */

            // Conditional Methos are flags within the .NET framework. The compiler will strip out this code for release. 
            /*[System.Diagnostics.Conditional("DEBUG")]
             * static void DebugWork()
             * {Do.DebugWork()}
             */

             /* You can specify the line numbner that an error occured by using;
              * #line 123 "Path.cs"
              * Use:
              * #line DEFAULT
              * to restore normal unhandled error functionality.
              */
        }

        static void ConvertingDataTypes()
        {
            /* Data Types can be implicity converted if it's going to a larger format:
             * INT -> Float -> Double
             * You cannot implictly convert from larger to smaller:
             * Double -> Float -> Int
             * You can cast to try and explicitly convert:
             */
            int i = 42;
            int i2 = (int)42.0;
            int i3 = (int)(i / 1.0);

            // casting only applies to the first expression following the cast, hence the need for () in the third example
        }

        static void CheckedContext()
        {
            int a, b, c;
            a = b = c = 3;
            int x = checked(a + b) * c;
            /* The checked value will result in the system throwing a Overflow Exception error if the values overrun the range of the stated type,
             * which is Int in this case. Checked only applies to the first expression following the case, hence the ()
             */
        }

        static void ConditionalOperators()
        {
            /* A conditional Operator will evaluate two statements. However, if the first statement in a conditional AND 
             * statement returns FALSE, it will not evaluate the subsequent statement. This is why this 
             * function will work
             */
            string a = "string";
            if (a != null && a.Length > 10)
            {
                Console.WriteLine(a);
            }

            /* A special kind of operator will evaluate a statement, and, based on that evaluation, 
             * it will pick one of two values. 
             */
            int x = 3;
            int y = 4;
            int XOrY = (x > y) /*statement to evaluate for TRUE/FALSE*/ ? x /*Select value between ? and : if TRUE*/ : y /*select value after : if FALSE*/;

            // put to good use:
            string Input = "string";
            string SanitizedInput = (Input == null) ? "0" : Input;

            // Null Coalescing allows for this, except in less steps:

            string Input2 = "string";
            string SanitizedInput2 = Input2 ?? /*if the input before ?? is not null, then the value is what's after the ?? */ "";

            // The following are both valid.

            int x1 = 2;

            x1 = x1 + 1;
            x1 += 1;
        }

        static void SwitchStatements()
        {
            // standard switch
            int a = 3;
            switch (a)
            {
                case 2 :
                    Console.WriteLine("Not 2");
                    break;
                default: Console.WriteLine(a);
                    break;
            }

            // allowing Fall Through requires the "goto" statement

            switch (a)
            {
                case 2:
                    Console.WriteLine("Not 2");
                    goto case 4;
                case 3: 
                    Console.WriteLine("That's the one");
                    break;
                case 4:
                    Console.WriteLine("Still Missed It");
                    break;
            }
        }
    }
}
