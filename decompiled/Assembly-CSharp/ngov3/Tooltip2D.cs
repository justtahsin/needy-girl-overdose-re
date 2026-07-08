using System.Threading;
using Cysharp.Threading.Tasks;
using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(Fader2D))]
public class Tooltip2D : MonoBehaviour, ITooltip, IFader
{
	protected float RIGHTBORDER = 9f;

	protected float LEFTBORDER = -9f;

	protected float DOWNBORDER = -5f;

	protected float UPBORDER = 5f;

	[SerializeField]
	private SpriteRenderer icon;

	[SerializeField]
	private TMP_Text speaker;

	[SerializeField]
	private TMP_Text contentText;

	[SerializeField]
	private Sprite osIcon;

	[SerializeField]
	private Sprite ameIcon;

	[SerializeField]
	protected RectTransform rect;

	[SerializeField]
	private RectTransform baloonRect;

	[SerializeField]
	protected RectTransform leftUp;

	[SerializeField]
	protected RectTransform rightDown;

	[SerializeField]
	private Fader2D fader2D;

	protected RectTransform BaloonRect => baloonRect;

	public void SetData(TooltipType type, Vector3 pos, bool isHoming, string nakamiText = "")
	{
		if (type == TooltipType.None)
		{
			contentText.text = nakamiText;
			icon.sprite = ameIcon;
			speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			return;
		}
		TooltipMaster.Param toolTip = NgoEx.getToolTip(type);
		contentText.text = NgoEx.GetToolTipText(toolTip, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		if (toolTip.Speaker == "Os")
		{
			icon.sprite = osIcon;
			speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Os, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else if (icon != null)
		{
			icon.sprite = ameIcon;
			speaker.text = NgoEx.SystemTextFromType(SystemTextType.Tooltip_Ame, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}

	public void Awake()
	{
		rect = GetComponent<RectTransform>();
	}

	public virtual void SetHomingPos()
	{
		if (!(rect == null))
		{
			SetBaloonPos();
			Vector3 cursorPosition = SingletonMonoBehaviour<CursorManager>.Instance.CursorPosition;
			Vector3 position = Camera.main.ScreenToWorldPoint(cursorPosition);
			position.z = rect.position.z;
			rect.position = position;
			float num = Mathf.Max(rightDown.position.x - RIGHTBORDER, 0f);
			float num2 = Mathf.Max(leftUp.position.y - UPBORDER, 0f);
			if (num > 0f || num2 > 0f)
			{
				position.x -= num;
				position.y -= num2;
				rect.position = position;
			}
		}
	}

	public void SetPos(Vector3 pos)
	{
		base.transform.localPosition = pos;
	}

	public virtual void SetBaloonPos()
	{
		if (BaloonRect != null)
		{
			BaloonRect.anchoredPosition = new Vector2(BaloonRect.sizeDelta.x / 2f, BaloonRect.sizeDelta.y / 2f);
		}
	}

	public async UniTask DOFade(float duration, float endValue, CancellationToken cancellationToken = default(CancellationToken))
	{
		await fader2D.DOFade(duration, endValue, cancellationToken);
	}

	public void SetAlpha(float alpha)
	{
		fader2D.SetAlpha(alpha);
	}
}
