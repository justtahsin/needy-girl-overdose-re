using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using NGO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class Tooltip : MonoBehaviour, ITooltip, IFader
{
	protected float RIGHTBORDER;

	protected float LEFTBORDER = 1436f;

	protected float BELOWBORDER;

	protected float UNDERBORDER = 1080f;

	[SerializeField]
	private Image icon;

	[SerializeField]
	private TMP_Text speaker;

	[SerializeField]
	private TMP_Text contentText;

	[SerializeField]
	private Sprite osIcon;

	[SerializeField]
	private Sprite ameIcon;

	[SerializeField]
	public CanvasGroup canvas;

	[SerializeField]
	public RectTransform rect;

	public bool isHoming = true;

	public void Awake()
	{
		rect = GetComponent<RectTransform>();
	}

	public void SetPos(Vector3 pos)
	{
		base.transform.localPosition = pos;
	}

	public virtual void SetHomingPos()
	{
		Vector3 cursorPosition = SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition;
		cursorPosition.z = 10f;
		Vector3 position = Camera.main.ScreenToWorldPoint(cursorPosition);
		base.transform.position = position;
		float x = rect.localPosition.x;
		float y = rect.localPosition.y;
		float f = Mathf.Clamp(x, RIGHTBORDER, LEFTBORDER - rect.sizeDelta.x);
		float f2 = Mathf.Clamp(y, BELOWBORDER + rect.sizeDelta.y, UNDERBORDER);
		rect.localPosition = new Vector3(Mathf.Round(f), Mathf.Round(f2), 0f);
	}

	public void SetData(TooltipType type, Vector3 pos, bool isHoming, string nakamiText = "")
	{
		if (type == TooltipType.None)
		{
			contentText.text = nakamiText;
			icon.sprite = ameIcon;
			speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else
		{
			TooltipMaster.Param toolTip = NgoEx.getToolTip(type);
			contentText.text = NgoEx.GetToolTipText(toolTip, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			if (toolTip.Speaker == "Os")
			{
				icon.sprite = osIcon;
				speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Os, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
			else
			{
				icon.sprite = ameIcon;
				speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			}
		}
		SetPos(pos);
	}

	public void SetBaloonPos()
	{
	}

	public async UniTask DOFade(float duration, float endValue, CancellationToken cancellationToken = default(CancellationToken))
	{
		await canvas.DOFade(endValue, duration).Play().WithCancellation(cancellationToken);
	}

	public void SetAlpha(float alpha)
	{
		canvas.alpha = alpha;
	}
}
