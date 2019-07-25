using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Delegate_Demo.Delegate_Test();


            MyButton myButton = new MyButton();
            //订阅事件
            Client.SubscribeEvent(myButton);
            //发布事件
            myButton.Click();


            Event_Func_Demo.Action_Test();
            Event_Func_Demo.Func_Test();
        }
    }
}
