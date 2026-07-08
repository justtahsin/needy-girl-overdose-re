using ngov3;

namespace ES3Types;

public class ES3UserType_SettingsArray : ES3ArrayType
{
	public static ES3Type Instance;

	public ES3UserType_SettingsArray()
		: base(typeof(Settings[]), ES3UserType_Settings.Instance)
	{
		Instance = this;
	}
}
