using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(TMP_Text))]
public class LanguageFontChanger : MonoBehaviour
{
	[Serializable]
	public struct LanguageFontData
	{
		[SerializeField]
		internal LanguageType _targetLanguage;

		[SerializeField]
		internal TMP_FontAsset _languageFont;

		[SerializeField]
		internal float _fontSize;

		[SerializeField]
		internal float _fontSpace;

		public LanguageType TargetLanguage => _targetLanguage;

		public TMP_FontAsset LanguageFont => _languageFont;

		public float FontSize => _fontSize;

		public float FontSpace => _fontSpace;
	}

	[SerializeField]
	private List<LanguageFontData> _fontDatas = new List<LanguageFontData>();

	private TMP_FontAsset _defaultFont;

	private float _defaultFontSize;

	private float _defaultFontSpace;

	private TMP_Text _targetText;

	[SerializeField]
	private TMPStencilSetter tMPStencil;

	public List<LanguageFontData> GetChangerList => _fontDatas;

	private void Start()
	{
		_targetText = ((Component)this).GetComponent<TMP_Text>();
		_defaultFont = _targetText.font;
		_defaultFontSize = _targetText.fontSize;
		_defaultFontSpace = _targetText.characterSpacing;
		ChangeFont(SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate(LanguageType t)
		{
			ChangeFont(t);
		}), ((Component)this).gameObject);
	}

	private void ChangeFont(LanguageType languageType)
	{
		foreach (LanguageFontData fontData in _fontDatas)
		{
			if (fontData._targetLanguage != languageType)
			{
				continue;
			}
			if ((Object)(object)fontData._languageFont != (Object)null)
			{
				_targetText.font = fontData._languageFont;
				if ((Object)(object)tMPStencil != (Object)null)
				{
					tMPStencil.SetStencil();
				}
			}
			_targetText.fontSize = fontData._fontSize;
			_targetText.characterSpacing = fontData.FontSpace;
			return;
		}
		_targetText.font = _defaultFont;
		_targetText.fontSize = _defaultFontSize;
		_targetText.characterSpacing = _defaultFontSpace;
		if ((Object)(object)tMPStencil != (Object)null)
		{
			tMPStencil.SetStencil();
		}
	}
}
