using System;using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
/*
使用简单工厂模式设计一个可以创建不同几何形状(如圆形、方形和三角形等)的绘图工具，
每个几何图形都具有绘制draw()和擦除Erase()两个方法，要求在绘制不支持的几何图形时，
提示一个UnSupportedShapeException。
 */
public class SimpleFactoryPattern:MonoBehaviour
{
    private void Start()
    {
        Shape shape;
        shape = ShapeFactory.CreatShape("Round");
        shape.Draw(new DrawLogger());
        shape.Erase(new EraseLogger());
    }

    private void Update()
    {
        
    }
}

public abstract class Shape
{
    public abstract void Draw(Logger logger);
    public abstract void Erase(Logger logger);

}

public class Round : Shape
{
    public override void Draw(Logger logger)
    {
        logger.Log("Round");
    }

    public override void Erase(Logger logger)
    {
        logger.Log("Round");
    }
}
public class Rectangle : Shape
{
    public override void Draw(Logger logger)
    {
        logger.Log("Rectangle");
    }

    public override void Erase(Logger logger)
    {
        logger.Log("Rectangle");
    }
}
public class Triangle : Shape
{
    public override void Draw(Logger logger)
    {
        logger.Log("Triangle");
    }

    public override void Erase(Logger logger)
    {
        logger.Log("Triangle");
    }
}

public class ShapeFactory
{
    public static Shape CreatShape(string shapeName)
    {
        Shape shape = null;
        switch (shapeName)
        {
            case "Round":
                shape = new Round();
                break;
            case "Rectangle":
                shape = new Rectangle();
                break;
            case "Triangle":
                shape = new Triangle();
                break;
        }
        return shape;
    }
}

public abstract class Logger
{
    public abstract void Log(string shapeName);
}

public class DrawLogger:Logger
{
    public override void Log(string shapeName)
    {
        Debug.Log("draw:"+ shapeName);
    }
}

public class EraseLogger : Logger
{
    public override void Log(string shapeName)
    {
        Debug.Log("erase: "+ shapeName);
    }
}