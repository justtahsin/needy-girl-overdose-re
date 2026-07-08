using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class LiveScenario : MonoBehaviour
{
	[SerializeField]
	public List<Playing> playing;

	public int TOGGLEDBASESPEED = 3000;

	public int STARTSPEED = 3000;

	public int BASESPEED = 3000;

	public ReactiveProperty<bool> isGensoku = new ReactiveProperty<bool>(initialValue: false);

	public bool isPause;

	public EffectType defaultEffectType = EffectType.Kenjo;

	[SerializeField]
	protected Live _Live;

	protected LanguageType _lang;

	public string title = "超絶最かわてんしちゃん降臨の儀";

	public bool isStarted;

	protected virtual void Awake()
	{
		playing = new List<Playing>();
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: false);
		_Live = base.transform.parent.transform.parent.GetComponent<Live>();
		_lang = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		SingletonMonoBehaviour<NotificationManager>.Instance.Clean();
		isGensoku.ObserveEveryValueChanged((ReactiveProperty<bool> x) => x.Value).Subscribe(delegate(bool v)
		{
			PostEffectManager.Instance.MogoMogo(v);
		}).AddTo(this);
	}

	public virtual async UniTask StartScenario()
	{
		isStarted = true;
		if (SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 2)
		{
			SingletonMonoBehaviour<TooltipManager>.Instance.ShowTutorial(TooltipType.tooltip_secondHaishin);
			_Live._HaisinSpeed.gameObject.GetComponent<Image>().DOColor(new Color(1f, 0.8f, 0.8f), 1f).SetLoops(4)
				.Play();
			await NgoEvent.DelaySkippable(Constants.SLOW);
			SingletonMonoBehaviour<TooltipManager>.Instance.Hide();
		}
		await PlayScenario();
	}

	public void PlayScenarioToNextSerihu()
	{
		while (playing.Count > 0)
		{
			Playing obj = playing[0];
			Play(playing[0]);
			playing.RemoveAt(0);
			if (obj.isJimaku)
			{
				break;
			}
		}
	}

	public void SkipScenario()
	{
		BASESPEED = 1;
		playing = new List<Playing>
		{
			new Playing(SoundType.SE_piyo, isloop: false)
		};
	}

	public async UniTask PlayScenario()
	{
		while (playing.Count > 0)
		{
			await Play(playing[0]);
			playing.RemoveAt(0);
			if (playing.Count <= 0)
			{
				break;
			}
			await UniTask.Delay(BASESPEED);
			while (isGensoku.Value || isPause)
			{
				await UniTask.WaitWhile(() => isGensoku.Value || isPause);
				await UniTask.Delay(BASESPEED);
			}
		}
		await EndScenario();
	}

	private async UniTask EndScenario()
	{
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Grand && SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Ideon)
		{
			_Live.Tenchan.OnEndStream();
			SingletonMonoBehaviour<EventManager>.Instance.ObiActive(onoff: true);
			await UniTask.Delay(Constants.MIDDLE);
			PostEffectManager.Instance.ResetShader();
		}
	}

	public async UniTask Play(Playing context)
	{
		if (context.startReading)
		{
			_Live.ReadComment();
			BASESPEED = 1;
			return;
		}
		if (context.isSetting)
		{
			if (context.ongaku != SoundType.None)
			{
				AudioManager.Instance.PlaySeByType(context.ongaku, context.isLoopAnim);
				return;
			}
			SingletonMonoBehaviour<ChanceEffectController>.Instance._current.Value = context.obi;
			SingletonMonoBehaviour<ChanceEffectController>.Instance._anim.Value = context.inout;
			SingletonMonoBehaviour<EventManager>.Instance.ObiActive(onoff: false);
			BASESPEED = 1;
			return;
		}
		if (context.isYohaku)
		{
			BASESPEED = 1;
			_Live.AddMob(context.nakami);
			_Live.CommentScroll.verticalNormalizedPosition = 0f;
			return;
		}
		if (context.isJimaku)
		{
			BASESPEED = STARTSPEED;
			await showJimaku(context);
			_Live.setAnti(context.antiComment, context.showAnti);
			return;
		}
		BASESPEED = STARTSPEED / 14 * context.nakami.Length;
		if (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value == LanguageType.EN)
		{
			if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ideon)
			{
				BASESPEED = Mathf.CeilToInt((float)BASESPEED / 2.5f);
			}
			else if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Ginga)
			{
				BASESPEED = Mathf.CeilToInt((float)BASESPEED / 2f);
			}
		}
		showComment(context);
		await UniTask.Yield();
		_Live.CommentScroll.verticalNormalizedPosition = 0f;
	}

	public void showComment(Playing context)
	{
		_Live.NewComment(context);
	}

	public async UniTask showJimaku(Playing context)
	{
		if (context.animation != "")
		{
			_Live.ChotenAnimation(context.animation, context.isLoopAnim);
		}
		await _Live.ShowJimaku(context);
	}

	public void OnDestroy()
	{
		SingletonMonoBehaviour<TaskbarManager>.Instance.SetTaskbarInteractive(interactive: true);
	}
}
