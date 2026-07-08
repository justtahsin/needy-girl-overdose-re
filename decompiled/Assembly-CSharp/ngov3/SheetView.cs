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

	public IReactiveProperty<int> CurrentDoseCount => _currentDoseCount;

	protected virtual void Start()
	{
		OnDosed().Subscribe(delegate
		{
			_currentDoseCount.Value++;
		}).AddTo(base.gameObject);
		_currentDoseCount.Subscribe(delegate(int count)
		{
			FetchOverDose(count);
		}).AddTo(base.gameObject);
		_tekiryouButton.gameObject.SetActive(value: false);
		_odButton.gameObject.SetActive(value: false);
		_sheet.OnClickAsObservable().Subscribe(delegate
		{
			OnDose();
		}).AddTo(this);
	}

	private TabletView NextTablet()
	{
		if (_currentDoseCount.Value >= _tablets.Count)
		{
			return null;
		}
		return _tablets[_currentDoseCount.Value];
	}

	public virtual void OnDose()
	{
		NextTablet()?.gameObject.SetActive(value: false);
		Shake();
		AudioManager.Instance.PlaySeByType(SoundType.SE_piporo);
		_currentDoseCount.Value++;
		SingletonMonoBehaviour<VibrationInputManager>.Instance.Vibrate(0.1f, 0.5f, 50f, 0.25f);
	}

	protected virtual IObservable<bool> OnDosed()
	{
		return from t in _tablets.Select((TabletView t) => t.HasDosed).Merge()
			where t
			select t;
	}

	private void FetchOverDose(int count)
	{
		if (count < _tekiryou)
		{
			_tekiryouButton.gameObject.SetActive(value: false);
			GetComponent<TooltipCaller>().type = TooltipType.System_Clickme;
		}
		else if (count == _tekiryou)
		{
			_tekiryouButton.gameObject.SetActive(value: true);
			GetComponent<TooltipCaller>().type = TooltipType.Tooltip_more;
		}
		else if (count > _tekiryou)
		{
			_tekiryouButton.gameObject.SetActive(value: false);
			_odButton.gameObject.SetActive(value: true);
		}
	}

	private void Shake()
	{
		Sequence sequence = _sequence;
		if (sequence == null || !sequence.IsPlaying())
		{
			_sequence = DOTween.Sequence().Append(_tabletRoot.DOAnchorPosY(-_tweenSetting.Power, (float)_tweenSetting.DurationMilliSeconds * 0.001f, snapping: true)).Append(_tabletRoot.DOAnchorPosY(_tweenSetting.Power * 2, (float)_tweenSetting.DurationMilliSeconds * 0.001f, snapping: true))
				.Append(_tabletRoot.DOAnchorPosY(-_tweenSetting.Power, (float)_tweenSetting.DurationMilliSeconds * 0.001f, snapping: true))
				.SetRelative()
				.SetLoops(_tweenSetting.ShakeCount);
			_sequence.SetAutoKill(autoKillOnCompletion: false).Play();
		}
	}
}
