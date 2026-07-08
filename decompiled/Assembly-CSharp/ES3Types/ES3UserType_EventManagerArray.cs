using ngov3;

namespace ES3Types;

public class ES3UserType_EventManagerArray : ES3ArrayType
{
	public static ES3Type Instance;

	public ES3UserType_EventManagerArray()
		: base(typeof(EventManager[]), ES3UserType_EventManager.Instance)
	{
		Instance = this;
	}
}
