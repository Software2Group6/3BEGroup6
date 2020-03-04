using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Part
{
	private string code;
	private string name;
	private double price;
	private PrefPart prefPart;

	public Part(string code, string name, double price, PrefPart prefPart)
	{
		this.code = code;
		this.name = name;
		this.price = price;
		this.prefPart = prefPart;
	}

}