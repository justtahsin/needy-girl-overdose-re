using System.Collections.Generic;
using UniRx;
using UnityEngine.Scripting;
using ngov3;

namespace ES3Types;

[Preserve]
[ES3Properties(new string[] { "commandStatus" })]
public class ES3UserType_CommandManager : ES3ComponentType
{
	public static ES3Type Instance;

	public ES3UserType_CommandManager()
		: base(typeof(CommandManager))
	{
		Instance = this;
		priority = 1;
	}

	protected override void WriteComponent(object obj, ES3Writer writer)
	{
		CommandManager commandManager = (CommandManager)obj;
		writer.WriteProperty("commandStatus", commandManager.commandStatus);
	}

	protected override void ReadComponent<T>(ES3Reader reader, object obj)
	{
		CommandManager commandManager = (CommandManager)obj;
		foreach (string property in reader.Properties)
		{
			if (property == "commandStatus")
			{
				commandManager.commandStatus = reader.Read<ReactiveProperty<Dictionary<ActionType, ActionStatus>>>();
			}
			else
			{
				reader.Skip();
			}
		}
	}
}
