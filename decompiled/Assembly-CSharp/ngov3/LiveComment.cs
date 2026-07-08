using System;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ngov3;

public class LiveComment : MonoBehaviour
{
	public Playing playing;

	public TMP_Text honbunView;

	private string honbun;

	public StatusType type;

	public int diff;

	private Live _live;

	private Transform _supachaParent;

	private bool isHiroizumi;

	[SerializeField]
	private GameObject Scull;

	[SerializeField]
	private Image _baseImage;

	[SerializeField]
	private RectTransform _eizo;

	[SerializeField]
	private RectTransform[] _superchatObjects;

	private bool isDeleted;

	private Superchat[] _superchats = new Superchat[8]
	{
		new Superchat
		{
			Type = SuperchatType.Red,
			Color = new Color(77f / 85f, 0.32156864f, 0.32156864f),
			LifeTime = 4f,
			CommonProvability = 0,
			SuperChatProvability = 1,
			AngelProvability = 1,
			FeverProvability = 5
		},
		new Superchat
		{
			Type = SuperchatType.Blue,
			Color = new Color(0.6313726f, 61f / 85f, 0.9411765f),
			LifeTime = 1f,
			CommonProvability = 0,
			SuperChatProvability = 8,
			AngelProvability = 21,
			FeverProvability = 15
		},
		new Superchat
		{
			Type = SuperchatType.Cyan,
			Color = new Color(0.54509807f, 71f / 85f, 1f),
			LifeTime = 1.2f,
			CommonProvability = 0,
			SuperChatProvability = 5,
			AngelProvability = 13,
			FeverProvability = 15
		},
		new Superchat
		{
			Type = SuperchatType.LightGreen,
			Color = new Color(47f / 85f, 1f, 66f / 85f),
			LifeTime = 2f,
			CommonProvability = 0,
			SuperChatProvability = 3,
			AngelProvability = 8,
			FeverProvability = 15
		},
		new Superchat
		{
			Type = SuperchatType.Yellow,
			Color = new Color(50f / 51f, 1f, 47f / 85f),
			LifeTime = 2.2f,
			CommonProvability = 0,
			SuperChatProvability = 2,
			AngelProvability = 5,
			FeverProvability = 15
		},
		new Superchat
		{
			Type = SuperchatType.Orange,
			Color = new Color(1f, 0.7921569f, 0.0627451f),
			LifeTime = 2.2f,
			CommonProvability = 0,
			SuperChatProvability = 1,
			AngelProvability = 3,
			FeverProvability = 15
		},
		new Superchat
		{
			Type = SuperchatType.Magenta,
			Color = new Color(78f / 85f, 32f / 51f, 0.9098039f),
			LifeTime = 3f,
			CommonProvability = 0,
			SuperChatProvability = 1,
			AngelProvability = 2,
			FeverProvability = 15
		},
		new Superchat
		{
			Type = SuperchatType.Red,
			Color = new Color(77f / 85f, 0.32156864f, 0.32156864f),
			LifeTime = 4f,
			CommonProvability = 0,
			SuperChatProvability = 1,
			AngelProvability = 1,
			FeverProvability = 5
		}
	};

	private Color bgDefault = new Color(50f / 51f, 1f, 47f / 85f, 0f);

	public bool IsDeleted => isDeleted;

