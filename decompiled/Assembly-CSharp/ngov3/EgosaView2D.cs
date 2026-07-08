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
using UnityEngine;

namespace ngov3;

public class EgosaView2D : MonoBehaviour, IStorable
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CEgosaAnimation_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EgosaView2D _003C_003E4__this;

		private RectTransform _003Cmusirect_003E5__2;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_0311: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02db: Unknown result type (might be due to invalid IL or missing references)
			//IL_02de: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EgosaView2D egosaView2D = _003C_003E4__this;
			try
			{
				UniTask val2;
				Awaiter val;
				switch (num)
				{
				default:
					AudioManager.Instance.PlaySeByType(SoundType.SE_yokan);
					egosaView2D.musimegane.SetActive(true);
					_003Cmusirect_003E5__2 = egosaView2D.musimegane.GetComponent<RectTransform>();
					egosaView2D.searchText.text = NgoEx.SystemTextFromType(SystemTextType.Search_egosa, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
					((Transform)_003Cmusirect_003E5__2).localPosition = new Vector3(4f, -4f, 0f);
					val2 = UniTask.Delay(120, false, (PlayerLoopTiming)8, egosaView2D._egosaCancelSource.Token, false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEgosaAnimation_003Ed__9>(ref val, ref this);
						return;
					}
					goto IL_00fc;
				case 0:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00fc;
				case 1:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0188;
				case 2:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0214;
				case 3:
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_02a0;
				case 4:
					{
						val = _003C_003Eu__1;
						_003C_003Eu__1 = default(Awaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_02a0:
					((Awaiter)(ref val)).GetResult();
					((Transform)_003Cmusirect_003E5__2).localPosition = new Vector3(0f, 0f, 0f);
					val2 = UniTask.Delay(120, false, (PlayerLoopTiming)8, egosaView2D._egosaCancelSource.Token, false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEgosaAnimation_003Ed__9>(ref val, ref this);
						return;
					}
					break;
					IL_00fc:
					((Awaiter)(ref val)).GetResult();
					((Transform)_003Cmusirect_003E5__2).localPosition = new Vector3(-4f, 4f, 0f);
					val2 = UniTask.Delay(120, false, (PlayerLoopTiming)8, egosaView2D._egosaCancelSource.Token, false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEgosaAnimation_003Ed__9>(ref val, ref this);
						return;
					}
					goto IL_0188;
					IL_0214:
					((Awaiter)(ref val)).GetResult();
					((Transform)_003Cmusirect_003E5__2).localPosition = new Vector3(-4f, -4f, 0f);
					val2 = UniTask.Delay(120, false, (PlayerLoopTiming)8, egosaView2D._egosaCancelSource.Token, false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEgosaAnimation_003Ed__9>(ref val, ref this);
						return;
					}
					goto IL_02a0;
					IL_0188:
					((Awaiter)(ref val)).GetResult();
					((Transform)_003Cmusirect_003E5__2).localPosition = new Vector3(4f, 4f, 0f);
					val2 = UniTask.Delay(120, false, (PlayerLoopTiming)8, egosaView2D._egosaCancelSource.Token, false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CEgosaAnimation_003Ed__9>(ref val, ref this);
						return;
					}
					goto IL_0214;
				}
				((Awaiter)(ref val)).GetResult();
				egosaView2D.musimegane.SetActive(false);
				if (SingletonMonoBehaviour<EventManager>.Instance.isTestScene)
				{
					egosaView2D.ShowAllEgosas();
				}
				if (!SingletonMonoBehaviour<EventManager>.Instance.isHorror)
				{
					egosaView2D.UpdateContents();
				}
				else
				{
					egosaView2D.UpdateHorror(SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayIndex) - 24);
				}
				AudioManager.Instance?.PlaySeByType(SoundType.SE_tweet_kusorep);
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cmusirect_003E5__2 = null;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cmusirect_003E5__2 = null;
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
	private GameObject musimegane;

	[SerializeField]
	private EgosaRepView2D kusoPrefab;

	[SerializeField]
	private Transform kusoParent;

	[SerializeField]
	private TMP_Text searchText;

	[SerializeField]
	private VerticalGridLayout2D verticalGridLayout2D;

	private CancellationTokenSource _egosaCancelSource;

	private void Start()
	{
	}

	public void OnPicked()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		_egosaCancelSource = new CancellationTokenSource();
		if (_egosaCancelSource != null)
		{
			EgosaAnimation();
		}
	}

	public void OnStored()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (_egosaCancelSource == null)
		{
			return;
		}
		_egosaCancelSource.Cancel();
		_egosaCancelSource.Dispose();
		foreach (Transform item in ((Component)kusoParent).transform)
		{
			Object.Destroy((Object)(object)((Component)item).gameObject);
		}
	}

	[AsyncStateMachine(typeof(_003CEgosaAnimation_003Ed__9))]
	private UniTask EgosaAnimation()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CEgosaAnimation_003Ed__9 _003CEgosaAnimation_003Ed__10 = default(_003CEgosaAnimation_003Ed__9);
		_003CEgosaAnimation_003Ed__10._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CEgosaAnimation_003Ed__10._003C_003E4__this = this;
		_003CEgosaAnimation_003Ed__10._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CEgosaAnimation_003Ed__10._003C_003Et__builder)).Start<_003CEgosaAnimation_003Ed__9>(ref _003CEgosaAnimation_003Ed__10);
		return ((AsyncUniTaskMethodBuilder)(ref _003CEgosaAnimation_003Ed__10._003C_003Et__builder)).Task;
	}

	private void ShowAllEgosas()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		for (int i = 0; i < NgoEx.getEgosas().ToList().Count - 1; i++)
		{
			EgosaRepView2D egosaRepView2D = Object.Instantiate<EgosaRepView2D>(kusoPrefab, kusoParent);
			((Component)egosaRepView2D).gameObject.transform.SetAsLastSibling();
			egosaRepView2D.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, i)));
			egosaRepView2D.Show();
			verticalGridLayout2D.AddLayoutObject(egosaRepView2D);
		}
	}

	private int ContentCount(int follower)
	{
		return Mathf.Max((int)Mathf.Log10((float)follower) - 4, 1);
	}

	private void UpdateContents()
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		string text = SingletonMonoBehaviour<EventManager>.Instance.dayActionHistory.FindLast((string st) => st.Contains("_"));
		if (text != null)
		{
			EgosaRepView2D egosaRepView2D = Object.Instantiate<EgosaRepView2D>(kusoPrefab, kusoParent);
			((Component)egosaRepView2D).gameObject.transform.SetAsLastSibling();
			egosaRepView2D.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "haisin", text)));
			egosaRepView2D.Show();
			verticalGridLayout2D.AddLayoutObject(egosaRepView2D);
		}
		int status = SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.Follower);
		EgosaRepView2D egosaRepView2D2 = Object.Instantiate<EgosaRepView2D>(kusoPrefab, kusoParent);
		((Component)egosaRepView2D2).gameObject.transform.SetAsLastSibling();
		egosaRepView2D2.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "follower", getFollowerRank(status))));
		egosaRepView2D2.Show();
		verticalGridLayout2D.AddLayoutObject(egosaRepView2D2);
		for (int num = 0; num < ContentCount(status); num++)
		{
			EgosaRepView2D egosaRepView2D3 = Object.Instantiate<EgosaRepView2D>(kusoPrefab, kusoParent);
			((Component)egosaRepView2D3).gameObject.transform.SetAsLastSibling();
			egosaRepView2D3.SetData(new KusoRepDrawable(NgoEx.EgosaString(value)));
			egosaRepView2D3.Show();
			verticalGridLayout2D.AddLayoutObject(egosaRepView2D3);
		}
		AlphaLevel alphaLevel = ((SingletonMonoBehaviour<EventManager>.Instance.nextActionHint.FirstOrDefault((Tuple<ActionType, AlphaLevel> hint) => hint.Item1 == ActionType.InternetPoketterEgosa) == null) ? null : SingletonMonoBehaviour<EventManager>.Instance.nextActionHint.FirstOrDefault((Tuple<ActionType, AlphaLevel> hint) => hint.Item1 == ActionType.InternetPoketterEgosa).Item2);
		if (alphaLevel != null && alphaLevel.alphaType == AlphaType.PR && alphaLevel.level == 5)
		{
			EgosaRepView2D egosaRepView2D4 = Object.Instantiate<EgosaRepView2D>(kusoPrefab, kusoParent);
			((Component)egosaRepView2D4).gameObject.transform.SetAsLastSibling();
			egosaRepView2D4.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "NetaGet_PR5", "NetaGet_PR5")));
			egosaRepView2D4.Show();
			verticalGridLayout2D.AddLayoutObject(egosaRepView2D4);
		}
	}

	private void UpdateHorror(int horrorDay)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		LanguageType value = SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value;
		int num = 2;
		if (horrorDay == 2 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) == 0)
		{
			num = 10;
			for (int i = 0; i < num; i++)
			{
				EgosaRepView2D egosaRepView2D = Object.Instantiate<EgosaRepView2D>(kusoPrefab, kusoParent);
				((Component)egosaRepView2D).gameObject.transform.SetAsLastSibling();
				egosaRepView2D.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, i, "horror", "horrorday2Before")));
				egosaRepView2D.Show();
				verticalGridLayout2D.AddLayoutObject(egosaRepView2D);
			}
		}
		if (horrorDay == 2 && SingletonMonoBehaviour<StatusManager>.Instance.GetStatus(StatusType.DayPart) != 0)
		{
			num = 8;
			for (int j = 0; j < num; j++)
			{
				EgosaRepView2D egosaRepView2D2 = Object.Instantiate<EgosaRepView2D>(kusoPrefab, kusoParent);
				((Component)egosaRepView2D2).gameObject.transform.SetAsLastSibling();
				egosaRepView2D2.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, j, "horror", "horrorday2Afterr")));
				egosaRepView2D2.Show();
				verticalGridLayout2D.AddLayoutObject(egosaRepView2D2);
			}
		}
		if (horrorDay == 1)
		{
			string text = SingletonMonoBehaviour<EventManager>.Instance.dayActionHistory.FindLast((string st) => st.Contains("_"));
			if (text != null)
			{
				EgosaRepView2D egosaRepView2D3 = Object.Instantiate<EgosaRepView2D>(kusoPrefab, kusoParent);
				((Component)egosaRepView2D3).gameObject.transform.SetAsLastSibling();
				egosaRepView2D3.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, "haisin", text)));
				egosaRepView2D3.Show();
				verticalGridLayout2D.AddLayoutObject(egosaRepView2D3);
			}
			for (int num2 = 0; num2 < num; num2++)
			{
				EgosaRepView2D egosaRepView2D4 = Object.Instantiate<EgosaRepView2D>(kusoPrefab, kusoParent);
				((Component)egosaRepView2D4).gameObject.transform.SetAsLastSibling();
				egosaRepView2D4.SetData(new KusoRepDrawable(NgoEx.EgosaString(value, num2, "horror", "horrorday1")));
				egosaRepView2D4.Show();
				verticalGridLayout2D.AddLayoutObject(egosaRepView2D4);
			}
		}
	}

	private string getFollowerRank(int follower)
	{
		if (follower < 10000)
		{
			return "small";
		}
		if (follower < 100000)
		{
			return "middle";
		}
		return "large";
	}
}
