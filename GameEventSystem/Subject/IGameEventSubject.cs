using System.Collections.Generic;

public abstract class IGameEventSubject
{
    private List<IGameEventObserver> mObservers = new List<IGameEventObserver>();

    public void RegisterObserver(IGameEventObserver ob)
    {
        mObservers.Add(ob);
    }

    public void RemoveObserver(IGameEventObserver ob)
    {
        mObservers.Remove(ob);
    }

    public void Notify()
    {
        foreach (var ob in mObservers)
        {
            ob.Update();
        }
    }
    
}