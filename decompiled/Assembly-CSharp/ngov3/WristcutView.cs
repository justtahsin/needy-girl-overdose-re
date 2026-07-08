using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public sealed class WristcutView : MonoBehaviour
{
	[SerializeField]
	private float _targetY;

	[SerializeField]
	private Image _kizuPrefab;

	[SerializeField]
	private Image _bar;

	[SerializeField]
	public Button _goButton;

	[SerializeField]
	private TMP_Text _goButtonT;

	public ActionButton _finishButton;

	[SerializeField]
	private RectTransform _root;

	private Subject<Cut> _onGoButton = new Subject<Cut>();

	private Sequence _barMove;

	public IObservable<Cut> OnGoButton => _onGoButton;

	public void OnStartGame(int day, int cutCount)
	{
		_goButtonT.text = NgoEx.SystemTextFromType(SystemTextType.WristGO, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		MoveBar();
		_ = cutCount;
		_goButton.OnClickAsObservable().Take(cutCount).Subscribe((Action<Unit>)delegate
		{
			OnGo(day);
			cutCount--;
			_goButtonT.text = cutCount.ToString();
		}, (Action)delegate
		{
			OnGo(day);
			OnCompleted().Forget();
		})
			.AddTo(base.gameObject);
	}

	private void MoveBar()
	{
		_barMove = DOTween.Sequence().Append(_bar.rectTransform.DOAnchorPosY(_targetY, 3f, snapping: true)).Append(_bar.rectTransform.DOAnchorPosY(0f - _targetY, 3f, snapping: true))
			.SetEase(Ease.Linear)
			.SetRelative()
			.SetLoops(-1)
			.Play();
	}

	public void OnGo(int dayIndex)
	{
		_onGoButton.OnNext(new Cut
		{
			DayIndex = dayIndex,
			Position = _bar.rectTransform.anchoredPosition
		});
		UnityEngine.Object.Instantiate(_kizuPrefab, _root).rectTransform.anchoredPosition = _bar.rectTransform.anchoredPosition;
	}

	public async UniTask OnCompleted()
	{
		await UniTask.Delay(80);
		_barMove.Kill();
		_onGoButton.OnCompleted();
		_finishButton.OnCommand();
	}
}
