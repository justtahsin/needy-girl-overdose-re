using System;
using UnityEngine;

namespace Extensions;

public static class TransformExtensions
{
	public static void AddChildren(this Transform transform, GameObject[] children)
	{
		Array.ForEach(children, delegate(GameObject child)
		{
			child.transform.parent = transform;
		});
	}

	public static void AddChildren(this Transform transform, Component[] children)
	{
		Array.ForEach(children, delegate(Component child)
		{
			child.transform.parent = transform;
		});
	}

	public static void ResetChildPositions(this Transform transform, bool recursive = false)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		foreach (Transform item in transform)
		{
			Transform val = item;
			val.position = Vector3.zero;
			if (recursive)
			{
				val.ResetChildPositions(recursive);
			}
		}
	}

	public static void SetChildLayers(this Transform transform, string layerName, bool recursive = false)
	{
		int layer = LayerMask.NameToLayer(layerName);
		SetChildLayersHelper(transform, layer, recursive);
	}

	private static void SetChildLayersHelper(Transform transform, int layer, bool recursive)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		foreach (Transform item in transform)
		{
			Transform val = item;
			((Component)val).gameObject.layer = layer;
			if (recursive)
			{
				SetChildLayersHelper(val, layer, recursive);
			}
		}
	}

	public static void SetX(this Transform transform, float x)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		transform.position = new Vector3(x, transform.position.y, transform.position.z);
	}

	public static void SetY(this Transform transform, float y)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		transform.position = new Vector3(transform.position.x, y, transform.position.z);
	}

	public static void SetZ(this Transform transform, float z)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		transform.position = new Vector3(transform.position.x, transform.position.y, z);
	}
}
