using System;
using UnityEngine;

public class CORPattern : MonoBehaviour
{
    private void Start()
    {
        int request = 31;
        Manager manager = new Manager(null);
        ViceManager viceManager = new ViceManager(manager);
        Director director = new Director(viceManager);
        
        director.Reply(31);
        director.Reply(25);
        director.Reply(5);
    }
}

public abstract class Approver
{
    protected Approver successor; //后继者
    public abstract void Reply(int days);
}
public class Director:Approver
{
    public Director(Approver successor)
    {
        this.successor = successor;
    }
    public override void Reply(int days)
    {
        if (days < 3)
        {
            Debug.Log("主任审批");
        }
        else
        {
            successor.Reply(days);
        }
    }
}
public class ViceManager:Approver
{
    public ViceManager(Approver successor)
    {
        this.successor = successor;
    }
    public override void Reply(int days)
    {
        if (days < 10)
        {
            Debug.Log("经理审批");
        }
        else
        {
            successor.Reply(days);
        }
    }
}
public class Manager:Approver
{
    public Manager(Approver successor)
    {
        this.successor = successor;
    }
    public override void Reply(int days)
    {
        Debug.Log(days < 30 ? "总经理审批" : "总经理审批不通过");
    }
}