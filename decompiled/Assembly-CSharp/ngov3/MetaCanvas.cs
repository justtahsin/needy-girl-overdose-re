using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class MetaCanvas : SingletonMonoBehaviour<MetaCanvas>
{
	[SerializeField]
	private Button _button_1;

	[SerializeField]
	private Button _button_2;

	public Button Button_1 => _button_1;

	public Button Button_2 => _button_2;

	public bool IsShowing
	{
		get
		{
			if (!_button_1.gameObject.activeInHierarchy)
			{
				return _button_2.gameObject.activeInHierarchy;
			}
			return true;
		}
	}

	public List<GameObject> SelectableObjects
	{
		get
		{
			List<GameObject> list = new List<GameObject>();
			if (_button_1.gameObject.activeInHierarchy)
			{
				list.Add(_button_1.gameObject);
			}
			if (_button_2.gameObject.activeInHierarchy)
			{
				list.Add(_button_2.gameObject);
			}
			return list;
		}
	}
}
