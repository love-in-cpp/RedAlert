using UnityEngine;

// 这个模式实现的需求和模板方法模式实现的需求相同  纠结这两种模式还是看需求的侧重点吧 策略模式更多应用在数值的修改，而模板方法模式更多应用在流程的固定，关注点并不在于属性或字段，而在于方法。
public class StrategyPattern : MonoBehaviour
{
    private void Start()
    {
        var accountS = new AccountS();
        accountS.AccountStrategy = new CurrentAccountStrategy();
        accountS.Handle("LZY", "123");
    }
}

public class AccountS
{
    public AccountStrategy AccountStrategy { get; set; }

    private bool Validate(string account, string password)
    {
        Debug.LogFormat($"账户名:{account} 密码:{password}");
        if (account == "LZY" && password == "123")
            return true;
        return false;
    }

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

    private void CalculateInterest()
    {
        AccountStrategy.CalculateInterest();
    }
}

public abstract class AccountStrategy
{
    public abstract void CalculateInterest();
}

public class CurrentAccountStrategy : AccountStrategy
{
    public override void CalculateInterest()
    {
        Debug.Log("活期账户策略，按活期计算利息");
    }
}

public class SavingAccountStrategy : AccountStrategy
{
    public override void CalculateInterest()
    {
        Debug.Log("定期账户策略：按定期计算利息！");
    }
}