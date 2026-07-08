using ngov3;

namespace ES3Types;

public class ES3UserType_AlphaLevelArray : ES3ArrayType
{
	public static ES3Type Instance;

	public ES3UserType_AlphaLevelArray()
		: base(typeof(AlphaLevel[]), ES3UserType_AlphaLevel.Instance)
	{
		Instance = this;
	}
}
