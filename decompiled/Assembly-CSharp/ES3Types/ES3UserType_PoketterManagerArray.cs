using ngov3;

namespace ES3Types;

public class ES3UserType_PoketterManagerArray : ES3ArrayType
{
	public static ES3Type Instance;

	public ES3UserType_PoketterManagerArray()
		: base(typeof(PoketterManager[]), ES3UserType_PoketterManager.Instance)
	{
		Instance = this;
	}
}
