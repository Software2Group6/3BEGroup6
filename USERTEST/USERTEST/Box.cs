using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Box
{
	private double[] dimensions;
	private int num;
	private string color;
	private string cups;
	private Inventory inventory;
	private string doorColor;

	public Box(int num, string doorColor, double[] dimensions, string color, Inventory inventory, string cups)
	{
		this.dimensions = dimensions;
		this.num = num;
		this.color = color;
		this.cups = cups;
		this.inventory = inventory;
		this.doorColor = doorColor;
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

	public string getDoorColor()
	{
		return doorColor;
	}

}
