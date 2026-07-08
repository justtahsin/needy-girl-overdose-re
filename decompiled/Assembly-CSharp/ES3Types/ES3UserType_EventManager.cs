using System.Collections.Generic;
using UnityEngine.Scripting;
using ngov3;

namespace ES3Types;

[Preserve]
[ES3Properties(new string[] { "eventsHistory", "loop", "midokumushi" })]
public class ES3UserType_EventManager : ES3ComponentType
{
	public static ES3Type Instance;

	public ES3UserType_EventManager()
		: base(typeof(EventManager))
	{
		Instance = this;
		priority = 1;
	}

	protected override void WriteComponent(object obj, ES3Writer writer)
	{
		EventManager eventManager = (EventManager)obj;
		writer.WriteProperty("eventsHistory", eventManager.eventsHistory);
		writer.WriteProperty("loop", eventManager.loop, ES3Type_int.Instance);
		writer.WriteProperty("midokumushi", eventManager.midokumushi, ES3Type_int.Instance);
	}

	protected override void ReadComponent<T>(ES3Reader reader, object obj)
	{
		EventManager eventManager = (EventManager)obj;
		foreach (string property in reader.Properties)
		{
			switch (property)
			{
			case "eventsHistory":
				eventManager.eventsHistory = reader.Read<List<string>>();
				break;
			case "loop":
				eventManager.loop = reader.Read<int>(ES3Type_int.Instance);
				break;
			case "midokumushi":
				eventManager.midokumushi = reader.Read<int>(ES3Type_int.Instance);
				break;
			default:
				reader.Skip();
				break;
			}
		}
	}
}
