using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineCell : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public JineDrawable nakami;

		public JineCell _003C_003E4__this;

		internal bool _003CsetData_003Eb__1(ResourceLocal r)
		{
			return r.FileName == nakami.ImageId;
		}

		internal void _003CsetData_003Eb__0(long _)
		{
			_003C_003E4__this.OnKidoku();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public ResourceLocal resource;

		internal void _003CsetData_003Eb__2(Unit _)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			ImageViewerHelper.OpenImageViewer(resource.FileName);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CsetData_003Ed__17 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineDrawable nakami;

		public JineCell _003C_003E4__this;

		private _003C_003Ec__DisplayClass17_1 _003C_003E8__1;

		private _003C_003Ec__DisplayClass17_0 _003C_003E8__2;

		public int kidokMilliSecond;

		private Image _003C_003E7__wrap1;

		private Awaiter<Sprite> _003C_003Eu__1;

		private TweenAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineCell jineCell = _003C_003E4__this;
			try
			{
				TweenAwaiter val;
				Awaiter<Sprite> val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__2;
						_003C_003Eu__2 = default(TweenAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_029d;
					}
					_003C_003E8__2 = new _003C_003Ec__DisplayClass17_0();
					_003C_003E8__2.nakami = nakami;
					_003C_003E8__2._003C_003E4__this = _003C_003E4__this;
					jineCell.cellalpha.alpha = 0f;
					jineCell.SetStamp(_003C_003E8__2.nakami);
					if (!_003C_003E8__2.nakami.ImageId.IsNotEmpty())
					{
						goto IL_01e9;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass17_1();
					((Component)jineCell._image).gameObject.SetActive(true);
					_003C_003E8__1.resource = jineCell._resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == _003C_003E8__2.nakami.ImageId);
					SingletonMonoBehaviour<Settings>.Instance.addImage(_003C_003E8__2.nakami.ImageId);
					if (_003C_003E8__1.resource == null)
					{
						Debug.LogError((object)("存在しない画像を探してるよ" + _003C_003E8__2.nakami.ImageId));
						goto IL_01e2;
					}
					_003C_003E7__wrap1 = jineCell._image;
					val2 = LoadPictures.LoadPictureAsync(_003C_003E8__1.resource.FileName, LoadPictures.PictureType.JINE).GetAwaiter();
					if (!val2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CsetData_003Ed__17>(ref val2, ref this);
						return;
					}
				}
				else
				{
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter<Sprite>);
					num = (_003C_003E1__state = -1);
				}
				Sprite result = val2.GetResult();
				_003C_003E7__wrap1.sprite = result;
				_003C_003E7__wrap1 = null;
				Button component = ((Component)jineCell._image).gameObject.GetComponent<Button>();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(component), (Action<Unit>)delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					ImageViewerHelper.OpenImageViewer(_003C_003E8__1.resource.FileName);
				}), ((Component)component).gameObject);
				goto IL_01e2;
				IL_01e9:
				jineCell.SetBody(_003C_003E8__2.nakami);
				jineCell.SetLocalize(_003C_003E8__2.nakami);
				if (_003C_003E8__2.nakami.JineUserType == JineUserType.pi && kidokMilliSecond == 1)
				{
					jineCell.OnKidoku();
				}
				val = DOTweenAsyncExtensions.GetAwaiter((Tween)(object)TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(jineCell.cellalpha, 1f, 0.4f)));
				if (!((TweenAwaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TweenAwaiter, _003CsetData_003Ed__17>(ref val, ref this);
					return;
				}
				goto IL_029d;
				IL_01e2:
				_003C_003E8__1 = null;
				goto IL_01e9;
				IL_029d:
				((TweenAwaiter)(ref val)).GetResult();
				if (_003C_003E8__2.nakami.JineUserType == JineUserType.pi && kidokMilliSecond > 1)
				{
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<long>(Observable.Timer(TimeSpan.FromSeconds((double)(_003C_003E8__2.nakami.kidokumillisecond / 1000))), (Action<long>)delegate
					{
						_003C_003E8__2._003C_003E4__this.OnKidoku();
					}), (Component)(object)jineCell);
				}
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003E8__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003E8__2 = null;
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[SerializeField]
	private ResourceLocalMaster _resourceMaster;

	[SerializeField]
	private TMP_Text honbun;

	[SerializeField]
	private TMP_Text day;

	[SerializeField]
	private TMP_Text _kidoku;

	[SerializeField]
	private Image stampWaku;

	[SerializeField]
	private Image _image;

	[SerializeField]
	private GameObject balloon;

	[SerializeField]
	private CanvasGroup ameIcon;

	[SerializeField]
	private CanvasGroup cellalpha;

	private bool langChangeSetted;

	public int _kidokuMilliSecondRange = 1000;

	public void setDay(int Day)
	{
		changeDay(Day);
		TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(cellalpha, 1f, 0.2f));
		setDayLang(Day);
	}

	private void changeDay(int Day)
	{
		honbun.text = NgoEx.DayText(Day, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
	}

	private void setDayLang(int Day)
	{
		if (!langChangeSetted)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
			{
				changeDay(Day);
			}), ((Component)this).gameObject);
			langChangeSetted = true;
		}
	}

	public void setDayPart(int DayPart)
	{
		changeDayPart(DayPart);
		TweenExtensions.Play<TweenerCore<float, float, FloatOptions>>(DOTweenModuleUI.DOFade(cellalpha, 1f, 0.2f));
		setDaypartLang(DayPart);
	}

	private void changeDayPart(int DayPart)
	{
		switch (DayPart)
		{
		case -1:
			honbun.text = "---";
			break;
		case 0:
			honbun.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart0, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		case 1:
			honbun.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart1, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		case 2:
			honbun.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart2, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		default:
			honbun.text = NgoEx.SystemTextFromType(SystemTextType.System_Daypart3, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			break;
		}
	}

	private void setDaypartLang(int DayPart)
	{
		if (!langChangeSetted)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
			{
				changeDayPart(DayPart);
			}), ((Component)this).gameObject);
			langChangeSetted = true;
		}
	}

	[AsyncStateMachine(typeof(_003CsetData_003Ed__17))]
	public UniTask setData(JineDrawable nakami, int kidokMilliSecond = 100)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CsetData_003Ed__17 _003CsetData_003Ed__18 = default(_003CsetData_003Ed__17);
		_003CsetData_003Ed__18._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CsetData_003Ed__18._003C_003E4__this = this;
		_003CsetData_003Ed__18.nakami = nakami;
		_003CsetData_003Ed__18.kidokMilliSecond = kidokMilliSecond;
		_003CsetData_003Ed__18._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CsetData_003Ed__18._003C_003Et__builder)).Start<_003CsetData_003Ed__17>(ref _003CsetData_003Ed__18);
		return ((AsyncUniTaskMethodBuilder)(ref _003CsetData_003Ed__18._003C_003Et__builder)).Task;
	}

	private void SetLocalize(JineDrawable nakami)
	{
		if (!langChangeSetted)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)delegate
			{
				OnLanguageUpdated(nakami);
			}), ((Component)this).gameObject);
			langChangeSetted = true;
		}
	}

	private void SetStamp(JineDrawable nakami)
	{
		if (nakami.StampType != StampType.None)
		{
			((Component)stampWaku).gameObject.SetActive(true);
			balloon.gameObject.SetActive(false);
			((Component)_image).gameObject.SetActive(false);
			stampWaku.sprite = LoadStampData.ReadStampContent(nakami.StampType, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}

	private void SetBody(JineDrawable nakami)
	{
		if (!(nakami.BodyJp == ""))
		{
			switch (SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value)
			{
			case LanguageType.JP:
				honbun.text = nakami.BodyJp;
				break;
			case LanguageType.CN:
				honbun.text = nakami.BodyCn;
				break;
			case LanguageType.KO:
				honbun.text = nakami.BodyKo;
				break;
			case LanguageType.TW:
				honbun.text = nakami.BodyTw;
				break;
			case LanguageType.VN:
				honbun.text = nakami.BodyVn;
				break;
			case LanguageType.FR:
				honbun.text = nakami.BodyFr;
				break;
			case LanguageType.IT:
				honbun.text = nakami.BodyIt;
				break;
			case LanguageType.GE:
				honbun.text = nakami.BodyGe;
				break;
			case LanguageType.SP:
				honbun.text = nakami.BodySp;
				break;
			case LanguageType.RU:
				honbun.text = nakami.BodyRu;
				break;
			default:
				honbun.text = nakami.BodyEn;
				break;
			}
			if (nakami.JineUserType == JineUserType.ame || nakami.JineUserType == JineUserType.pi)
			{
				((Component)this).GetComponentInChildren<JineWrapper>().Wrap();
			}
		}
	}

	public void OnKidoku(int milliSecond = 1000)
	{
		_kidoku.text = NgoEx.SystemTextFromType(SystemTextType.JINE_Kidoku, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Component)_kidoku).gameObject.GetComponent<CanvasGroup>().alpha = 1f;
	}

	public void OnLanguageUpdated(JineDrawable nakami)
	{
		SetStamp(nakami);
		SetBody(nakami);
		if ((Object)(object)_kidoku != (Object)null && _kidoku.text != "")
		{
			_kidoku.text = NgoEx.SystemTextFromType(SystemTextType.JINE_Kidoku, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
	}
}
