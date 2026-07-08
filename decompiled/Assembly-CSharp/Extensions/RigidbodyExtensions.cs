using UnityEngine;

namespace Extensions;

public static class RigidbodyExtensions
{
	public static void ChangeDirection(this Rigidbody rigidbody, Vector3 direction)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		Vector3 velocity = rigidbody.velocity;
		rigidbody.velocity = direction * ((Vector3)(ref velocity)).magnitude;
	}
}
