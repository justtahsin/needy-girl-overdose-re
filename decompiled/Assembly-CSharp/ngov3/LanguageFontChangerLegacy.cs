using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

[RequireComponent(typeof(Text))]
public class LanguageFontChangerLegacy : MonoBehaviour
{
	[Serializable]
	public struct LanguageFontDataLegacy
	{
		[SerializeField]
		internal LanguageType _targetLanguage;

		[SerializeField]
		internal Font _languageFont;

		[SerializeField]
		internal int _fontSize;
	}

	[SerializeField]
	private List<LanguageFontDataLegacy> _fontDatas = new List<LanguageFontDataLegacy>();

	private Font _defaultFont;

	private int _defaultFontSize;

	private Text _targetText;

	private void Start()
	{
		_targetText = GetComponent<Text>();
		_defaultFont = _targetText.font;
		_defaultFontSize = _targetText.fontSize;
		ChangeFont(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Subscribe(delegate(LanguageType t)
		{
			ChangeFont(t);
		}).AddTo(base.gameObject);
	}

	private void ChangeFont(LanguageType languageType)
	{
		foreach (LanguageFontDataLegacy fontData in _fontDatas)
		{
			if (fontData._targetLanguage == languageType)
			{
				_targetText.font = fontData._languageFont;
				_targetText.fontSize = fontData._fontSize;
				return;
			}
		}
		_targetText.font = _defaultFont;
		_targetText.fontSize = _defaultFontSize;
	}
}
