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
	private string color;
	private Inventory inventory;
	private bool doors;

	public Locker(double[] dimensions, string color, Inventory inventory)
	{
		this.dimensions = dimensions;
		this.color = color;
		this.inventory = inventory;
		this.doors = doors;
	}



}
