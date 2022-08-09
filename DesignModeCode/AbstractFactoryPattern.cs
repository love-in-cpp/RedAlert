using System;
using UnityEngine;

 /*
  * Sunny软件公司欲推出一款新的手机游戏软件，
  * 该软件能够支持Symbian、Android和Windows Mobile等多个智能手机操作系统平台，
  * 针对不同的手机操作系统，
  * 该游戏软件提供了不同的游戏操作控制(OperationController)类和游戏界面控制(InterfaceController)类，
  * 并提供相应的工厂类来封装这些类的初始化过程。
  * 软件要求具有较好的扩展性以支持新的操作系统平台，为了满足上述需求，试采用抽象工厂模式对其进行设计。
  */


public class AbstractFactoryPattern : MonoBehaviour
{
    private void Start()
    {
        OSFactory osFactory = new SymbianFactory();
        var ic = osFactory.CreatIC();
        var oc = osFactory.CreatOC();
        ic.ApplyMethod();
        oc.ApplyMethod();
        
        OSFactory osFactory1 = new WindowsFactory();
        var ic1 = osFactory1.CreatIC();
        var oc1 = osFactory1.CreatOC();
        ic1.ApplyMethod();
        oc1.ApplyMethod();

    }
}

public abstract class Controller
{
    protected string name;

    public virtual void ApplyMethod()
    {
        Debug.Log(name);
    }
}
public abstract class OperationController:Controller
{
   
}
public abstract class InterfaceController:Controller
{
    
}

public class SymbianOC:OperationController
{
    public override void ApplyMethod()
    {
        this.name = "SymbianOC";
        base.ApplyMethod();
    }
}
public class AndroidOC:OperationController
{
    public override void ApplyMethod()
    {
        this.name = "AndroidOC";
        base.ApplyMethod();
    }
}
public class WindowsOC:OperationController
{
    public override void ApplyMethod()
    {
        this.name = "WindowsOC";
        base.ApplyMethod();
    }
}
public class SymbianIC:InterfaceController
{
    public override void ApplyMethod()
    {
        this.name = "SymbianIC";
        base.ApplyMethod();
    }
}
public class AndroidIC:InterfaceController
{
    public override void ApplyMethod()
    {
        this.name = "AndroidIC";
        base.ApplyMethod();
    }
}
public class WindowsIC:InterfaceController
{
    public override void ApplyMethod()
    {
        this.name = "WindowsIC";
        base.ApplyMethod();
    }
}

public abstract class OSFactory
{
    public abstract OperationController CreatOC();
    public abstract InterfaceController CreatIC();
}

public class SymbianFactory : OSFactory
{
    public override OperationController CreatOC()
    {
        return new SymbianOC();
    }

    public override InterfaceController CreatIC()
    {
        return new SymbianIC();
    }
}
public class AndroidFactory : OSFactory
{
    public override OperationController CreatOC()
    {
        return new AndroidOC();
    }

    public override InterfaceController CreatIC()
    {
        return new AndroidIC();
    }
}
public class WindowsFactory : OSFactory
{
    public override OperationController CreatOC()
    {
        return new WindowsOC();
    }

    public override InterfaceController CreatIC()
    {
        return new WindowsIC();
    }
}
    

