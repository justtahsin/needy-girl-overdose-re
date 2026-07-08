using System.Collections.Generic;

namespace ngov3;

public class WindowManager_Day0 : WindowManager
{
	protected override void Awake()
	{
		_taskBarList = new List<TaskButton>();
	}
}