	public void Awake()
	{
		_live = Object.FindObjectOfType<Live>();
		if (!((Object)(object)_live == (Object)null))
		{
			Transform transform = ((Component)_live.Tenchan).gameObject.transform;
			_eizo = (RectTransform)(object)((transform is RectTransform) ? transform : null);
			_supachaParent = ((Component)((Component)_live.Tenchan).gameObject.transform.GetChild(1)).gameObject.transform;
			if ((Object)(object)_baseImage == (Object)null)
			{
				_baseImage = ((Component)this).GetComponent<Image>();
			}
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerEnterAsObservable((UIBehaviour)(object)_baseImage), (Action<PointerEventData>)delegate
			{
				highlighted();
				Select();
			}), (Component)(object)this);
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<PointerEventData>(ObservableTriggerExtensions.OnPointerExitAsObservable((UIBehaviour)(object)_baseImage), (Action<PointerEventData>)delegate
			{
				exited();
				Deselect();
			}), (Component)(object)this);
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Collider2D>(ObservableTriggerExtensions.OnTriggerEnter2DAsObservable((Component)(object)this), (Action<Collider2D>)delegate
			{
				highlighted();
				Select();
			}), ((Component)this).gameObject);
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Collider2D>(ObservableTriggerExtensions.OnTriggerExit2DAsObservable((Component)(object)this), (Action<Collider2D>)delegate
			{
				exited();
				Deselect();
			}), ((Component)this).gameObject);
		}
	}

	public async void SetContent(Playing playing, bool isRead = false)
	{
		this.playing = playing;
		honbun = playing.nakami;
		type = playing.diffStatusType;
		diff = playing.delta;
		honbunView.text = honbun;
		await UniTask.DelayFrame(1, (PlayerLoopTiming)8, default(CancellationToken), false);
		int lineCount = honbunView.GetTextInfo(honbunView.text).lineCount;
		float num = ((playing.color == SuperchatType.White) ? (30f * (float)lineCount) : 10f);
		((Component)this).GetComponent<RectTransform>().sizeDelta = new Vector2(380f, num);
		if (isRead)
		{
			return;
		}
		if (playing.color != SuperchatType.White)
		{
			bgDefault = _superchats[(int)playing.color].Color;
			((Graphic)_baseImage).color = bgDefault;
			SuperChatEffect();
		}
		else if (playing.henji != "" || (_live.isOiwai && Random.Range(0, 3) < 2))
		{
			int num2 = Random.Range(0, _superchats.Length);
			bgDefault = _superchats[num2].Color;
			((Graphic)_baseImage).color = bgDefault;
			SuperChatEffect();
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)this).gameObject.GetComponent<Button>()), (Action<Unit>)delegate
			{
				hirou(this.playing);
			}), ((Component)this).gameObject);
		}
		else
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)this).gameObject.GetComponent<Button>()), (Action<Unit>)delegate
			{
				sakujo(this.playing);
			}), ((Component)this).gameObject);
		}
	}

	public void hirou(Playing playing)
	{
		if (_live.isActiveReaction() && !isHiroizumi)
		{
			isHiroizumi = true;
			_live.NowPlaying.isGensoku.Value = false;
			AdjustSpeed();
			_live.hirowareta(playing);
			_live.Actioned();
		}
	}

	public void sakujo(Playing playing)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		if (_live.isActiveReaction() && !isHiroizumi && (!SingletonMonoBehaviour<EventManager>.Instance.isHorror || SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) != 29))
		{
			isHiroizumi = true;
			_live.NowPlaying.isGensoku.Value = false;
			AdjustSpeed();
			AudioManager.Instance.PlaySeByType(SoundType.SE_pien);
			TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(ShortcutExtensionsTMPText.DOColor(honbunView, new Color(0f, 0f, 0f, 0f), 0.4f));
			isDeleted = true;
			if (playing.delta != 0 && playing.diffStatusType != StatusType.Tension)
			{
				SingletonMonoBehaviour<StatusManager>.Instance.UpdateStatus(playing.diffStatusType, playing.delta);
			}
			_live.Actioned();
		}
	}

	private void highlighted()
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		if (!_live.isActiveReaction() || isHiroizumi)
		{
			return;
		}
		if (SingletonMonoBehaviour<EventManager>.Instance.isHorror && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) == 29)
		{
			if (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value != LanguageType.EN)
			{
				Encoding uTF = Encoding.UTF8;
				Encoding encoding = Encoding.GetEncoding("Shift_JIS");
				byte[] bytes = uTF.GetBytes(honbun);
				string text = encoding.GetString(bytes);
				honbunView.text = text;
			}
			else
			{
				honbunView.text = "縺溘☆縺代※";
			}
		}
		else
		{
			_live.NowPlaying.isGensoku.Value = true;
			AdjustSpeed();
			if (playing.henji != "")
			{
				((Graphic)_baseImage).color = new Color(50f / 51f, 1f, 47f / 85f, 1f);
			}
			else
			{
				Scull.SetActive(true);
			}
		}
	}

	private void AdjustSpeed()
	{
		if (_live.NowPlaying.isGensoku.Value)
		{
			_live.NowPlaying.BASESPEED = 3500;
		}
		else
		{
			_live.NowPlaying.BASESPEED = _live.NowPlaying.STARTSPEED;
		}
	}

	private void exited()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, Vector2.zero, (CursorMode)0);
		_live.NowPlaying.isGensoku.Value = false;
		AdjustSpeed();
		((Graphic)_baseImage).color = bgDefault;
		Scull.SetActive(false);
		_ = isHiroizumi;
	}

	private void Select()
	{
		_live.SelectingComment = this;
	}

	private void Deselect()
	{
		if ((Object)(object)_live.SelectingComment == (Object)(object)this)
		{
			_live.SelectingComment = null;
		}
	}

	private void ChangeIineColor()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		TweenExtensions.Play<TweenerCore<Color, Color, ColorOptions>>(ShortcutExtensionsTMPText.DOColor(honbunView, new Color(77f / 85f, 0.32156864f, 0.32156864f, 1f), 0.4f));
	}

	public void SuperChatEffect()
	{
		AudioManager.Instance?.PlaySeByType(SoundType.SE_haisin_superchat);
		Transform val = _supachaParent;
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Happy)
		{
			val = ((Component)_live).gameObject.transform;
		}
		RectTransform supacha = Object.Instantiate<RectTransform>(_superchatObjects[Random.Range(0, _superchatObjects.Length)], val);
		supacha.DoSperchatMove(delegate
		{
			Object.Destroy((Object)(object)((Component)supacha).gameObject);
		});
	}
}
