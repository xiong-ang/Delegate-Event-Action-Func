using System;

namespace FuncObject
{
    //自定义参数，参数来着事件发布者
    public class ButtonClickArgs : EventArgs
    {
        public string Clicker;
    }

    public class MyButton
    {
        public delegate void ClickHandler(object sender, ButtonClickArgs e); 
        public event ClickHandler OnClick; //Event 对ClickHandler对象进行了封装，只暴露+=/-=方法

        //事件发布
        public void Click()
        { 
            OnClick(this, new ButtonClickArgs() { Clicker = "ivy" });
        }
    }

    public class Client
    {
        //订阅事件
        public static void SubscribeEvent(MyButton btn)
        {  
            btn.OnClick += someAction1;
            btn.OnClick += someAction2;
        }
        
        public static void someAction1(object sender, ButtonClickArgs e)
        {
            Console.WriteLine("someAction1");
        }
        public static void someAction2(object sender, ButtonClickArgs e)
        {
            Console.WriteLine("someAction2");
        }
    }
}
