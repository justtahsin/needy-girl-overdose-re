using NGO;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class ControllerGuide_PlayStation : ControllerGuide
{
	[SerializeField]
	[Header("ヘッダーテキスト")]
	private Text _header;

	[Header("デスクトップタブテキスト")]
	[SerializeField]
	private Text _desktop_Header;

	[SerializeField]
	private Text _desktop_A;

	[SerializeField]
	private Text _desktop_B;

	[SerializeField]
	private Text _desktop_B_Sub;

	[SerializeField]
	private Text _desktop_X;

	[SerializeField]
	private Text _desktop_X_Sub;

	[SerializeField]
	private Text _desktop_Y;

	[SerializeField]
	private Text _desktop_RS;

	[SerializeField]
	private Text _desktop_LS;

	[SerializeField]
	private Text _desktop_R;

	[SerializeField]
	private Text _desktop_ZR;

	[SerializeField]
	private Text _desktop_L;

	[SerializeField]
	private Text _desktop_ZL;

	[SerializeField]
	private Text _desktop_Plus;

	[SerializeField]
	private Text _desktop_Minus;

	[SerializeField]
	private Text _desktop_Cross;

	[SerializeField]
	private Text _desktop_LRPress;

	[Header("配信タブテキスト")]
	[SerializeField]
	private Text _live_Header;

	[SerializeField]
	private Text _live_A;

	[SerializeField]
	private Text _live_B;

	[SerializeField]
	private Text _live_RS;

	[SerializeField]
	private Text _live_LS;

	[SerializeField]
	private Text _live_R;

	[SerializeField]
	private Text _live_ZR;

	[SerializeField]
	private Text _live_ZR_Sub;

	[SerializeField]
	private Text _live_L;

	[SerializeField]
	private Text _live_ZL;

	[SerializeField]
	private Text _live_ZL_Sub;

	[SerializeField]
	private Text _live_Minus;

	[SerializeField]
	private Text _live_Cross;

	[Header("ログインタブテキスト")]
	[SerializeField]
	private Text _login_Header;

	[SerializeField]
	private Text _login_A;

	[SerializeField]
	private Text _login_B;

	[SerializeField]
	private Text _login_LS;

	[SerializeField]
	private Text _login_RS;

	[SerializeField]
	private Text _login_ZR;

	[SerializeField]
	private Text _login_ZL;

	[SerializeField]
	private Text _login_Minus;

	[SerializeField]
	private Text _login_Cross;

	protected override void SetText(TabType type)
	{
		_header.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide01, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_desktop_Header.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide02, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_live_Header.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide03, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		_login_Header.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide04, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		switch (type)
		{
		case TabType.Desktop:
			_desktop_A.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide05, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_B.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide06, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_B_Sub.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide07, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_X.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide08, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_X_Sub.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide09, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_Y.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide10, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_RS.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide15, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_LS.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide16, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_R.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide13, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_ZR.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide11, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_L.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide13, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_ZL.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide12, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_Plus.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide14, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_Minus.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide01, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_Cross.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide17, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_desktop_LRPress.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide19, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		case TabType.Live:
			_live_A.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide05, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_B.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide20, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_RS.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide15, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_LS.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide16, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_R.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide21, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_ZR.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide23, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_ZR_Sub.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide25, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_L.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide22, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_ZL.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide24, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_ZL_Sub.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide25, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_Minus.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide01, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_live_Cross.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide17, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		default:
			_login_A.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide05, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_login_B.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide26, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_login_LS.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide16, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_login_RS.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide15, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_login_ZR.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide11, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_login_ZL.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide12, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_login_Minus.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide01, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			_login_Cross.text = NgoEx.SystemTextFromType(SystemTextType.SwitchGuide17, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		}
	}
}
