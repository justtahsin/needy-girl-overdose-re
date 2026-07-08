using ngov3;

namespace ES3Types;

public class ES3UserType_JineDataArray : ES3ArrayType
{
	public static ES3Type Instance;

	public ES3UserType_JineDataArray()
		: base(typeof(JineData[]), ES3UserType_JineData.Instance)
	{
		Instance = this;
	}
}
