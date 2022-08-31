using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
// 作业

/*
public class CompositePattern:MonoBehaviour
{
    private void Start()
    {
    }
}
public abstract class ICompoment
{
    public abstract void Operation();
}

public abstract class UnitControl: ICompoment//控件
{
}

public class Button:UnitControl
{
    public override void Operation()
    {
    }
}

public class TextArea:UnitControl
{
    public override void Operation()
    {
    }
}

public abstract class Container:ICompoment
{
    protected List<Component> list;

    public void AddComponent(ICompoment component)
    {}

    public void DeleteComponent(ICompoment component)
    {}
    public void GetCompoment(int index)
    {}
    
}

public class Widget : Container
{
    public override void Operation()
    {
    }
}

public class MiddlePanel : Container
{
    public override void Operation()
    {
    }
}
*/

// 课程
public class CompositePattern:MonoBehaviour
{
    private void Start()
    {
        DMComposite root = new DMComposite("Root");

        DMLeaf leaf1 = new DMLeaf("GameObject");
        DMLeaf leaf2 = new DMLeaf("GameObject (2)");
        DMComposite gameObject1 = new DMComposite("GameObject (1)");
        
        root.AddChild(leaf1);
        root.AddChild(gameObject1);
        root.AddChild(leaf2);

        DMLeaf child1 = new DMLeaf("GameObject");
        DMLeaf child2 = new DMLeaf("GameObject (1)");
        gameObject1.AddChild(child1);
        gameObject1.AddChild(child2);
        ReadComponent(root);
    }

    private void ReadComponent(DMComponent component)
    {
        Debug.Log(component.name);
        List<DMComponent> children = component.children;
        if (children == null || children.Count == 0) return;
        foreach (var child in children)
        {
            ReadComponent(child);
        }

    }
} 

public abstract class DMComponent
{
    protected string mName; // name of GameObject
    public string name => mName;
    protected List<DMComponent> mChildren;
    public List<DMComponent> children => mChildren;

    public DMComponent(string name)
    {
        mChildren = new List<DMComponent>();
        mName = name;
    }

    public abstract void AddChild(DMComponent c);

    public abstract void RemoveChild(DMComponent c);

    public abstract DMComponent GetChild(int index);

}

public class DMLeaf : DMComponent
{
    public DMLeaf(string name) : base(name)
    {
    }

    public override void AddChild(DMComponent c)
    {
        
    }

    public override void RemoveChild(DMComponent c)
    {
    }

    public override DMComponent GetChild(int index)
    {
        return null;
    }
}

public class DMComposite : DMComponent
{
    public DMComposite(string name) : base(name)
    {
    }

    public override void AddChild(DMComponent c)
    {
        mChildren.Add(c);
    }

    public override void RemoveChild(DMComponent c)
    {
        mChildren.Remove(c);
    }

    public override DMComponent GetChild(int index)
    {
        return mChildren[index];
    }
}
