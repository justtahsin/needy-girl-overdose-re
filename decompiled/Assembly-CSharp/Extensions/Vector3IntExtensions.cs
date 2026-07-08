using System;
using UnityEngine;

namespace Extensions;

public static class Vector3IntExtensions
{
	public static Vector3 ToVector3(this Vector3Int vector)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		return new Vector3(Convert.ToSingle(((Vector3Int)(ref vector)).x), Convert.ToSingle(((Vector3Int)(ref vector)).y), Convert.ToSingle(((Vector3Int)(ref vector)).z));
	}
}
