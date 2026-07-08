using NGO;
using UnityEngine.Scripting;
using ngov3;

namespace ES3Types;

[Preserve]
[ES3Properties(new string[] { "user", "id", "responseType", "stampType", "day", "freeMessage" })]
public class ES3UserType_JineData : ES3ObjectType
{
	public static ES3Type Instance;

	public ES3UserType_JineData()
		: base(typeof(JineData))
	{
		Instance = this;
		priority = 1;
	}

	protected override void WriteObject(object obj, ES3Writer writer)
	{
		JineData jineData = (JineData)obj;
		writer.WriteProperty("user", jineData.user);
		writer.WriteProperty("id", jineData.id);
		writer.WriteProperty("responseType", jineData.responseType);
		writer.WriteProperty("stampType", jineData.stampType);
		writer.WriteProperty("day", jineData.day, ES3Type_int.Instance);
		writer.WriteProperty("freeMessage", jineData.freeMessage, ES3Type_string.Instance);
	}

	protected override void ReadObject<T>(ES3Reader reader, object obj)
	{
		JineData jineData = (JineData)obj;
		foreach (string property in reader.Properties)
		{
			switch (property)
			{
			case "user":
				jineData.user = reader.Read<JineUserType>();
				break;
			case "id":
				jineData.id = reader.Read<JineType>();
				break;
			case "responseType":
				jineData.responseType = reader.Read<ResponseType>();
				break;
			case "stampType":
				jineData.stampType = reader.Read<StampType>();
				break;
			case "day":
				jineData.day = reader.Read<int>(ES3Type_int.Instance);
				break;
			case "freeMessage":
				jineData.freeMessage = reader.Read<string>(ES3Type_string.Instance);
				break;
			default:
				reader.Skip();
				break;
			}
		}
	}

	protected override object ReadObject<T>(ES3Reader reader)
	{
		JineData jineData = new JineData();
		ReadObject<T>(reader, jineData);
		return jineData;
	}
}
