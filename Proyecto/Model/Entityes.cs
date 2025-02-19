using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

public abstract class Entityes : ISubject
{

	public int _PosX {  get; set; }
	public int _PosY { get; set; }
	public Image sprite { get; set; }
	private List<IObserver> observers = new List<IObserver>();

	public Entityes(int x, int y, Image sprites)
	{
		_PosX = x;
		_PosY = y;
		sprite = sprites;

	}

	public void AddObserver(IObserver observer) => observers.Add(observer);
	public void RemoveObserver(IObserver observer) => observers.Remove(observer);
	public void NotifyObservers()
	{
		foreach (var observer in observers)
		{
			observer.Update();

		}
	}




}
