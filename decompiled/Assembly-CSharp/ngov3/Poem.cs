using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace ngov3;

public class Poem : SingletonMonoBehaviour<Poem>
{
	[SerializeField]
	protected CanvasGroup PoemCanvas;

	[SerializeField]
	protected Button ClickToSkip;

	protected string poemHonbun;

	[SerializeField]
	protected TMP_Text PoemText;

	[SerializeField]
	protected Volume YamiNoise;

	protected Settings _setting;

	protected Sequence sequence;

	protected bool playingAnimation;

	[SerializeField]
	protected Button StartPoemButton;

	private static readonly string[] INVALID_CHARS = new string[15]
	{
		" ", "\u3000", "!", "?", "！", "？", "\"", "'", "\\", ".",
		",", "、", "。", "…", "・"
	};

	protected override void Awake()
	{
		base.Awake();
		if (StartPoemButton != null)
		{
			StartPoemButton.OnClickAsObservable().Subscribe(delegate
			{
				StartPoem("インターネットって、汚水が流れるどぶみたいなきったない匂いがする。\n\nこの世で最も汚れた空間だと思う。");
			}).AddTo(StartPoemButton);
		}
	}

	public virtual void Start()
	{
		PoemCanvas.alpha = 0f;
		PoemCanvas.interactable = false;
		PoemCanvas.blocksRaycasts = false;
		YamiNoise.weight = 0f;
		PoemText.text = "";
	}

	public void SkipPoem()
	{
		if (playingAnimation)
		{
			sequence.Kill(complete: true);
			endAnimation();
		}
	}

	public async UniTask StartPoem(string poem, bool isDaypassing = true)
	{
		string beforeText = PoemText.text;
		if (playingAnimation)
		{
			return;
		}
		playingAnimation = true;
		sequence = DOTween.Sequence().OnStart(delegate
		{
			PoemCanvas.alpha = 0f;
			PoemCanvas.interactable = true;
			PoemCanvas.blocksRaycasts = true;
			PoemText.text = "";
			YamiNoise.weight = 0.2f;
		}).Append(PoemCanvas.DOFade(1f, 0.4f).SetEase(Ease.InSine))
			.Append(PoemText.DOText(poem, (float)poem.Length * 0.12f).SetEase(Ease.Linear).OnUpdate(delegate
			{
				string text = PoemText.text;
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
			.Append(DOTween.To(() => YamiNoise.weight, delegate(float x)
			{
				YamiNoise.weight = x;
			}, 1f, 0.2f).SetEase(Ease.InExpo))
			.AppendInterval(1.8f)
			.OnComplete(delegate
			{
				endAnimation();
			});
		await sequence.Play();
	}

	public virtual void endAnimation()
	{
		playingAnimation = false;
		PoemCanvas.interactable = false;
		PoemCanvas.blocksRaycasts = false;
	}

	public void CleanPoem()
	{
		DOTween.Sequence().Append(DOTween.To(() => YamiNoise.weight, delegate(float x)
		{
			YamiNoise.weight = x;
		}, 0f, 0.2f).SetEase(Ease.OutExpo)).Join(PoemCanvas.DOFade(0f, 1.4f).SetEase(Ease.InSine))
			.Play();
	}
}
