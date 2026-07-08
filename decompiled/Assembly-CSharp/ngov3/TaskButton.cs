using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

[Serializable]
public class TaskButton : MonoBehaviour
{
	public IWindow window;

	[SerializeField]
	private TMP_Text _title;

	private Button button;

	private Image bg;

	[SerializeField]
	private Sprite Content;

	[SerializeField]
	private Sprite Empty;

	private void Awake()
	{
		bg = GetComponent<Image>();
		button = GetComponent<Button>();
		button.OnClickAsObservable().Subscribe(delegate
		{
			Touched();
		}).AddTo(button);
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(async delegate
		{
			await UniTask.Delay(3);
			SetName(window);
		}).AddTo(button);
		if (SingletonMonoBehaviour<TaskbarManager>.Instance != null)
		{
			SingletonMonoBehaviour<TaskbarManager>.Instance.TaskBarGroup.ObserveEveryValueChanged((CanvasGroup x) => x.interactable).Subscribe(delegate(bool x)
			{
				ChangeButtonColor(x);
			}).AddTo(this);
		}
	}

	public void setWindow(IWindow w)
	{
		window = w;
		SetName(w);
		Pop();
	}

	public void SetName(IWindow w)
	{
		_title.text = window.Wname;
	}

	public void Close()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void Minimize()
	{
		bg.sprite = Content;
	}

	public void Pop()
	{
		bg.sprite = Empty;
	}

	public void Touched()
	{
		if (window.windowState == WindowState.minimized)
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Pop(window);
		}
		else
		{
			SingletonMonoBehaviour<WindowManager>.Instance.Minimize(window);
		}
	}

	private void ChangeButtonColor(bool isEnabled)
	{
		if (isEnabled)
		{
			button.image.color = button.colors.normalColor;
		}
		else
		{
			button.image.color = button.colors.disabledColor;
		}
	}
}
