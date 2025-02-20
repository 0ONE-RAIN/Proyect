using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public abstract class Entityes : ISubject
{
    public int X { get; set; }
    public int Y { get; set; }
    public Image Sprite { get; set; }
    private List<IObserver> observers = new List<IObserver>();

    public Entityes(int x, int y, Image sprite)
    {
        X = x;
        Y = y;
        Sprite = sprite;
    }

    public void AddObserver(IObserver observer) => observers.Add(observer);
    public void RemoveObserver(IObserver observer) => observers.Remove(observer);

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            if (observer is System.Windows.Forms.Control control && control.IsDisposed)
                continue;
            observer.Update(this);

        }
    }
    public void Notify()
    {
        foreach (var observer in observers)
        {
            if (observer is System.Windows.Forms.Control control && control.IsDisposed)
                continue;
            observer.Update(this);
        }
    }
}
