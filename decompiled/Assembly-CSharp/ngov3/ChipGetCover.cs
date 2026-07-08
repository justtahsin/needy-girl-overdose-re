using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ChipGetCover : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup _cover;

	[SerializeField]
	private Button _next;

	[SerializeField]
	private TMP_Text _getLabel;

	[SerializeField]
	private TMP_Text _windowTitleLabel;

	[SerializeField]
	private TMP_Text _buttonLabel;

	[SerializeField]
	private NetaChipAlpha _newChipA;

	public ReactiveProperty<bool> isGetting = new ReactiveProperty<bool>(initialValue: false);

	private Sequence sequence;

	public Button NectButton => _next;

	public void Awake()
	{
		_buttonLabel.text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_next.OnClickAsObservable().Subscribe(delegate
		{
			EndGet();
		}).AddTo(_next.gameObject);
	}

	public void getNewChip(AlphaType type, int level)
	{
		string text = NgoEx.SystemTextFromType(SystemTextType.neta_get, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_windowTitleLabel.text = text;
		_getLabel.text = NgoEx.SystemTextFromType(SystemTextType.System_NetaGet, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		isGetting.Value = true;
		DOTween.Sequence().OnStart(delegate
		{
			_cover.alpha = 0f;
			_cover.interactable = true;
			_cover.blocksRaycasts = true;
			_newChipA.ShowType(type, level, isDiscovered: true);
			_newChipA._tooltip.isShowTooltip = false;
			_newChipA.button.transition = Selectable.Transition.None;
		}).Append(_cover.DOFade(1f, 0.4f))
			.AppendCallback(delegate
			{
				AudioManager.Instance.PlaySeByType(SoundType.SE_Tetehen);
			})
			.Append(_newChipA.transform.DOScale(1f, 0.3f))
			.Play();
	}

	public void EndGet()
	{
		DOTween.Sequence().Append(_cover.DOFade(0f, 0.2f)).OnComplete(delegate
		{
			_cover.interactable = false;
			_cover.blocksRaycasts = false;
			isGetting.Value = false;
			SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		})
			.SetAutoKill(autoKillOnCompletion: false)
			.Play();
	}
}
