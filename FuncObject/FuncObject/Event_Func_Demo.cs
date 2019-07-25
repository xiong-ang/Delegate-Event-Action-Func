using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncObject
{
    class Event_Func_Demo
    {
        private static Action<int, int> myAction;
        private static void method1(int a, int b)
        {
            Console.WriteLine($"{a}, {b}");
        }
        public static void Action_Test()
        {
            myAction += method1;
            myAction(5, 6);
        }


        private static Func<int, int, string> myFunc;
        private static string method2(int a, int b)
        {
            return $"{a}-{b}";
        }
        public static void Func_Test()
        {
            myFunc += method2;
            Console.WriteLine(myFunc(5, 6));
        }
    }
}
