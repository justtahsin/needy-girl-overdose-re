using UniRx;
using UnityEngine.Scripting;
using ngov3;

namespace ES3Types;

[Preserve]
[ES3Properties(new string[] { "CurrentLanguage", "BgmVolume", "SeVolume" })]
public class ES3UserType_Settings : ES3ComponentType
{
	public static ES3Type Instance;

	public ES3UserType_Settings()
		: base(typeof(Settings))
	{
		Instance = this;
		priority = 1;
	}

	protected override void WriteComponent(object obj, ES3Writer writer)
	{
		Settings settings = (Settings)obj;
		writer.WriteProperty("CurrentLanguage", settings.CurrentLanguage);
		writer.WriteProperty("BgmVolume", settings.BgmVolume, ES3Type_float.Instance);
		writer.WriteProperty("SeVolume", settings.SeVolume, ES3Type_float.Instance);
	}

	protected override void ReadComponent<T>(ES3Reader reader, object obj)
	{
		Settings settings = (Settings)obj;
		foreach (string property in reader.Properties)
		{
			switch (property)
			{
			case "CurrentLanguage":
				settings.CurrentLanguage = reader.Read<ReactiveProperty<LanguageType>>();
				break;
			case "BgmVolume":
				settings.BgmVolume = reader.Read<float>(ES3Type_float.Instance);
				break;
			case "SeVolume":
				settings.SeVolume = reader.Read<float>(ES3Type_float.Instance);
				break;
			default:
				reader.Skip();
				break;
			}
		}
	}
}
