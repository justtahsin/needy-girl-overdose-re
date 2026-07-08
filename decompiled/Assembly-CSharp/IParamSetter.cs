using System.Collections.Generic;

public interface IParamSetter<T>
{
	void SetParam<T>(IEnumerable<T> newParams);
}
