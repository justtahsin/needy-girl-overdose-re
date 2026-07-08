using System.Collections.Generic;
using UnityEngine.Scripting;
using ngov3;

namespace ES3Types;

[Preserve]
[ES3Properties(new string[] { "history" })]
public class ES3UserType_PoketterManager : ES3ComponentType
{
	public static ES3Type Instance;

	public ES3UserType_PoketterManager()
		: base(typeof(PoketterManager))
	{
		Instance = this;
		priority = 1;
	}

	protected override void WriteComponent(object obj, ES3Writer writer)
	{
		PoketterManager poketterManager = (PoketterManager)obj;
		writer.WriteProperty("history", poketterManager.history);
	}

	protected override void ReadComponent<T>(ES3Reader reader, object obj)
	{
		PoketterManager poketterManager = (PoketterManager)obj;
		foreach (string property in reader.Properties)
		{
			if (property == "history")
			{
				poketterManager.history = reader.Read<List<TweetData>>();
			}
			else
			{
				reader.Skip();
			}
		}
	}
}
