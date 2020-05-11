using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Locker
{
	private double[] dimensions;
	private int num;
	private string color;
	private Inventory inventory;
	private bool doors;

	public Locker(int num, bool doors, double[] dimensions, string color, Inventory inventory)
	{
		this.dimensions = dimensions;
		this.num = num;
		this.color = color;
		this.inventory = inventory;
		this.doors = doors;
	}

	public int getNum()
	{
		return num;
	}

	public double getDimension(int a)
	{
		return dimensions[a];
	}

	public string getCOlor()
	{
		return color;
	}

	public bool getDoor()
	{
		return doors;
	}

}
