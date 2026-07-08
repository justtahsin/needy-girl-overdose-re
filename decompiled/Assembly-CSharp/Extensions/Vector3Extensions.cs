using System.Collections.Generic;
using UnityEngine;

namespace Extensions;

public static class Vector3Extensions
{
	public static Vector3 GetClosest(this Vector3 position, IEnumerable<Vector3> otherPositions)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		Vector3 result = Vector3.zero;
		float num = float.PositiveInfinity;
		foreach (Vector3 otherPosition in otherPositions)
		{
			Vector3 val = position - otherPosition;
			float sqrMagnitude = ((Vector3)(ref val)).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				result = otherPosition;
				num = sqrMagnitude;
			}
		}
		return result;
	}
}
