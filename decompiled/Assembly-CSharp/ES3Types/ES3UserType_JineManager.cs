using System.Collections.Generic;
using UnityEngine.Scripting;
using ngov3;

namespace ES3Types;

[ES3Properties(new string[] { "history" })]
[Preserve]
public class ES3UserType_JineManager : ES3ComponentType
{
	public static ES3Type Instance;

	public ES3UserType_JineManager()
		: base(typeof(JineManager))
	{
		Instance = this;
		priority = 1;
	}

	protected override void WriteComponent(object obj, ES3Writer writer)
	{
		JineManager jineManager = (JineManager)obj;
		writer.WriteProperty("history", jineManager.history);
	}

	protected override void ReadComponent<T>(ES3Reader reader, object obj)
	{
		JineManager jineManager = (JineManager)obj;
		foreach (string property in reader.Properties)
		{
			if (property == "history")
			{
				jineManager.history = reader.Read<List<JineData>>();
			}
			else
			{
				reader.Skip();
			}
		}
	}
}
