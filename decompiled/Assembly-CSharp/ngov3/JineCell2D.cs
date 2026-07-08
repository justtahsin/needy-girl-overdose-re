using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ngov3;

public class JineCell2D : MonoBehaviour, ILayoutElement2D, IRectMaskableObject
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public JineDrawable nakami;

		public JineCell2D _003C_003E4__this;

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
	private sealed class _003C_003Ec__DisplayClass42_1
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
	private struct _003CsetData_003Ed__42 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public JineDrawable nakami;

		public JineCell2D _003C_003E4__this;

		private _003C_003Ec__DisplayClass42_1 _003C_003E8__1;

		private _003C_003Ec__DisplayClass42_0 _003C_003E8__2;

		public int kidokMilliSecond;

		private SpriteRenderer _003C_003E7__wrap1;

		private Awaiter<Sprite> _003C_003Eu__1;

		private Awaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_035e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0366: Unknown result type (might be due to invalid IL or missing references)
			//IL_031b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0320: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			JineCell2D jineCell2D = _003C_003E4__this;
			try
			{
				Awaiter val;
				Awaiter<Sprite> val2;
				if (num != 0)
				{
					if (num == 1)
					{
						val = _003C_003Eu__2;
						_003C_003Eu__2 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0375;
					}
					_003C_003E8__2 = new _003C_003Ec__DisplayClass42_0();
					_003C_003E8__2.nakami = nakami;
					_003C_003E8__2._003C_003E4__this = _003C_003E4__this;
					jineCell2D.nakami = _003C_003E8__2.nakami;
					jineCell2D.cellalpha.SetAlpha(0f);
					jineCell2D.SetStamp(_003C_003E8__2.nakami);
					if (!_003C_003E8__2.nakami.ImageId.IsNotEmpty())
					{
						goto IL_02a7;
					}
					_003C_003E8__1 = new _003C_003Ec__DisplayClass42_1();
					((Component)jineCell2D._image).gameObject.SetActive(true);
					_003C_003E8__1.resource = jineCell2D._resourceMaster.ResourceList.FirstOrDefault((ResourceLocal r) => r.FileName == _003C_003E8__2.nakami.ImageId);
					if (_003C_003E8__1.resource == null)
					{
						Debug.Log((object)("ImageIDが見つからず" + _003C_003E8__2.nakami.ImageId));
						((Component)jineCell2D._image).gameObject.SetActive(false);
						goto IL_02a0;
					}
					Debug.Log((object)("ImageID=" + _003C_003E8__2.nakami.ImageId));
					SingletonMonoBehaviour<Settings>.Instance.addImage(_003C_003E8__2.nakami.ImageId);
					_003C_003E7__wrap1 = jineCell2D._image;
					val2 = LoadPictures.LoadPictureAsync(_003C_003E8__1.resource.FileName, LoadPictures.PictureType.JINE).GetAwaiter();
					if (!val2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter<Sprite>, _003CsetData_003Ed__42>(ref val2, ref this);
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
				jineCell2D._imageFileName = _003C_003E8__1.resource.FileName;
				Rect rect = ((Component)jineCell2D._image).GetComponent<RectTransform>().rect;
				Vector2 size = ((Rect)(ref rect)).size;
				jineCell2D._image.size = size;
				((Component)jineCell2D._image).GetComponent<BoxCollider2D>().size = size;
				Button component = ((Component)jineCell2D._image).gameObject.GetComponent<Button>();
				DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(component), (Action<Unit>)delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					ImageViewerHelper.OpenImageViewer(_003C_003E8__1.resource.FileName);
				}), ((Component)component).gameObject);
				if ((Object)(object)jineCell2D.imageOverHungObject != (Object)null)
				{
					jineCell2D.imageOverHungObject.SetParentRect(((Component)((Component)jineCell2D).transform.parent.parent).GetComponent<RectTransform>());
				}
				goto IL_02a0;
				IL_02a0:
				_003C_003E8__1 = null;
				goto IL_02a7;
				IL_02a7:
				jineCell2D.SetBody(_003C_003E8__2.nakami);
				jineCell2D.SetLocalize(_003C_003E8__2.nakami);
				if (_003C_003E8__2.nakami.JineUserType == JineUserType.pi && kidokMilliSecond == 1)
				{
					jineCell2D.OnKidoku();
				}
				jineCell2D.SetLayout(_003C_003E8__2.nakami);
				UniTask val3 = jineCell2D.cellalpha.DOFade(0.4f, 1f);
				val = ((UniTask)(ref val3)).GetAwaiter();
				if (!((Awaiter)(ref val)).IsCompleted)
				{
					num = (_003C_003E1__state = 1);
					_003C_003Eu__2 = val;
					((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CsetData_003Ed__42>(ref val, ref this);
					return;
				}
				goto IL_0375;
				IL_0375:
				((Awaiter)(ref val)).GetResult();
				if (_003C_003E8__2.nakami.JineUserType == JineUserType.pi && kidokMilliSecond > 1)
				{
					DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<long>(Observable.Timer(TimeSpan.FromSeconds((double)(_003C_003E8__2.nakami.kidokumillisecond / 1000))), (Action<long>)delegate
					{
						_003C_003E8__2._003C_003E4__this.OnKidoku();
					}), (Component)(object)jineCell2D);
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
	private TMP_Text _kidoku;

	[SerializeField]
	private SpriteRenderer stampWaku;

	[SerializeField]
	private SpriteRenderer _image;

	[SerializeField]
	private GameObject balloon;

	[SerializeField]
	private SpriteRenderer _balloonRend;

	[SerializeField]
	private SpriteRenderer _tailRend;

	[SerializeField]
	private Fader2D cellalpha;

	private bool langChangeSetted;

	public int _kidokuMilliSecondRange = 1000;

	[SerializeField]
	private RectTransform rectTransform;

	private LayoutElement2DType layoutElement2DType;

	private Subject<Unit> onDestroySubject = new Subject<Unit>();

	private string _imageFileName = "N/A";

	[SerializeField]
	private ScrolllOverHungObject imageOverHungObject;

	private JineDrawable nakami;

	[Header("Layout Component")]
	[SerializeField]
	private LayoutElement cellElement;

	[SerializeField]
	private LayoutElement nakamiElement;

	[SerializeField]
	private LayoutElement balloonElement;

	[SerializeField]
	private LayoutElement honbunElement;

	[SerializeField]
	private LayoutElement stampElement;

	[SerializeField]
	private LayoutElement imageElement;

	[SerializeField]
	private float balloonHightOffset;

	public LayoutElement2DType LayoutElement2DType => layoutElement2DType;

	public RectTransform RectTransform => rectTransform;

	public SpriteRenderer BalloonRend => _balloonRend;

	public SpriteRenderer TailRend => _tailRend;

	public IObservable<Unit> OnDestroyObservable => (IObservable<Unit>)onDestroySubject;

	private void Start()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)imageOverHungObject != (Object)null)
		{
			imageOverHungObject.SetParentRect(((Component)((Component)this).transform.parent.parent).GetComponent<RectTransform>());
		}
		rectTransform.offsetMin = new Vector2(0f, rectTransform.offsetMin.y);
		rectTransform.offsetMax = new Vector2(0f, rectTransform.offsetMax.y);
		cellalpha.SetAlpha(0f);
	}

	private void OnDestroy()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		onDestroySubject.OnNext(Unit.Default);
		onDestroySubject.OnCompleted();
		if (_imageFileName != "N/A")
		{
			LoadPictures.DeleteCache(_imageFileName, LoadPictures.PictureType.JINE);
		}
	}

	public void setDay(int Day)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		changeDay(Day);
		UniTaskExtensions.Forget(cellalpha.DOFade(0.2f, 1f, UniTaskCancellationExtensions.GetCancellationTokenOnDestroy((MonoBehaviour)(object)this)));
		setDayLang(Day);
		SetLayoutSeparator();
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
				SetLayoutSeparator();
			}), ((Component)this).gameObject);
			langChangeSetted = true;
		}
	}

	public void setDayPart(int DayPart)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		changeDayPart(DayPart);
		UniTaskExtensions.Forget(cellalpha.DOFade(0.2f, 1f, UniTaskCancellationExtensions.GetCancellationTokenOnDestroy((MonoBehaviour)(object)this)));
		setDaypartLang(DayPart);
		SetLayoutSeparator();
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
				SetLayoutSeparator();
			}), ((Component)this).gameObject);
			langChangeSetted = true;
		}
	}

	[AsyncStateMachine(typeof(_003CsetData_003Ed__42))]
	public UniTask setData(JineDrawable nakami, int kidokMilliSecond = 100)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		_003CsetData_003Ed__42 _003CsetData_003Ed__43 = default(_003CsetData_003Ed__42);
		_003CsetData_003Ed__43._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CsetData_003Ed__43._003C_003E4__this = this;
		_003CsetData_003Ed__43.nakami = nakami;
		_003CsetData_003Ed__43.kidokMilliSecond = kidokMilliSecond;
		_003CsetData_003Ed__43._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CsetData_003Ed__43._003C_003Et__builder)).Start<_003CsetData_003Ed__42>(ref _003CsetData_003Ed__43);
		return ((AsyncUniTaskMethodBuilder)(ref _003CsetData_003Ed__43._003C_003Et__builder)).Task;
	}

	private void SetLocalize(JineDrawable nakami)
	{
		if (!langChangeSetted)
		{
			DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<LanguageType>((IObservable<LanguageType>)SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage, (Action<LanguageType>)async delegate
			{
				await UniTask.DelayFrame(1, (PlayerLoopTiming)8, default(CancellationToken), false);
				OnLanguageUpdated(nakami);
				SetLayout(nakami);
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
			honbun.text = NgoEx.GetJineHonbun(nakami, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
			if (nakami.JineUserType == JineUserType.ame || nakami.JineUserType == JineUserType.pi)
			{
				((Component)this).GetComponentInChildren<JineWrapper>().Wrap();
			}
		}
	}

	public void OnKidoku(int milliSecond = 1000)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		_kidoku.text = NgoEx.SystemTextFromType(SystemTextType.JINE_Kidoku, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		((Graphic)_kidoku).color = Color.white;
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

	public void SetUpMask(RectTransform targetMaskRect)
	{
	}

	private void SetLayout(JineDrawable nakami)
	{
		switch (nakami.JineUserType)
		{
		case JineUserType.ame:
			SetLayoutAme();
			break;
		case JineUserType.pi:
			SetLayoutPi();
			break;
		case JineUserType.separator:
			SetLayoutSeparator();
			break;
		case JineUserType.timeSeparator:
			SetLayoutSeparator();
			break;
		case JineUserType.eventSeparator:
			SetLayoutSeparator();
			break;
		}
	}

	[ContextMenu("\ufffd\ufffd\ufffdC\ufffdA\ufffdE\ufffdg\ufffdm\ufffdF(Ame)")]
	private void SetLayoutAme()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		float num = 10f;
		if (((Component)honbunElement).gameObject.activeInHierarchy)
		{
			float num2 = 450f;
			RectTransform component = ((Component)honbunElement).GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(num2, 0f);
			honbunElement.minWidth = Mathf.Min(honbun.preferredWidth, num2);
			component.sizeDelta = new Vector2(honbunElement.minWidth, 0f);
			honbunElement.minHeight = honbun.preferredHeight;
			component.sizeDelta = new Vector2(honbunElement.minWidth, honbunElement.minHeight);
		}
		if (((Component)balloonElement).gameObject.activeInHierarchy)
		{
			RectTransform component2 = ((Component)balloonElement).GetComponent<RectTransform>();
			balloonElement.minWidth = honbunElement.minWidth;
			balloonElement.minHeight = honbunElement.minHeight;
			component2.sizeDelta = new Vector2(balloonElement.minWidth, balloonElement.minHeight);
			component2.anchoredPosition = new Vector2(component2.sizeDelta.x / 2f, (0f - component2.sizeDelta.y) / 2f);
		}
		if (((Component)imageElement).gameObject.activeInHierarchy)
		{
			RectTransform component3 = ((Component)imageElement).GetComponent<RectTransform>();
			if (((Component)balloonElement).gameObject.activeInHierarchy)
			{
				component3.anchoredPosition = new Vector2(component3.sizeDelta.x / 2f, 0f - (balloonElement.minHeight + num + component3.sizeDelta.y / 2f));
			}
			else
			{
				component3.anchoredPosition = new Vector2(component3.sizeDelta.x / 2f, (0f - component3.sizeDelta.y) / 2f);
			}
		}
		RectTransform component4 = ((Component)nakamiElement).GetComponent<RectTransform>();
		float num3 = 0f;
		float num4 = 0f;
		if (((Component)balloonElement).gameObject.activeInHierarchy)
		{
			num3 = Mathf.Max(num3, balloonElement.minWidth);
			num4 += balloonElement.minHeight;
		}
		if (((Component)imageElement).gameObject.activeInHierarchy)
		{
			num3 = Mathf.Max(num3, imageElement.minWidth);
			num4 += imageElement.minHeight;
			if (((Component)balloonElement).gameObject.activeInHierarchy)
			{
				num4 += num;
			}
		}
		if (((Component)stampElement).gameObject.activeInHierarchy)
		{
			num3 = Mathf.Max(num3, stampElement.minWidth);
			num4 += stampElement.minHeight;
		}
		nakamiElement.minWidth = num3;
		nakamiElement.minHeight = num4;
		component4.sizeDelta = new Vector2(nakamiElement.minWidth, nakamiElement.minHeight);
		RectTransform component5 = ((Component)this).GetComponent<RectTransform>();
		cellElement.minHeight = Mathf.Max(nakamiElement.minHeight, 50f);
		Vector2 sizeDelta = component5.sizeDelta;
		sizeDelta.y = cellElement.minHeight;
		component5.sizeDelta = sizeDelta;
		Debug.Log((object)honbunElement.minWidth);
		Debug.Log((object)balloonElement.minWidth);
		Debug.Log((object)nakamiElement.minWidth);
	}

	[ContextMenu("\ufffd\ufffd\ufffdC\ufffdA\ufffdE\ufffdg\ufffdm\ufffdF(Pi)")]
	private void SetLayoutPi()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		if (((Component)honbunElement).gameObject.activeInHierarchy)
		{
			RectTransform component = ((Component)honbunElement).GetComponent<RectTransform>();
			honbunElement.minWidth = honbun.preferredWidth;
			honbunElement.minHeight = honbun.preferredHeight;
			component.sizeDelta = new Vector2(honbunElement.minWidth, honbunElement.minHeight + balloonHightOffset);
		}
		if (((Component)balloonElement).gameObject.activeInHierarchy)
		{
			RectTransform component2 = ((Component)balloonElement).GetComponent<RectTransform>();
			balloonElement.minWidth = honbunElement.minWidth;
			balloonElement.minHeight = honbunElement.minHeight;
			component2.sizeDelta = new Vector2(balloonElement.minWidth, balloonElement.minHeight + balloonHightOffset);
			component2.anchoredPosition = new Vector2((0f - component2.sizeDelta.x) / 2f, (0f - component2.sizeDelta.y) / 2f);
		}
		RectTransform component3 = ((Component)this).GetComponent<RectTransform>();
		if (((Component)balloonElement).gameObject.activeInHierarchy)
		{
			cellElement.minHeight = balloonElement.minHeight;
		}
		else
		{
			cellElement.minHeight = stampElement.minHeight;
		}
		Vector2 sizeDelta = component3.sizeDelta;
		sizeDelta.y = cellElement.minHeight;
		component3.sizeDelta = sizeDelta;
		RectTransform component4 = ((Component)_kidoku).GetComponent<RectTransform>();
		if (((Component)balloonElement).gameObject.activeInHierarchy)
		{
			component4.anchoredPosition = new Vector2(0f - (balloonElement.minWidth - 40f), component4.anchoredPosition.y);
		}
		else
		{
			component4.anchoredPosition = new Vector2(0f - (stampElement.minWidth - 40f), component4.anchoredPosition.y);
		}
	}

	[ContextMenu("\ufffd\ufffd\ufffdC\ufffdA\ufffdE\ufffdg\ufffdm\ufffdF(Separator)")]
	private void SetLayoutSeparator()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		float num = 160f;
		float num2 = 450f;
		RectTransform component = ((Component)honbunElement).GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(num2, 0f);
		honbunElement.minWidth = Mathf.Clamp(honbun.preferredWidth, num, num2);
		component.sizeDelta = new Vector2(honbunElement.minWidth, 0f);
		honbunElement.minHeight = honbun.preferredHeight;
		component.sizeDelta = new Vector2(honbunElement.minWidth, honbunElement.minHeight);
		RectTransform component2 = ((Component)balloonElement).GetComponent<RectTransform>();
		balloonElement.minWidth = honbunElement.minWidth;
		balloonElement.minHeight = honbunElement.minHeight;
		component2.sizeDelta = new Vector2(balloonElement.minWidth, balloonElement.minHeight);
	}
}
