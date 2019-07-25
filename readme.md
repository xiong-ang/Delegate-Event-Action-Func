# Delegate vs Event vs Action vs Func
> **Delegate** 类似于函数指针，可以实现函数对象的传递；  
**Event** 利用Delegate实现了发布订阅模式；   
**Action和Func** 实现泛型Delegate，无须预定义，简化使用。

## Delegate
### Delegate vs 函数指针   
delegate相当于函数指针，但函数指针只能指向静态函数，而delegate既可以引用静态函数，又可以引用非静态成员函数。在引用非静态成员函数时，delegate不但保存了对此函数入口指针的引用，而且还保存了调用此函数的类实例的引用（保存了调用上下文）。其次，与函数指针相比，delegate是面向对象、类型安全、可靠的受控（managed）对象。也就是说，runtime能够保证delegate指向一个有效的方法，你无须担心delegate会指向无效地址或者越界地址。
```C#
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
```
## Event
### 发布订阅模式
事件是一种标准的发布订阅模式：事件订阅时，通过给委托对象增加方法实现；事件发布时，通过调用委托对象实现。
### Example
```C#
//自定义参数，参数来着事件发布者
public class ButtonClickArgs : EventArgs
{
    public string Clicker;
}

public class MyButton
{
    public delegate void ClickHandler(object sender, ButtonClickArgs e); 
    //定义Event，Event对ClickHandler对象进行了封装，只暴露+=/-=方法
    public event ClickHandler OnClick; 

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
```
### Event vs Delegate
首先，通过加入event关键字，在编译的时候编译器会自动针对事件生成一个私有的字段（与此事件相关的委托），以及两个访问器方法，即add访问器方法以及remove访问器方法，用于对事件的注册及注销（对事件使用+=及-=操作时就是调用的这两个方法）。  
实际上声明一个委托类型的字段也可以实现这些功能，之所以采用event而不直接采用委托，还是**为了封装**。可以设想一下，如果直接采用公共的委托字段，类型外部就可以对此字段进行直接的操作了，比如将其直接赋值为null。  
而使用event关键字就可以保证对事件的操作仅限于add访问器方法以及remove访问器方法（即只能使用+=及-=）。

## Action & Func
delegate，Action和Func都是为了实现**操作方法的传递**，Action和Func用泛型预定义delegate，因此，用户不需要定义delegate，可以直接定义delegate的对象使用，简化了使用流程。
```C#
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
```