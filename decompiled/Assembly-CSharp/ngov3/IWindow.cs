using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public interface IWindow : IScalable, IOpenable, IClosable, ISwitchableCloseState, IStateSwitchable, IUnityComponent, IStackable, ISwitchableMoveState
{
	AppType appType { get; set; }

	WindowState windowState { get; set; }

	GameObject nakamiApp { get; }

	ActiveState activeState { get; set; }

	string Wname { get; set; }

	Button _close { get; }

	Button _minimize { get; }

	Button _maximize { get; }

	void Touched();

	void Born();

	void setRandomPosition();

	void SetName(string name);

	void SetApp(AppTypeToData a);

	void SetCachedApp(AppTypeToData a);

	void SetStratchAble(bool active);
}
