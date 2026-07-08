using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MusicTitleMaster : ScriptableObject
{
	private enum ValueType
	{
		Id,
		Index,
		IsPlayable,
		BodyJp,
		BodyEn,
		BodyCn,
		FileName
	}

	[SerializeField]
	private List<MusicTitle> _MusicTitleList = new List<MusicTitle>();

	public List<MusicTitle> MusicTitleList => _MusicTitleList;

	public void SetData(string[] data)
	{
		List<MusicTitle> list = new List<MusicTitle>();
		MusicTitle musicTitle = new MusicTitle();
		int num = 0;
		for (int i = 0; i < 147; i++)
		{
			bool flag = false;
			if (i == 0 || num >= 7)
			{
				num = 0;
				musicTitle = new MusicTitle();
			}
			for (int j = 0; j < 7; j++)
			{
				if (!flag)
				{
					if (GetPrime(i, 7) == 0)
					{
						musicTitle.Id = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 7) == 1)
					{
						musicTitle.Index = int.Parse(data[i]);
						flag = true;
						num++;
					}
					else if (GetPrime(i, 7) == 2)
					{
						musicTitle.IsPlayable = bool.Parse(data[i]);
						flag = true;
						num++;
					}
					else if (GetPrime(i, 7) == 3)
					{
						musicTitle.BodyJp = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 7) == 4)
					{
						musicTitle.BodyEn = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 7) == 5)
					{
						musicTitle.BodyCn = data[i];
						flag = true;
						num++;
					}
					else if (GetPrime(i, 7) == 6)
					{
						musicTitle.FileName = data[i];
						flag = true;
						num++;
					}
				}
			}
			if (num == 6)
			{
				list.Add(musicTitle);
			}
		}
		_MusicTitleList = list;
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
