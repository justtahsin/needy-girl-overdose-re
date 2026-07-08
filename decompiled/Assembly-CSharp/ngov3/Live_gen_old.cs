using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Live_gen_old : MonoBehaviour
{
	[SerializeField]
	public Button _HaisinSpeed;

	[SerializeField]
	public TMP_Text _Speedlabel;

	public int Speed;

	private string nowSpeedLabel = "はいしんスピード\u3000ふつう";

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
	private Button _next;

	[SerializeField]
	private Button _replay;

	[SerializeField]
	private Button _reset;

	[SerializeField]
	private Button _gb;

	private bool isGBActive;

	private static readonly string[] INVALID_CHARS = new string[15]
	{
		" ", "\u3000", "!", "?", "！", "？", "\"", "'", "\\", ".",
		",", "、", "。", "…", "・"
	};

	public async UniTask Awake()
	{
		_lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		Speed = SingletonMonoBehaviour<Settings>.Instance.haishinSpeed;
		chotenView(SingletonMonoBehaviour<EventManager>.Instance.alpha, SingletonMonoBehaviour<EventManager>.Instance.beta);
		bgView();
		setSpeed();
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

	private void readline()
	{
		nowLine++;
		try
		{
			string[] array = _input.text.Replace("\r\n", "\n").Split('\n', '\r');
			if (array.Length <= nowLine)
			{
				Tenchan.OnEndStream();
				return;
			}
			string[] array2 = array[nowLine].Split(',');
			if (array2.Length == 1)
			{
				speak(array2[0].Replace("_", "\n"));
			}
			else
			{
				speak(array2[0].Replace("_", "\n"), array2[1]);
			}
		}
		catch
		{
			speak("えーとえーと", "stream_cho_eeto");
		}
	}

	private void rewind()
	{
		nowLine = -1;
		jimakuShowing.text = "";
		Tenchan.PlayAnim("stream_cho_akaruku");
	}

	private void clear()
	{
		rewind();
		_input.text = "";
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
			nowSpeedLabel = "ふつう";
			isHayakuti = false;
			break;
		case 1:
			nowSpeedLabel = "はやくち";
			isHayakuti = true;
			break;
		default:
			nowSpeedLabel = "一瞬";
			isHayakuti = true;
			break;
		}
		_Speedlabel.text = nowSpeedLabel;
		SingletonMonoBehaviour<Settings>.Instance.haishinSpeed = Speed;
	}

	private void bgView()
	{
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		int status2 = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex);
		if (status > 100000 && status2 > 14)
		{
			Tenchan._backGround.sprite = Tenchan.background_silver_shield;
		}
		if (status > 1000000 && status2 > 27)
		{
			Tenchan._backGround.sprite = Tenchan.background_gold_shield;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.alpha == AlphaType.Angel)
		{
			switch (SingletonMonoBehaviour<EventManager>.Instance.alphaLevel)
			{
			case 1:
				Tenchan._backGround.sprite = Tenchan.background_kinen1;
				break;
			case 2:
				Tenchan._backGround.sprite = Tenchan.background_kinen2;
				break;
			case 3:
				Tenchan._backGround.sprite = Tenchan.background_kinen3;
				break;
			case 4:
				Tenchan._backGround.sprite = Tenchan.background_kinen4;
				break;
			default:
				Tenchan._backGround.sprite = Tenchan.background_kinen5;
				break;
			}
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Kyouso)
		{
			Tenchan._backGround.sprite = Tenchan._background_kyouso;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) >= 28)
		{
			Tenchan._backGround.sprite = Tenchan._background_horror;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Happy)
		{
			Tenchan._backGround.sprite = Tenchan._background_happy;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ntr)
		{
			Tenchan._backGround.sprite = Tenchan._background_ntr;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Sucide)
		{
			Tenchan._backGround.sprite = Tenchan._background_sayonara1;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Grand)
		{
			Tenchan._backGround.color = new Color(0f, 0f, 0f, 0f);
		}
	}

	public void chotenView(AlphaType alpha, BetaType beta = BetaType.akaruku, int alphaLevel = 1)
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
