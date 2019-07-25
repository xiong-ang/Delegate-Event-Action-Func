using System;

namespace FuncObject
{
    class Delegate_Demo
    {
        private delegate int MyDelegate(int v1, int v2);
        private static int method1(int a, int b)
        {
            return a + b;
        }
        private static int method2(int a, int b)
        {
            return a * b;
        }
        public static void Delegate_Test()
        {
            MyDelegate myDelegate = new MyDelegate(method1);
            myDelegate += new MyDelegate(method2);
            Console.WriteLine(myDelegate(5, 6)); // return the last result
        }
    }
}
