using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public class PrefPart
{
	private string color;
	private string name;
	private double dimension;

	public PrefPart(double dimension, string color, string name)
	{
		this.dimension = dimension;
		this.color = color;
		this.name = name;
	}

}
