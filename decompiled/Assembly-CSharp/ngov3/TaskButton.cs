using System;
using System.Threading;
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
		bg = ((Component)this).GetComponent<Image>();
		button = ((Component)this).GetComponent<Button>();
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(button), (Action<Unit>)delegate
		{
			Touched();
		}), (Component)(object)button);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)async delegate
		{
			await UniTask.Delay(3, false, (PlayerLoopTiming)8, default(CancellationToken), false);
			SetName(window);
		}), (Component)(object)button);
		if ((Object)(object)SingletonMonoBehaviour<TaskbarManager>.Instance != (Object)null)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(ObserveExtensions.ObserveEveryValueChanged<CanvasGroup, bool>(SingletonMonoBehaviour<TaskbarManager>.Instance.TaskBarGroup, (Func<CanvasGroup, bool>)((CanvasGroup x) => x.interactable), (FrameCountType)0, false), (Action<bool>)delegate(bool x)
			{
				ChangeButtonColor(x);
			}), (Component)(object)this);
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
		Object.Destroy((Object)(object)((Component)this).gameObject);
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
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		ColorBlock colors;
		if (isEnabled)
		{
			Image image = ((Selectable)button).image;
			colors = ((Selectable)button).colors;
			((Graphic)image).color = ((ColorBlock)(ref colors)).normalColor;
		}
		else
		{
			Image image2 = ((Selectable)button).image;
			colors = ((Selectable)button).colors;
			((Graphic)image2).color = ((ColorBlock)(ref colors)).disabledColor;
		}
	}
}
