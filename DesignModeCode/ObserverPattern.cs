using System;
using System.Collections.Generic;
using UnityEngine;

public class ObserverPattern:MonoBehaviour
{
    private void Start()
    {
        var gpSystem = new GPSystem();
        var gp1 = new GP("股票A", 1);
        var gp2 = new GP("股票B", 3);
        var mouse1 = new GPBuyer("鼠鼠1", gpSystem);
        var mouse2 = new GPBuyer("鼠鼠2", gpSystem);

        gpSystem.AddGP(gp1).AddGP(gp2);

        mouse1.BuyGP(gp1);
        mouse2.BuyGP(gp2);
        mouse2.BuyGP(gp1);

        gp1.newPrice = 5f;
        gp2.newPrice = 7f;
        
        gpSystem.Notify();

    }
}

public abstract class ISubject
{
    protected List<IObserver> buyers;
    public abstract GPSystem AddBuyers(GPBuyer gpBuyer);
    public abstract void Notify();
}

public class GPSystem:ISubject
{
    private List<GP> gpList;
    public List<IObserver> Buyers => buyers;

    public GPSystem()
    {
        gpList = new List<GP>();
        buyers = new List<IObserver>();
    }

    public GPSystem AddGP(GP gp)
    {
        gpList.Add(gp);
        return this;
    }


    public override GPSystem AddBuyers(GPBuyer gpBuyer)
    {
        buyers.Add(gpBuyer);
        return this;
    }

    public override void Notify()
    {
        Debug.Log("-**********************股票系统：当前股民**********************-");
        foreach (var buyer in Buyers)
        {
            Debug.Log(buyer.name);
        }
        Debug.Log("-**********************分割线**********************-");
        foreach (var gp in gpList)
        {
            if (gp.newPrice >= gp.oldPrice*(1+0.05))
            {
                foreach (var observer in gp.buyers)
                {
                    observer.React(gp);
                }
            }
        }
    }
    
}

public abstract class IObserver
{
    public string name;
    public abstract void React(GP gp);
}

public class GPBuyer : IObserver
{
    
    private GPSystem gpSystem;

    public GPBuyer(string name, GPSystem gpSystem)
    {
        this.name = name;
        this.gpSystem = gpSystem;
    }
    public override void React(GP gp)
    {
        Debug.Log(name+" 收到了 " + gp.name + "的价格变更: " + gp.oldPrice + " => " + gp.newPrice);
    }

    public void BuyGP(GP gp)
    {
        Debug.Log(name+" 购买了 " + gp.name + "，价格为: " + gp.oldPrice);
        gp.buyers.Add(this);
        if (gpSystem.Buyers.Contains(this) is false)
        {
            gpSystem.Buyers.Add(this);
        }
        
    }
}

public class GP
{
    public string name { get; set; }
    public float oldPrice;

    private float _newPrice;
    public float newPrice
    {
        get { return _newPrice;}
        set
        {
            _newPrice = value;
            Debug.Log(name+" 的价格已更新：" + oldPrice + " => " + value);
        }
    }

    public List<GPBuyer> buyers;

    public GP(string name, float oldPrice)
    {
        buyers = new List<GPBuyer>();
        this.name = name;
        this.oldPrice = oldPrice;
        _newPrice = oldPrice;
    }
    
}
