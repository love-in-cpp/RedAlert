using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandPattern : MonoBehaviour
{
    private void Start()
    {
        BoardScreen boardScreen = new BoardScreen();
        Menu menu = new Menu();

        MenuItem menuItem1 = new MenuItem(new OpenCommand(boardScreen));
        MenuItem menuItem2 = new MenuItem(new OpenCommand(boardScreen));
        menu.AddMenuItem(menuItem1);
        menu.AddMenuItem(menuItem2);
        
        menu.ExecItem();
        
    }
}

public class BoardScreen
{
    public string Name { get; set; }
    public void Open()
    {
        Name = "BoardScreen";
        Debug.Log(Name +" is open");
    }

    public void Create()
    {
        // 省时间不想创建其他类了
    }

    public void Edit()
    {
        
    }
}

public class Menu
{
    public string Name { get; set; }
    private readonly List<MenuItem> _menuItem = new List<MenuItem>();
    private static int _count = 0;

    public void AddMenuItem(MenuItem menuItem)
    {
        _menuItem.Add(menuItem);
        menuItem.Name = "MenuItem" + _count;
        _count++;
    }

    public void ExecItem()
    {
        foreach (var menuItem in _menuItem)
        {
            menuItem.OnClick();
        }
    }
}

public class MenuItem
{
    public string Name { get; set; }

    private AbstractCommand _abstractCommand;

    public MenuItem(AbstractCommand command)
    {
        _abstractCommand = command;
    }

    public AbstractCommand AbstractCommand
    {
        set => _abstractCommand = value;
    }
    public void OnClick()
    {
        Debug.Log(Name + " is clicked");
        _abstractCommand.Execute();
    }
}

public abstract class AbstractCommand
{
    public abstract void Execute();
}

public class OpenCommand : AbstractCommand
{
    private readonly BoardScreen _screen;

    public OpenCommand(BoardScreen screen)
    {
        _screen = screen;
    }
    public override void Execute()
    {
        _screen.Open();
    }
}


