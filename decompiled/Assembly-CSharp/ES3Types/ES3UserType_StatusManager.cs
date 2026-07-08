using System.Collections.Generic;
using UnityEngine.Scripting;
using ngov3;

namespace ES3Types;

[Preserve]
[ES3Properties(new string[] { "statuses" })]
public class ES3UserType_StatusManager : ES3ComponentType
{
	public static ES3Type Instance;

	public ES3UserType_StatusManager()
		: base(typeof(StatusManager))
	{
		Instance = this;
		priority = 1;
	}

	protected override void WriteComponent(object obj, ES3Writer writer)
	{
		StatusManager statusManager = (StatusManager)obj;
		writer.WriteProperty("statuses", statusManager.statuses);
	}

	protected override void ReadComponent<T>(ES3Reader reader, object obj)
	{
		StatusManager statusManager = (StatusManager)obj;
		foreach (string property in reader.Properties)
		{
			if (property == "statuses")
			{
				statusManager.statuses = reader.Read<List<Status>>();
			}
			else
			{
				reader.Skip();
			}
		}
	}
}
