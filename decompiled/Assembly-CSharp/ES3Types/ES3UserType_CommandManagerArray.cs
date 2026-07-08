using ngov3;

namespace ES3Types;

public class ES3UserType_CommandManagerArray : ES3ArrayType
{
	public static ES3Type Instance;

	public ES3UserType_CommandManagerArray()
		: base(typeof(CommandManager[]), ES3UserType_CommandManager.Instance)
	{
		Instance = this;
	}
}
