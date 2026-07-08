using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types;

[ES3Properties(new string[] { "localPosition", "localRotation", "localScale", "parent" })]
[Preserve]
public class ES3UserType_Transform : ES3ComponentType
{
	public static ES3Type Instance;

	public ES3UserType_Transform()
		: base(typeof(Transform))
	{
		Instance = this;
		priority = 1;
	}

	protected override void WriteComponent(object obj, ES3Writer writer)
	{
		Transform transform = (Transform)obj;
		writer.WriteProperty("localPosition", transform.localPosition, ES3Type_Vector3.Instance);
		writer.WriteProperty("localRotation", transform.localRotation, ES3Type_Quaternion.Instance);
		writer.WriteProperty("localScale", transform.localScale, ES3Type_Vector3.Instance);
		writer.WritePropertyByRef("parent", transform.parent);
	}

	protected override void ReadComponent<T>(ES3Reader reader, object obj)
	{
		Transform transform = (Transform)obj;
		foreach (string property in reader.Properties)
		{
			switch (property)
			{
			case "localPosition":
				transform.localPosition = reader.Read<Vector3>(ES3Type_Vector3.Instance);
				break;
			case "localRotation":
				transform.localRotation = reader.Read<Quaternion>(ES3Type_Quaternion.Instance);
				break;
			case "localScale":
				transform.localScale = reader.Read<Vector3>(ES3Type_Vector3.Instance);
				break;
			case "parent":
				transform.parent = reader.Read<Transform>(ES3Type_Transform.Instance);
				break;
			default:
				reader.Skip();
				break;
			}
		}
	}
}
