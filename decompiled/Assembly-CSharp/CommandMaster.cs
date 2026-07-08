using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CommandMaster : ScriptableObject
{
	private enum ValueType
	{
		Id,
		Summary,
		WindowId,
		ShortcutId,
		TitleJp,
		TitleEn,
		TitleCn,
		TitleKo,
		LineMidokuBehaviour,
		NeedDay,
		NeedEvent
	}

	[SerializeField]
	private List<Command> _CommandList = new List<Command>();

	public List<Command> CommandList => _CommandList;

	public void SetData(string[] data)
	{
		List<Command> list = new List<Command>();
		Command command = new Command();
		int num = 0;
		for (int i = 0; i < 560; i++)
		{
			bool flag = false;
			if (i == 0 || num >= 10)
			{
				num = 0;
				command = new Command();
			}
			for (int j = 0; j < 10; j++)
			{
				if (!flag)
				{
					if (GetPrime(i, 10) == 0)
					{
						command.Id = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 10) == 1)
					{
						command.Summary = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 10) == 2)
					{
						command.WindowId = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 10) == 3)
					{
						command.ShortcutId = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 10) == 4)
					{
						command.TitleJp = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 10) == 5)
					{
						command.TitleEn = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 10) == 6)
					{
						command.TitleCn = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 10) == 8)
					{
						command.LineMidokuBehaviour = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 10) == 9)
					{
						command.NeedDay = int.Parse(data[i]);
						flag = true;
						num++;
					}
					else if (GetPrime(i, 10) == 10)
					{
						command.NeedEvent = data[i];
						flag = true;
						num++;
					}
				}
			}
			if (num == 9)
			{
				list.Add(command);
			}
		}
		_CommandList = list;
	}

	private int GetPrime(int value, int length)
	{
		int num;
		for (num = value; num >= length; num -= length)
		{
		}
		return num;
	}
}
