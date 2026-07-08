using System.Collections.Generic;
using UnityEngine.Scripting;
using ngov3;

namespace ES3Types;

[ES3Properties(new string[] { "GotAlpha", "usedAlpha" })]
[Preserve]
public class ES3UserType_NetaManager : ES3ComponentType
{
	public static ES3Type Instance;

	public ES3UserType_NetaManager()
		: base(typeof(NetaManager))
	{
		Instance = this;
		priority = 1;
	}

	protected override void WriteComponent(object obj, ES3Writer writer)
	{
		NetaManager netaManager = (NetaManager)obj;
		writer.WriteProperty("GotAlpha", netaManager.GotAlpha);
		writer.WriteProperty("usedAlpha", netaManager.usedAlpha);
	}

	protected override void ReadComponent<T>(ES3Reader reader, object obj)
	{
		NetaManager netaManager = (NetaManager)obj;
		foreach (string property in reader.Properties)
		{
			if (!(property == "GotAlpha"))
			{
				if (property == "usedAlpha")
				{
					netaManager.usedAlpha = reader.Read<List<AlphaLevel>>();
				}
				else
				{
					reader.Skip();
				}
			}
			else
			{
				netaManager.GotAlpha = reader.Read<List<AlphaLevel>>();
			}
		}
	}
}
