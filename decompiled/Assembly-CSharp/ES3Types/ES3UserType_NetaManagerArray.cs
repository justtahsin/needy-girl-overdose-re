using ngov3;

namespace ES3Types;

public class ES3UserType_NetaManagerArray : ES3ArrayType
{
	public static ES3Type Instance;

	public ES3UserType_NetaManagerArray()
		: base(typeof(NetaManager[]), ES3UserType_NetaManager.Instance)
	{
		Instance = this;
	}
}
