using System;
using System.Runtime.CompilerServices;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ChipGetCover : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static TweenCallback _003C_003E9__11_1;

		internal void _003CgetNewChip_003Eb__11_1()
		{
			AudioManager.Instance.PlaySeByType(SoundType.SE_Tetehen);
		}
	}

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

	public ReactiveProperty<bool> isGetting = new ReactiveProperty<bool>(false);

	private Sequence sequence;

	public Button NectButton => _next;

	public void Awake()
	{
		_buttonLabel.text = NgoEx.SystemTextFromType(SystemTextType.Dialog_OK, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_next), (Action<Unit>)delegate
		{
			EndGet();
		}), ((Component)_next).gameObject);
	}

	public void getNewChip(AlphaType type, int level)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		string text = NgoEx.SystemTextFromType(SystemTextType.neta_get, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_windowTitleLabel.text = text;
		_getLabel.text = NgoEx.SystemTextFromType(SystemTextType.System_NetaGet, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		isGetting.Value = true;
		Sequence obj = TweenSettingsExtensions.Append(TweenSettingsExtensions.OnStart<Sequence>(DOTween.Sequence(), (TweenCallback)delegate
		{
			_cover.alpha = 0f;
			_cover.interactable = true;
			_cover.blocksRaycasts = true;
			_newChipA.ShowType(type, level, isDiscovered: true);
			_newChipA._tooltip.isShowTooltip = false;
			((Selectable)_newChipA.button).transition = (Transition)0;
		}), (Tween)(object)DOTweenModuleUI.DOFade(_cover, 1f, 0.4f));
		object obj2 = _003C_003Ec._003C_003E9__11_1;
		if (obj2 == null)
		{
			TweenCallback val = delegate
			{
				AudioManager.Instance.PlaySeByType(SoundType.SE_Tetehen);
			};
			_003C_003Ec._003C_003E9__11_1 = val;
			obj2 = (object)val;
		}
		TweenExtensions.Play<Sequence>(TweenSettingsExtensions.Append(TweenSettingsExtensions.AppendCallback(obj, (TweenCallback)obj2), (Tween)(object)ShortcutExtensions.DOScale(((Component)_newChipA).transform, 1f, 0.3f)));
	}

	public void EndGet()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		TweenExtensions.Play<Sequence>(TweenSettingsExtensions.SetAutoKill<Sequence>(TweenSettingsExtensions.OnComplete<Sequence>(TweenSettingsExtensions.Append(DOTween.Sequence(), (Tween)(object)DOTweenModuleUI.DOFade(_cover, 0f, 0.2f)), (TweenCallback)delegate
		{
			_cover.interactable = false;
			_cover.blocksRaycasts = false;
			isGetting.Value = false;
			SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		}), false));
	}
}
