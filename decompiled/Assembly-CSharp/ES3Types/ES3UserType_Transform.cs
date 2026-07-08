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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		Transform val = (Transform)obj;
		writer.WriteProperty("localPosition", val.localPosition, ES3Type_Vector3.Instance);
		writer.WriteProperty("localRotation", val.localRotation, ES3Type_Quaternion.Instance);
		writer.WriteProperty("localScale", val.localScale, ES3Type_Vector3.Instance);
		writer.WritePropertyByRef("parent", (Object)(object)val.parent);
	}

	protected override void ReadComponent<T>(ES3Reader reader, object obj)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		Transform val = (Transform)obj;
		foreach (string property in reader.Properties)
		{
			switch (property)
			{
			case "localPosition":
				val.localPosition = reader.Read<Vector3>(ES3Type_Vector3.Instance);
				break;
			case "localRotation":
				val.localRotation = reader.Read<Quaternion>(ES3Type_Quaternion.Instance);
				break;
			case "localScale":
				val.localScale = reader.Read<Vector3>(ES3Type_Vector3.Instance);
				break;
			case "parent":
				val.parent = reader.Read<Transform>(ES3Type_Transform.Instance);
				break;
			default:
				reader.Skip();
				break;
			}
		}
	}
}
