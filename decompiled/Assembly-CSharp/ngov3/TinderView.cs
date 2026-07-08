using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class TinderView : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnChoosed_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public TinderView _003C_003E4__this;

		private void MoveNext()
		{
			TinderView tinderView = _003C_003E4__this;
			try
			{
				tinderView._buttonRoot.SetActive(false);
				TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)((Graphic)tinderView._Otoko1).rectTransform, 1080f, 0.5f, false));
				TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveY((Transform)(object)((Graphic)tinderView._Otoko2).rectTransform, 1080f, 0.5f, false));
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[SerializeField]
	private Image _Otoko1;

	[SerializeField]
	private Image _Otoko2;

	[SerializeField]
	private List<Sprite> _otoko = new List<Sprite>();

	[SerializeField]
	private GameObject _buttonRoot;

	[SerializeField]
	private Button _nope;

	[SerializeField]
	private Button _like;

	[SerializeField]
	private int otokoindex;

	private bool isOmote = true;

	public void OnLanguageUpdated(LanguageType lang)
	{
		((Component)_nope).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dinder_Nope, lang);
		((Component)_like).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Dinder_Like, lang);
	}

	public void Awake()
	{
	}

	protected void Start()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_nope), (Action<Unit>)delegate
		{
			ChangeOtoko();
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate(LanguageType lang)
		{
			OnLanguageUpdated(lang);
		}), ((Component)this).gameObject);
		_otoko = shuffleOtoko(_otoko);
		_Otoko1.sprite = _otoko[0];
		_Otoko2.sprite = _otoko[1];
	}

	private List<Sprite> shuffleOtoko(List<Sprite> aList)
	{
		Random random = new Random();
		int count = _otoko.Count;
		for (int i = 0; i < count; i++)
		{
			int index = i + (int)(random.NextDouble() * (double)(count - i));
			Sprite value = aList[index];
			aList[index] = aList[i];
			aList[i] = value;
		}
		return aList;
	}

	private async void ChangeOtoko()
	{
		await UniTask.Delay(10, false, (PlayerLoopTiming)8, default(CancellationToken), false);
		((Selectable)_nope).interactable = false;
		AudioManager.Instance.PlaySeByType(SoundType.SE_kuraiSelect);
		if (otokoindex + 3 > _otoko.Count)
		{
			otokoindex = 0;
			_otoko = shuffleOtoko(_otoko);
		}
		TweenAwaiter val;
		TweenAwaiter val2 = default(TweenAwaiter);
		if (isOmote)
		{
			val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)((Graphic)_Otoko1).rectTransform, -1920f, 0.8f, false)));
			if (!((TweenAwaiter)(ref val)).IsCompleted)
			{
				await val;
				val = val2;
				val2 = default(TweenAwaiter);
			}
			((TweenAwaiter)(ref val)).GetResult();
			((Component)_Otoko1).transform.SetAsFirstSibling();
			val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)((Graphic)_Otoko1).rectTransform, 0f, 0.1f, false)));
			if (!((TweenAwaiter)(ref val)).IsCompleted)
			{
				await val;
				val = val2;
			}
			((TweenAwaiter)(ref val)).GetResult();
			_Otoko1.sprite = _otoko[otokoindex + 2];
		}
		else
		{
			val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)((Graphic)_Otoko2).rectTransform, -1920f, 0.8f, false)));
			if (!((TweenAwaiter)(ref val)).IsCompleted)
			{
				await val;
				val = val2;
				val2 = default(TweenAwaiter);
			}
			((TweenAwaiter)(ref val)).GetResult();
			((Component)_Otoko2).transform.SetAsFirstSibling();
			val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<Vector3, Vector3, VectorOptions>>(ShortcutExtensions.DOLocalMoveX((Transform)(object)((Graphic)_Otoko2).rectTransform, 0f, 0.1f, false)));
			if (!((TweenAwaiter)(ref val)).IsCompleted)
			{
				await val;
				val = val2;
			}
			((TweenAwaiter)(ref val)).GetResult();
			_Otoko2.sprite = _otoko[otokoindex + 2];
		}
		isOmote = !isOmote;
		otokoindex++;
		((Selectable)_nope).interactable = true;
	}

	[AsyncStateMachine(typeof(_003COnChoosed_003Ed__13))]
	public UniTask OnChoosed()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003COnChoosed_003Ed__13 _003COnChoosed_003Ed__14 = default(_003COnChoosed_003Ed__13);
		_003COnChoosed_003Ed__14._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnChoosed_003Ed__14._003C_003E4__this = this;
		_003COnChoosed_003Ed__14._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnChoosed_003Ed__14._003C_003Et__builder)).Start<_003COnChoosed_003Ed__13>(ref _003COnChoosed_003Ed__14);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnChoosed_003Ed__14._003C_003Et__builder)).Task;
	}
}
