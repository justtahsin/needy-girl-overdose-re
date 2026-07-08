using UnityEngine;

namespace ES3Types;

public class ES3UserType_TransformArray : ES3ArrayType
{
	public static ES3Type Instance;

	public ES3UserType_TransformArray()
		: base(typeof(Transform[]), ES3UserType_Transform.Instance)
	{
		Instance = this;
	}
}
