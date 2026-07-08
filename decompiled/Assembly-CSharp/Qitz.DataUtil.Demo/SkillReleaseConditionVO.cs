using System;
using UnityEngine;

namespace Qitz.DataUtil.Demo;

[Serializable]
public class SkillReleaseConditionVO
{
	[SerializeField]
	private int id;

	[SerializeField]
	private string unique_name;

	[SerializeField]
	private int value;

	[SerializeField]
	private string type;

	public int Id => id;

	public string UniqueName => unique_name;

	public int Value => value;

	public string Type => type;
}
