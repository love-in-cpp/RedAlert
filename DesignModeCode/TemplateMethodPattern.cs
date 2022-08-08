using System;
using UnityEngine;

public class TemplateMethodPattern : MonoBehaviour
{
    private void Start()
    {
        // Account account = new CurrentAccount();
        // account.Handle("LZY","123");

        Account account2 = new SavingAccount();
        var a = account2.GetType();

        var o = Activator.CreateInstance(a);
        var handle = a.GetMethod("Handle");
        handle.Invoke(o, new object[] { "LZY", "123" });
    }
}

public abstract class Account
{
    private bool Validate(string account, string password)
    {
        Debug.LogFormat($"账户名:{account} 密码:{password}");
        if (account == "LZY" && password == "123")
            return true;
        return false;
    }

    protected abstract void CalculateInterest();

    private void Display()
    {
        Debug.Log("利息为：");
    }

    public virtual void Handle(string account, string password)
    {
        if (!Validate(account, password))
        {
            Debug.LogFormat("账户名或密码错误！");
            return;
        }

        CalculateInterest();
        Display();
    }
}

internal class CurrentAccount : Account
{
    protected override void CalculateInterest()
    {
        Debug.Log("按活期计算利息！");
    }
}

internal class SavingAccount : Account
{
    protected override void CalculateInterest()
    {
        Debug.Log("按定期计算利息！");
    }
}