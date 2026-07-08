using NGO;
using UnityEngine;

namespace ngov3;

public static class CommandHelper
{
	private static CommandMaster _commandMaster;

	private static ActMaster _ActMaster;

	public static CommandMaster getCommandMaster()
	{
		if ((Object)(object)_commandMaster == (Object)null)
		{
			_commandMaster = Resources.Load<CommandMaster>("Master/Command");
		}
		return _commandMaster;
	}

	public static string GetCommandTitle(CommandType type)
	{
		return getCommandMaster().CommandList.Find((Command j) => j.Id == type.ToString()).TitleJp;
	}

	public static string GetCommandTitle(CommandType type, LanguageType lang)
	{
		CommandMaster commandMaster = getCommandMaster();
		if (Object.op_Implicit((Object)(object)commandMaster))
		{
			switch (lang)
			{
			case LanguageType.JP:
				return commandMaster.CommandList.Find((Command j) => j.Id == type.ToString()).TitleJp;
			case LanguageType.CN:
				return commandMaster.CommandList.Find((Command j) => j.Id == type.ToString()).TitleCn;
			case LanguageType.KO:
			case LanguageType.TW:
			case LanguageType.VN:
			case LanguageType.FR:
			case LanguageType.IT:
			case LanguageType.GE:
			case LanguageType.SP:
			case LanguageType.RU:
				return "";
			default:
				return commandMaster.CommandList.Find((Command j) => j.Id == type.ToString()).TitleEn;
			}
		}
		return "null";
	}

	public static ActMaster getActMaster()
	{
		if ((Object)(object)_ActMaster == (Object)null)
		{
			_ActMaster = Resources.Load<ActMaster>("Master/Act");
		}
		return _ActMaster;
	}

	public static string GetCommandTitle(ActionType type, LanguageType lang)
	{
		ActMaster actMaster = getActMaster();
		if (Object.op_Implicit((Object)(object)actMaster))
		{
			return lang switch
			{
				LanguageType.JP => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleJp, 
				LanguageType.CN => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleCn, 
				LanguageType.KO => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleKo, 
				LanguageType.TW => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleTw, 
				LanguageType.VN => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleVn, 
				LanguageType.FR => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleFr, 
				LanguageType.IT => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleIt, 
				LanguageType.GE => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleGe, 
				LanguageType.SP => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleSp, 
				LanguageType.RU => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleRu, 
				_ => actMaster.param.Find((ActMaster.Param j) => j.Id == type.ToString()).TitleEn, 
			};
		}
		return "null";
	}
}
