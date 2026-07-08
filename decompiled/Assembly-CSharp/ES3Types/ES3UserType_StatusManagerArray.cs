using ngov3;

namespace ES3Types;

public class ES3UserType_StatusManagerArray : ES3ArrayType
{
	public static ES3Type Instance;

	public ES3UserType_StatusManagerArray()
		: base(typeof(StatusManager[]), ES3UserType_StatusManager.Instance)
	{
		Instance = this;
	}
}
