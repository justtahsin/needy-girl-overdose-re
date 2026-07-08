using ngov3;

namespace ES3Types;

public class ES3UserType_JineManagerArray : ES3ArrayType
{
	public static ES3Type Instance;

	public ES3UserType_JineManagerArray()
		: base(typeof(JineManager[]), ES3UserType_JineManager.Instance)
	{
		Instance = this;
	}
}
