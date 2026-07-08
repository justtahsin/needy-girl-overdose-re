using System.Collections.Generic;
using UnityEngine;

namespace Extensions;

public static class Vector3Extensions
{
	public static Vector3 GetClosest(this Vector3 position, IEnumerable<Vector3> otherPositions)
	{
		Vector3 result = Vector3.zero;
		float num = float.PositiveInfinity;
		foreach (Vector3 otherPosition in otherPositions)
		{
			float sqrMagnitude = (position - otherPosition).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				result = otherPosition;
				num = sqrMagnitude;
			}
		}
		return result;
	}
}
