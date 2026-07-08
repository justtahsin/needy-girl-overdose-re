using System.Text;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
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
		if (!(_live == null))
		{
			_eizo = _live.Tenchan.gameObject.transform as RectTransform;
			_supachaParent = _live.Tenchan.gameObject.transform.GetChild(1).gameObject.transform;
			if (_baseImage == null)
			{
				_baseImage = GetComponent<Image>();
			}
			_baseImage.OnPointerEnterAsObservable().Subscribe(delegate
			{
				highlighted();
				Select();
			}).AddTo(this);
			_baseImage.OnPointerExitAsObservable().Subscribe(delegate
			{
				exited();
				Deselect();
			}).AddTo(this);
			this.OnTriggerEnter2DAsObservable().Subscribe(delegate
			{
				highlighted();
				Select();
			}).AddTo(base.gameObject);
			this.OnTriggerExit2DAsObservable().Subscribe(delegate
			{
				exited();
				Deselect();
			}).AddTo(base.gameObject);
		}
	}

	public async void SetContent(Playing playing, bool isRead = false)
	{
		this.playing = playing;
		honbun = playing.nakami;
		type = playing.diffStatusType;
		diff = playing.delta;
		honbunView.text = honbun;
		await UniTask.DelayFrame(1);
		int lineCount = honbunView.GetTextInfo(honbunView.text).lineCount;
		float y = ((playing.color == SuperchatType.White) ? (30f * (float)lineCount) : 10f);
		GetComponent<RectTransform>().sizeDelta = new Vector2(380f, y);
		if (isRead)
		{
			return;
		}
		if (playing.color != SuperchatType.White)
		{
			bgDefault = _superchats[(int)playing.color].Color;
			_baseImage.color = bgDefault;
			SuperChatEffect();
		}
		else if (playing.henji != "" || (_live.isOiwai && Random.Range(0, 3) < 2))
		{
			int num = Random.Range(0, _superchats.Length);
			bgDefault = _superchats[num].Color;
			_baseImage.color = bgDefault;
			SuperChatEffect();
			base.gameObject.GetComponent<Button>().OnClickAsObservable().Subscribe(delegate
			{
				hirou(this.playing);
			})
				.AddTo(base.gameObject);
		}
		else
		{
			base.gameObject.GetComponent<Button>().OnClickAsObservable().Subscribe(delegate
			{
				sakujo(this.playing);
			})
				.AddTo(base.gameObject);
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
		if (_live.isActiveReaction() && !isHiroizumi && (!SingletonMonoBehaviour<EventManager>.Instance.isHorror || SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) != 29))
		{
			isHiroizumi = true;
			_live.NowPlaying.isGensoku.Value = false;
			AdjustSpeed();
			AudioManager.Instance.PlaySeByType(SoundType.SE_pien);
			honbunView.DOColor(new Color(0f, 0f, 0f, 0f), 0.4f).Play();
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
				_baseImage.color = new Color(50f / 51f, 1f, 47f / 85f, 1f);
			}
			else
			{
				Scull.SetActive(value: true);
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
		SingletonMonoBehaviour<CursorManager>.Instance.SetCursor(null, Vector2.zero, CursorMode.Auto);
		_live.NowPlaying.isGensoku.Value = false;
		AdjustSpeed();
		_baseImage.color = bgDefault;
		Scull.SetActive(value: false);
		_ = isHiroizumi;
	}

	private void Select()
	{
		_live.SelectingComment = this;
	}

	private void Deselect()
	{
		if (_live.SelectingComment == this)
		{
			_live.SelectingComment = null;
		}
	}

	private void ChangeIineColor()
	{
		honbunView.DOColor(new Color(77f / 85f, 0.32156864f, 0.32156864f, 1f), 0.4f).Play();
	}

	public void SuperChatEffect()
	{
		AudioManager.Instance?.PlaySeByType(SoundType.SE_haisin_superchat);
		Transform supachaParent = _supachaParent;
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding == EndingType.Ending_Happy)
		{
			supachaParent = _live.gameObject.transform;
		}
		RectTransform supacha = Object.Instantiate(_superchatObjects[Random.Range(0, _superchatObjects.Length)], supachaParent);
		supacha.DoSperchatMove(delegate
		{
			Object.Destroy(supacha.gameObject);
		});
	}
}
