using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class SheetView : MonoBehaviour
{
	[Serializable]
	private sealed class TweenSetting
	{
		public int DurationMilliSeconds = 50;

		public int Power = 10;

		public int ShakeCount = 2;
	}

	[SerializeField]
	private TweenSetting _tweenSetting;

	private Sequence _sequence;

	[SerializeField]
	protected RectTransform _tabletRoot;

	[SerializeField]
	private Button _sheet;

	[SerializeField]
	protected List<TabletView> _tablets = new List<TabletView>();

	[SerializeField]
	protected Button _tekiryouButton;

	[SerializeField]
	protected Button _odButton;

	[SerializeField]
	protected int _tekiryou = 2;

	protected IntReactiveProperty _currentDoseCount = new IntReactiveProperty(0);

	public IReactiveProperty<int> CurrentDoseCount => (IReactiveProperty<int>)(object)_currentDoseCount;

	protected virtual void Start()
	{
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(OnDosed(), (Action<bool>)delegate
		{
			IntReactiveProperty currentDoseCount = _currentDoseCount;
			int value = ((ReactiveProperty<int>)(object)currentDoseCount).Value;
			((ReactiveProperty<int>)(object)currentDoseCount).Value = value + 1;
		}), ((Component)this).gameObject);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>((IObservable<int>)_currentDoseCount, (Action<int>)delegate(int count)
		{
			FetchOverDose(count);
		}), ((Component)this).gameObject);
		((Component)_tekiryouButton).gameObject.SetActive(false);
		((Component)_odButton).gameObject.SetActive(false);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_sheet), (Action<Unit>)delegate
		{
			OnDose();
		}), (Component)(object)this);
	}

	private TabletView NextTablet()
	{
		if (((ReactiveProperty<int>)(object)_currentDoseCount).Value >= _tablets.Count)
		{
			return null;
		}
		return _tablets[((ReactiveProperty<int>)(object)_currentDoseCount).Value];
	}

	public virtual void OnDose()
	{
		TabletView tabletView = NextTablet();
		if (tabletView != null)
		{
			((Component)tabletView).gameObject.SetActive(false);
		}
		Shake();
		AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
		IntReactiveProperty currentDoseCount = _currentDoseCount;
		int value = ((ReactiveProperty<int>)(object)currentDoseCount).Value;
		((ReactiveProperty<int>)(object)currentDoseCount).Value = value + 1;
		SingletonMonoBehaviour<VibrationInputManager>.Instance.Vibrate(0.1f, 0.5f, 50f, 0.25f);
	}

	protected virtual IObservable<bool> OnDosed()
	{
		return Observable.Where<bool>(Observable.Merge<bool>((IEnumerable<IObservable<bool>>)_tablets.Select((TabletView t) => t.HasDosed)), (Func<bool, bool>)((bool t) => t));
	}

	private void FetchOverDose(int count)
	{
		if (count < _tekiryou)
		{
			((Component)_tekiryouButton).gameObject.SetActive(false);
			((Component)this).GetComponent<TooltipCaller>().type = TooltipType.System_Clickme;
		}
		else if (count == _tekiryou)
		{
			((Component)_tekiryouButton).gameObject.SetActive(true);
			((Component)this).GetComponent<TooltipCaller>().type = TooltipType.Tooltip_more;
		}
		else if (count > _tekiryou)
		{
			((Component)_tekiryouButton).gameObject.SetActive(false);
			((Component)_odButton).gameObject.SetActive(true);
		}
	}

	private void Shake()
	{
		Sequence sequence = _sequence;
		if (sequence == null || !TweenExtensions.IsPlaying((Tween)(object)sequence))
		{
			_sequence = TweenSettingsExtensions.SetLoops<Sequence>(TweenSettingsExtensions.SetRelative<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(TweenSettingsExtensions.Append(DOTween.Sequence(), (Tween)(object)DOTweenModuleUI.DOAnchorPosY(_tabletRoot, (float)(-_tweenSetting.Power), (float)_tweenSetting.DurationMilliSeconds * 0.001f, true)), (Tween)(object)DOTweenModuleUI.DOAnchorPosY(_tabletRoot, (float)(_tweenSetting.Power * 2), (float)_tweenSetting.DurationMilliSeconds * 0.001f, true)), (Tween)(object)DOTweenModuleUI.DOAnchorPosY(_tabletRoot, (float)(-_tweenSetting.Power), (float)_tweenSetting.DurationMilliSeconds * 0.001f, true))), _tweenSetting.ShakeCount);
			TweenExtensions.Play<Sequence>(TweenSettingsExtensions.SetAutoKill<Sequence>(_sequence, false));
		}
	}
}
