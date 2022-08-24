using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Transactions;
using UnityEngine;

public class FlyweightPattern:MonoBehaviour
{
    private void Start()
    {
        AbstractFLChess b1, b2, b3, w1, w2, w3;
        ChessFactory cs = ChessFactory.GetInstance();

        b1 = cs.GetChess("b");
        b2 = cs.GetChess("b");

        w1 = cs.GetChess("w");
        w2 = cs.GetChess("w");

        Debug.Log(b1==b2);
        Debug.Log(w1==w2);
        
        b1.Show(new Coordinates(3,4));
        w1.Show(new Coordinates(1,8));

    }
}

public abstract class AbstractFLChess
{
    protected string mColor; // 内部生成，唯一且不可更改
    public string color
    {
        get => mColor;
    }

    public void Show(Coordinates outsideVar)
    {
        Debug.Log("内部变量，颜色："+ color +" ; "+
                  "外部变量，坐标："+ "(" + outsideVar.x + ", " +outsideVar.y + ")");
    }
}

public class ConcreteFLBlackChess : AbstractFLChess
{
    public ConcreteFLBlackChess()
    {
        mColor = "black";
    }
}

public class ConcreteFLWhiteChess : AbstractFLChess
{
    public ConcreteFLWhiteChess()
    {
        mColor = "white";
    }
}

public class ChessFactory
{
    private static ChessFactory instance = new ChessFactory();
    private Hashtable hashtable; // 享元池
    
    private ChessFactory()
    {
        hashtable = new Hashtable();
        AbstractFLChess black = new ConcreteFLBlackChess();
        hashtable.Add("b",black);
        AbstractFLChess white = new ConcreteFLWhiteChess();
        hashtable.Add("w", white);
    }
    
    public static ChessFactory GetInstance()
    {
        return instance;
    }

    public AbstractFLChess GetChess(string color)
    {
        if (!hashtable.ContainsKey(color))
        {
            return null;
        }

        return (AbstractFLChess)hashtable[color];
    }
}
// 二维坐标类 ,外部注入
public class Coordinates
{
    public float x { get; set; }
    public float y { get; set; }

    public Coordinates(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}