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
		foreach (Transform item in transform)
		{
			item.position = Vector3.zero;
			if (recursive)
			{
				item.ResetChildPositions(recursive);
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
		foreach (Transform item in transform)
		{
			item.gameObject.layer = layer;
			if (recursive)
			{
				SetChildLayersHelper(item, layer, recursive);
			}
		}
	}

	public static void SetX(this Transform transform, float x)
	{
		transform.position = new Vector3(x, transform.position.y, transform.position.z);
	}

	public static void SetY(this Transform transform, float y)
	{
		transform.position = new Vector3(transform.position.x, y, transform.position.z);
	}

	public static void SetZ(this Transform transform, float z)
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, z);
	}
}
