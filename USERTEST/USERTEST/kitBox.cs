using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class kitBox
{
	private List<Box> boxList = new List<Box>();

	public kitBox(List<Box> lockerList)
	{
		this.boxList = boxList;
	}

	public void Add(Box a)
	{
		boxList.Add(a);
	}

	public int getLength()
	{
		return boxList.Count;
	}

	public List<double> getAllHeights()
	{
		List<double> allHeights = new List<double>();
		for (int i = 0; i < boxList.Count; i++)
		{
			allHeights.Add(boxList[i].getDimension(0));
		}
		return allHeights;
	}

	public List<string> getAllColors()
	{
		List<string> allColors = new List<string>();
		for (int i = 0; i < boxList.Count; i++)
		{
			allColors.Add(boxList[i].getCOlor());
		}
		return allColors;
	}

	public List<string> getAllDoorColors()
	{
		List<string> allColors = new List<string>();
		for (int i = 0; i < boxList.Count; i++)
		{
			allColors.Add(boxList[i].getDoorColor());
		}
		return allColors;
	}

	public List<string> getAllCups()
	{
		List<string> allCups = new List<string>();
		for (int i = 0; i < boxList.Count; i++)
		{
			allCups.Add(boxList[i].getCup());
		}
		return allCups;
	}

	public void Clear()
	{
		boxList.Clear();
	}

	public void RemoveAt(int a)
	{
		boxList.RemoveAt(a);
	}
}
