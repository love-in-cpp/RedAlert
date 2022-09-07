using System;
using System.Collections.Generic;
using UnityEngine;

public class MementoPattern:MonoBehaviour
{
    private void Start()
    {
        int index = -1; // 记录撤销到哪步的指针
        ChessmanCaretaker caretaker = new ChessmanCaretaker();
        Chessman chessman = new Chessman("車", 1, 1);
        Play(ref index, chessman,caretaker);
        chessman.X = 8;
        Play(ref index, chessman,caretaker);
        chessman.X = 9;
        Play(ref index, chessman,caretaker);
        chessman.Y = 12;
        Play(ref index, chessman,caretaker);
        chessman.X = 89;
        Play(ref index, chessman,caretaker);
        
        Undo(ref index, chessman,caretaker);
        Undo(ref index, chessman,caretaker);
        Redo(ref index, chessman,caretaker);
        Redo(ref index, chessman,caretaker);
        Redo(ref index, chessman,caretaker);
        Undo(ref index, chessman,caretaker);
        Undo(ref index, chessman,caretaker);
        Undo(ref index, chessman,caretaker);
        Undo(ref index, chessman,caretaker);
        Undo(ref index, chessman,caretaker);
        Undo(ref index, chessman,caretaker);
    }

    private void Play(ref int index, Chessman chessman, ChessmanCaretaker caretaker)
    {
        index++;
        caretaker.Set(chessman.Save());
        Debug.Log("棋子" + chessman.Name+ "当前位置为：" + "第" + chessman.X + "行" + "第" + chessman.Y + "列。");
    }
    
    private void Undo(ref int index, Chessman chessman, ChessmanCaretaker caretaker)
    {
        if (caretaker.Get(index - 1) is null)
        {
            Debug.Log("已不能再悔棋");
            return;
        }
        Debug.Log("******悔棋******");
        index--;
        chessman.Restore(caretaker.Get(index));
        Debug.Log("棋子" + chessman.Name+ "当前位置为：" + "第" + chessman.X + "行" + "第" + chessman.Y + "列。");
        
    }

    private void Redo(ref int index, Chessman chessman, ChessmanCaretaker caretaker)
    {
        if (caretaker.Get(index + 1) is null)
        {
            Debug.Log("已不能再撤销悔棋");
            return;
        }
        Debug.Log("******撤销悔棋******");
        index++;
        chessman.Restore(caretaker.Get(index));
        Debug.Log("棋子" + chessman.Name+ "当前位置为：" + "第" + chessman.X + "行" + "第" + chessman.Y + "列。");
    }
    
}

class Chessman
{
    private string _name;
    public string Name => _name;
    public Chessman(string name, int x, int y)
    {
        _name = name;
        X = x;
        Y = y;
    }
    public int X { get; set; }
    public int Y { get; set; }

    public ChessmanMemento Save()
    {
        return new ChessmanMemento(_name, X, Y);
    }

    public void Restore(ChessmanMemento memento)
    {
        _name = memento.Name;
        X = memento.X;
        Y = memento.Y;
    }
    internal class ChessmanMemento
    {
        public string Name { get; set; }

        public ChessmanMemento(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}



public class ChessmanCaretaker
{
    private List<Chessman.ChessmanMemento> _memento;

    public ChessmanCaretaker()
    {
        _memento = new List<Chessman.ChessmanMemento>();
    }
    
    internal Chessman.ChessmanMemento Get(int index)
    {
        if (index > 0 && index < _memento.Count)
        {
            return _memento[index];
        }

        return null;
    }

    internal void Set(Chessman.ChessmanMemento memento)
    {
        _memento.Add(memento);
    }
    
}