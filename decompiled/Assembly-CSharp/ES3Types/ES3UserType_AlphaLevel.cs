using UnityEngine.Scripting;
using ngov3;

namespace ES3Types;

[Preserve]
[ES3Properties(new string[] { "alphaType", "level" })]
public class ES3UserType_AlphaLevel : ES3ObjectType
{
	public static ES3Type Instance;

	public ES3UserType_AlphaLevel()
		: base(typeof(AlphaLevel))
	{
		Instance = this;
		priority = 1;
	}

	protected override void WriteObject(object obj, ES3Writer writer)
	{
		AlphaLevel alphaLevel = (AlphaLevel)obj;
		writer.WriteProperty("alphaType", alphaLevel.alphaType);
		writer.WriteProperty("level", alphaLevel.level, ES3Type_int.Instance);
	}

	protected override void ReadObject<T>(ES3Reader reader, object obj)
	{
		AlphaLevel alphaLevel = (AlphaLevel)obj;
		foreach (string property in reader.Properties)
		{
			if (!(property == "alphaType"))
			{
				if (property == "level")
				{
					alphaLevel.level = reader.Read<int>(ES3Type_int.Instance);
				}
				else
				{
					reader.Skip();
				}
			}
			else
			{
				alphaLevel.alphaType = reader.Read<AlphaType>();
			}
		}
	}

	protected override object ReadObject<T>(ES3Reader reader)
	{
		AlphaLevel alphaLevel = new AlphaLevel();
		ReadObject<T>(reader, alphaLevel);
		return alphaLevel;
	}
}
