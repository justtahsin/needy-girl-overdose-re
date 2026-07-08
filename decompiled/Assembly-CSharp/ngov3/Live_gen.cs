using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Live_gen : MonoBehaviour
{
	private enum LiveGenStatus
	{
		NONE,
		CHOTEN_VIEW,
		CATEGORY_SELECT,
		ANIMATION_KEY_SELECT
	}

	[SerializeField]
	public Button _HaisinSpeed;

	[SerializeField]
	public TMP_Text _Speedlabel;

	public int Speed;

	private string nowSpeedLabel = "はいしんスピード\u3000ふつう";

	private string nowNextLabel = "▶\n\nすすむ";

	[SerializeField]
	private TMP_Text jimakuShowing;

	[SerializeField]
	private GameObject greenback;

	[SerializeField]
	public TenchanView Tenchan;

	private string todaysTenchan = "stream_cho_akaruku";

	public bool isHayakuti;

	private LanguageType _lang;

	private bool isSpeaking;

	private Tweener Jimaku;

	private int nowLine = -1;

	private string nowSerihu = "";

	private string nowAnim = "";

	[SerializeField]
	private TMP_InputField _input;

	[SerializeField]
	public TMP_Text _nextLabel;

	[SerializeField]
	private Button _next;

	[SerializeField]
	public TMP_Text _replayLabel;

	[SerializeField]
	private Button _replay;

	[SerializeField]
	public TMP_Text _resetLabel;

	[SerializeField]
	private Button _reset;

	[SerializeField]
	public TMP_Text _gbLabel;

	[SerializeField]
	private Button _gb;

	private bool isGBActive;

	private static readonly string[] INVALID_CHARS = new string[15]
	{
		" ", "\u3000", "!", "?", "！", "？", "\"", "'", "\\", ".",
		",", "、", "。", "…", "・"
	};

	[SerializeField]
	private Transform inputFieldParent;

	[SerializeField]
	private TextInputItem textInputItemPrefab;

	[SerializeField]
	private int initializeInputFieldCount = 1;

	private List<TextInputItem> textInputs = new List<TextInputItem>();

	[Header("AnimationKeyMaster")]
	[SerializeField]
	private Transform categoryParent;

	[SerializeField]
	private GameObject categoryView;

	[SerializeField]
	private Transform animationKeyParent;

	[SerializeField]
	private GameObject animationKeyView;

	[SerializeField]
	private AnimationCategoryVODataStore animationCategoryVODataStore;

	[SerializeField]
	private AnimationKeyVODataStore animationKeyVODataStore;

	[SerializeField]
	private AnimationCategoryItem categoryItemPrefab;

	[SerializeField]
	private AnimationItem animationHistoryItemPrefab;

	[SerializeField]
	private AnimationItem animationReturnItemPrefab;

	[SerializeField]
	private AnimationKeyItem animationKeyItemPrefab;

	[SerializeField]
	private Button _closeAnimationKeyParent;

	private TextInputItem selectedTextInput;

	[SerializeField]
	private VerticalLayoutGroup textGrid;

	[SerializeField]
	private List<Button> liveGenButtons;

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private TMP_Text _titleEditLabel;

	[SerializeField]
	private TMP_InputField _liveTitleLabel;

	[SerializeField]
	private TMP_Text _visitorsLabel;

	[SerializeField]
	private List<AnimationKeyItem> animationKeyItems = new List<AnimationKeyItem>();

	private IEnumerable<TextInputItem> ReadableTexts => textInputs.Where((TextInputItem t) => !string.IsNullOrEmpty(t.Input.text) || !string.IsNullOrEmpty(t.AnimationKey.Value));

	private void SetAppButtonsIntalactable(bool interactable)
	{
		foreach (Button liveGenButton in liveGenButtons)
		{
			liveGenButton.interactable = interactable;
		}
	}

	[ContextMenu("FixLayout")]
	public async void FixTextGridLayout()
	{
		float verticalNormalizedPosition = scrollRect.verticalNormalizedPosition;
		if (textGrid.childAlignment == TextAnchor.UpperLeft)
		{
			textGrid.childAlignment = TextAnchor.UpperCenter;
		}
		else
		{
			textGrid.childAlignment = TextAnchor.UpperLeft;
		}
		scrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
	}

	public void SetSelectedTextInput(TextInputItem selectedTextInput)
	{
		this.selectedTextInput = selectedTextInput;
		foreach (TextInputItem textInput in textInputs)
		{
			textInput.SetSelected(isSelected: false);
		}
		this.selectedTextInput.SetSelected(isSelected: true);
	}

	private void SetLiveGenView(LiveGenStatus liveGenStatus)
	{
		if (liveGenStatus == LiveGenStatus.CHOTEN_VIEW)
		{
			foreach (TextInputItem textInput in textInputs)
			{
				textInput.SetSelected(isSelected: false);
			}
			animationKeyView.SetActive(value: false);
			categoryView.gameObject.SetActive(value: false);
			SetAppButtonsIntalactable(interactable: true);
			ClearAnimationKeys();
		}
		if (liveGenStatus == LiveGenStatus.CATEGORY_SELECT)
		{
			animationKeyView.SetActive(value: false);
			categoryView.gameObject.SetActive(value: true);
			SetAppButtonsIntalactable(interactable: false);
			ClearAnimationKeys();
		}
		if (liveGenStatus == LiveGenStatus.ANIMATION_KEY_SELECT)
		{
			animationKeyView.SetActive(value: true);
			categoryView.gameObject.SetActive(value: false);
			SetAppButtonsIntalactable(interactable: false);
		}
	}

	public async void AddTextInput(TextInputItem textInputItem)
	{
		textInputs.Insert(textInputItem.Index, textInputItem);
		if (textInputs.Select((TextInputItem ti) => ti.Index).Max() == textInputItem.Index)
		{
			await UniTask.Delay(10);
			Debug.Log("最後尾なので下部にスクロール");
			scrollRect.verticalNormalizedPosition = 0f;
		}
	}

	public void RemoveTextInput(TextInputItem textInputItem)
	{
		textInputs = textInputs.Where((TextInputItem t) => t.Index != textInputItem.Index).ToList();
	}

	private async void InitializeLiveInput()
	{
		textInputs.ForEach(delegate(TextInputItem ti)
		{
			UnityEngine.Object.Destroy(ti.gameObject);
		});
		await UniTask.DelayFrame(1);
		textInputs = new List<TextInputItem>();
		selectedTextInput = null;
		for (int num = 0; num < initializeInputFieldCount; num++)
		{
			TextInputItem textInputItem = PrefabFolder.InstantiateTo<TextInputItem>(textInputItemPrefab, inputFieldParent);
			textInputItem.Initialize(this);
			textInputs.Add(textInputItem);
		}
	}

	public async UniTask Awake()
	{
		_titleEditLabel.text = NgoEx.SystemTextFromType(SystemTextType.TitleEdit, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_liveTitleLabel.text = NgoEx.SystemTextFromType(SystemTextType.LiveTitle, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_visitorsLabel.text = "N " + NgoEx.SystemTextFromType(SystemTextType.Haisin_Watching_Number, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		InitializeLiveInput();
		_closeAnimationKeyParent.OnClickAsObservable().Subscribe(delegate
		{
			closeAnimationKeyView();
		}).AddTo(base.gameObject);
		_lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		Speed = SingletonMonoBehaviour<Settings>.Instance.haishinSpeed;
		chotenView();
		bgView();
		setSpeed();
		nowNextLabel = "▶\n\n" + NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_Next, _lang);
		_nextLabel.text = nowNextLabel;
		_replayLabel.text = "◀◀\n\n" + NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_Replay, _lang);
		_resetLabel.text = "■\n\n" + NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_Reset, _lang);
		_gbLabel.text = "GB " + NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_GB, _lang);
		_HaisinSpeed.OnClickAsObservable().Subscribe(delegate
		{
			ToggleSpeed();
		}).AddTo(base.gameObject);
		_next.OnClickAsObservable().Subscribe(delegate
		{
			readline();
		}).AddTo(base.gameObject);
		_replay.OnClickAsObservable().Subscribe(delegate
		{
			rewind();
		}).AddTo(base.gameObject);
		_reset.OnClickAsObservable().Subscribe(delegate
		{
			clear();
		}).AddTo(base.gameObject);
		_gb.OnClickAsObservable().Subscribe(delegate
		{
			toggleGB();
		}).AddTo(base.gameObject);
	}

	private void Start()
	{
		AudioManager.Instance?.StopBgm();
		(from onKey in (from _ in this.UpdateAsObservable()
				select Input.GetKey(KeyCode.UpArrow)).DistinctUntilChanged()
			where onKey
			select onKey).Subscribe(delegate
		{
			TextInputItem selectedItem = textInputs.FirstOrDefault((TextInputItem ti) => ti.IsSelected);
			if (!(selectedItem == null) && selectedItem.Index != 0)
			{
				textInputs.ForEach(delegate(TextInputItem ti)
				{
					ti.SetSelected(isSelected: false);
				});
				textInputs.FirstOrDefault((TextInputItem it) => it.Index == selectedItem.Index - 1).Input.Select();
			}
		}).AddTo(base.gameObject);
		(from onKey in (from _ in this.UpdateAsObservable()
				select Input.GetKey(KeyCode.DownArrow)).DistinctUntilChanged()
			where onKey
			select onKey).Subscribe(delegate
		{
			TextInputItem selectedItem = textInputs.FirstOrDefault((TextInputItem ti) => ti.IsSelected);
			if (!(selectedItem == null) && selectedItem.Index != textInputs.Select((TextInputItem it) => it.Index).Max())
			{
				textInputs.ForEach(delegate(TextInputItem ti)
				{
					ti.SetSelected(isSelected: false);
				});
				textInputs.FirstOrDefault((TextInputItem it) => it.Index == selectedItem.Index + 1).Input.Select();
			}
		}).AddTo(base.gameObject);
		(from onKey in (from _ in this.UpdateAsObservable()
				select Input.GetKey(KeyCode.Return)).DistinctUntilChanged()
			where onKey
			select onKey).Subscribe(delegate
		{
			TextInputItem textInputItem = textInputs.FirstOrDefault((TextInputItem ti) => ti.IsSelected);
			if (!(textInputItem == null) && (!(textInputItem.Input.text == "") || !(textInputItem.AnimationKey.Value == "")))
			{
				textInputs.ForEach(delegate(TextInputItem ti)
				{
					ti.SetSelected(isSelected: false);
				});
				textInputItem.CreateChildItem();
			}
		}).AddTo(base.gameObject);
		(from _ in this.UpdateAsObservable()
			select Input.GetKey(KeyCode.Delete) || Input.GetKey(KeyCode.Backspace) into onKey
			where onKey
			select onKey).Subscribe(delegate
		{
			TextInputItem textInputItem = textInputs.FirstOrDefault((TextInputItem ti) => ti.IsSelected);
			if (!(textInputItem == null) && textInputItem.Input.text == "")
			{
				textInputItem.DeleatItem();
			}
		}).AddTo(base.gameObject);
		SetLiveGenView(LiveGenStatus.CHOTEN_VIEW);
		foreach (AnimationCategoryVO item in animationCategoryVODataStore.Items.Where((AnimationCategoryVO cv) => cv.AnimationCategory != AnimationCategoryEnum.none))
		{
			PrefabFolder.InstantiateTo<AnimationCategoryItem>(categoryItemPrefab, categoryParent).Initialize(item, delegate(AnimationCategoryVO vo)
			{
				SetLiveGenView(LiveGenStatus.ANIMATION_KEY_SELECT);
				IEnumerable<AnimationKeyVO> enumerable = animationKeyVODataStore.Items.Where((AnimationKeyVO akv) => akv.AnimationCategory == vo.AnimationCategory);
				SetAnimationKeyView(enumerable);
			});
		}
		PrefabFolder.InstantiateTo<AnimationItem>(animationHistoryItemPrefab, categoryParent).Initialize(delegate
		{
			SetLiveGenView(LiveGenStatus.ANIMATION_KEY_SELECT);
			List<string> list = new List<string>(SingletonMonoBehaviour<Settings>.Instance.animationKeyHistory);
			list.Reverse();
			IEnumerable<AnimationKeyVO> enumerable = from aniKey in list
				select animationKeyVODataStore.Items.FirstOrDefault((AnimationKeyVO akv) => akv.Id == aniKey) into akv
				where akv != null
				select akv;
			SetAnimationKeyView(enumerable);
		}, NgoEx.SystemTextFromType(SystemTextType.live_gen_history, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
		PrefabFolder.InstantiateTo<AnimationItem>(animationReturnItemPrefab, categoryParent).Initialize(delegate
		{
			selectedTextInput.AnimationKey.Value = "";
			SetLiveGenView(LiveGenStatus.CHOTEN_VIEW);
		}, NgoEx.SystemTextFromType(SystemTextType.live_gen_unlock, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
	}

	private void ClearAnimationKeys()
	{
		animationKeyItems.ForEach(delegate(AnimationKeyItem ak)
		{
			UnityEngine.Object.DestroyImmediate(ak.gameObject);
		});
		animationKeyItems = new List<AnimationKeyItem>();
	}

	private void SetAnimationKeyView(IEnumerable<AnimationKeyVO> targetCategoryAnimatoonKeys)
	{
		foreach (AnimationKeyVO targetCategoryAnimatoonKey in targetCategoryAnimatoonKeys)
		{
			AnimationKeyItem animationKeyItem = PrefabFolder.InstantiateTo<AnimationKeyItem>(animationKeyItemPrefab, animationKeyParent);
			animationKeyItems.Add(animationKeyItem);
			animationKeyItem.Initialize(targetCategoryAnimatoonKey, delegate(AnimationKeyVO vo)
			{
				SingletonMonoBehaviour<Settings>.Instance.AddAnimationKeyHistory(vo.Id);
				selectedTextInput.AnimationKey.Value = vo.Id;
				selectedTextInput.Input.Select();
				closeAnimationKeyView();
			});
		}
	}

	public void ShowCategoryParent()
	{
		SetLiveGenView(LiveGenStatus.CATEGORY_SELECT);
	}

	private void closeAnimationKeyView()
	{
		SetLiveGenView(LiveGenStatus.CHOTEN_VIEW);
		foreach (Transform item in animationKeyParent)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
	}

	private void readline()
	{
		nowLine++;
		try
		{
			TextInputItem[] array = ReadableTexts.ToArray();
			if (array.Length <= nowLine)
			{
				Tenchan.ShowEndView();
				return;
			}
			string text = array[nowLine].Input.text;
			string value = array[nowLine].AnimationKey.Value;
			speak(text.Replace("_", "\n").Replace("<br>", "\n"), value);
		}
		catch (Exception message)
		{
			Debug.LogError(message);
			speak(NgoEx.SystemTextFromType(SystemTextType.Agreement, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), "stream_cho_eeto");
		}
	}

	private void rewind()
	{
		nowLine = -1;
		jimakuShowing.text = "";
		ChotenAnimation("stream_cho_akaruku", isloop: false);
		if (Tenchan.LiveEnd)
		{
			Tenchan.ReWindEndView();
		}
	}

	private async void clear()
	{
		SingletonMonoBehaviour<WindowManager>.Instance.CloseApp(AppType.ManualHaishin);
		base.gameObject.SetActive(value: false);
		await UniTask.DelayFrame(1);
		SingletonMonoBehaviour<WindowManager>.Instance.NewWindow(AppType.ManualHaishin);
	}

	public async UniTask speak(string nakami, string anim = "")
	{
		if (anim != "")
		{
			ChotenAnimation(anim, isloop: false);
		}
		await showJimaku(nakami);
	}

	private void ToggleSpeed()
	{
		Speed++;
		Speed %= 3;
		setSpeed();
	}

	private void toggleGB()
	{
		isGBActive = !isGBActive;
		greenback.SetActive(isGBActive);
	}

	public void setSpeed(int speed)
	{
		Speed = speed;
		setSpeed();
	}

	private void setSpeed()
	{
		switch (Speed)
		{
		case 0:
			nowSpeedLabel = NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_SpeedUpNormal, _lang);
			isHayakuti = false;
			break;
		case 1:
			nowSpeedLabel = NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_SpeedUpFaster, _lang);
			isHayakuti = true;
			break;
		default:
			nowSpeedLabel = NgoEx.SystemTextFromType(SystemTextType.ManualHaishin_SpeedUpMoment, _lang);
			isHayakuti = true;
			break;
		}
		_Speedlabel.text = nowSpeedLabel;
		SingletonMonoBehaviour<Settings>.Instance.haishinSpeed = Speed;
	}

	private void bgView()
	{
	}

	public void chotenView(AlphaType alpha = AlphaType.none, BetaType beta = BetaType.akaruku, int alphaLevel = 1)
	{
		todaysTenchan = "stream_cho_akaruku";
		Tenchan.PlayAnim(todaysTenchan);
	}

	public void ChotenAnimation(string animationName, bool isloop)
	{
		Tenchan.PlayAnim(animationName);
	}

	public async UniTask showJimaku(string nakami)
	{
		float num = (isHayakuti ? 0.02f : 0.05f);
		if (Speed == 2)
		{
			jimakuShowing.text = nakami;
			Canvas.ForceUpdateCanvases();
			isSpeaking = true;
			await UniTask.Delay((int)MathF.Ceiling((float)nakami.Length * num * 1000f));
			isSpeaking = false;
		}
		else
		{
			jimakuShowing.text = "";
			isSpeaking = true;
			await Speak(nakami, num);
			await UniTask.Delay(Constants.FAST / 8);
			isSpeaking = false;
		}
	}

	public async UniTask Speak(string nakami, float speed)
	{
		string beforeText = jimakuShowing.text;
		await DOTween.Sequence().OnStart(delegate
		{
			jimakuShowing.text = "";
		}).Append(jimakuShowing.DOText(nakami, (float)nakami.Length * speed).SetEase(Ease.Linear).OnUpdate(delegate
		{
			string text = jimakuShowing.text;
			if (!(beforeText == text))
			{
				string text2 = text[text.Length - 1].ToString();
				if (text2 != "\n" && text2 != "\u3000" && text2 != " ")
				{
					AudioManager.Instance.PlaySeByType(SoundType.SE_per);
				}
				beforeText = text;
			}
		}))
			.Play();
	}
}
