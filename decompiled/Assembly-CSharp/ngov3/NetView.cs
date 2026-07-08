using System;
using NGO;
using TMPro;
using UnityEngine;

namespace ngov3;

public class NetView : MonoBehaviour
{
	[SerializeField]
	private InternetType netType;

	[SerializeField]
	private KitsuneResView _kituneResPrefabView;

	[SerializeField]
	private TMP_Text _suretai;

	[SerializeField]
	private RectTransform _content;

	protected void Awake()
	{
		UpdateContents();
	}

	public void UpdateContents(int num = 1)
	{
		if ((Object)(object)_suretai == (Object)null)
		{
			return;
		}
		string text = netType.ToString();
		InternetType result;
		string text2 = (Enum.TryParse<InternetType>(text + "_res0", out result) ? NgoEx.KituneFromType(text + "_res0", SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value) : string.Empty);
		_suretai.text = text2;
		foreach (KituneMaster.Param item in NgoEx.KituneFromRank(text))
		{
			if (!item.Id.EndsWith("0"))
			{
				Object.Instantiate<KitsuneResView>(_kituneResPrefabView, (Transform)(object)_content).SetData(NgoEx.SystemTextFromType(SystemTextType.Kitsune_Handle, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value), item.ResNumber, NgoEx.KituneFromType(item.Id, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value));
			}
		}
	}
}
