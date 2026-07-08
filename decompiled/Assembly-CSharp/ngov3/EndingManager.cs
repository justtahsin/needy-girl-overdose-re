using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using NGO;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ngov3;

public class EndingManager : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003COnAnykeyAsync_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public EndingManager _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			EndingManager endingManager = _003C_003E4__this;
			try
			{
				Awaiter val;
				if (num == 0)
				{
					val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00c0;
				}
				AudioManager.Instance.StopAll();
				if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Jisatu)
				{
					SingletonMonoBehaviour<EventManager>.Instance.nowEnding = EndingType.Ending_None;
					Resources.UnloadUnusedAssets();
					UniTask val2 = UniTask.Delay(1400, false, (PlayerLoopTiming)8, default(CancellationToken), false);
					val = ((UniTask)(ref val2)).GetAwaiter();
					if (!((Awaiter)(ref val)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003COnAnykeyAsync_003Ed__10>(ref val, ref this);
						return;
					}
					goto IL_00c0;
				}
				SingletonMonoBehaviour<EventManager>.Instance.AddEvent<Event_Rentan_Comeback>();
				Object.Destroy((Object)(object)((Component)endingManager).gameObject);
				goto end_IL_000e;
				IL_00c0:
				((Awaiter)(ref val)).GetResult();
				endingManager.asyncLoad.allowSceneActivation = true;
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
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
	private TMP_Text _summary;

	[SerializeField]
	private GameObject _endingAchievement;

	[SerializeField]
	private GameObject _achievedBlock;

	[SerializeField]
	private GameObject _unachievedBlock;

	[SerializeField]
	private GameObject _achievingBlock;

	[SerializeField]
	private Window _windowPoketter;

	private EndingType end;

	private AsyncOperation asyncLoad;

	private CancellationToken token;

	private void Awake()
	{
		token = UniTaskCancellationExtensions.GetCancellationTokenOnDestroy((MonoBehaviour)(object)this);
		token.ThrowIfCancellationRequested();
		PostEffectManager.Instance.ResetShader();
		end = SingletonMonoBehaviour<EventManager>.Instance.nowEnding;
		Transform transform = _endingAchievement.transform;
		List<EndingType> mitaEnd = SingletonMonoBehaviour<Settings>.Instance.mitaEnd;
		string[] names = Enum.GetNames(typeof(EndingType));
		foreach (string id in names)
		{
			if (!(id == "Ending_None") && !(id == "Ending_Completed") && !(id == "Ending_NetShut"))
			{
				if (id == end.ToString())
				{
					Object.Instantiate<GameObject>(_achievingBlock, transform);
				}
				else if (mitaEnd.Exists((EndingType gotend) => gotend.ToString() == id))
				{
					Object.Instantiate<GameObject>(_achievedBlock, transform);
				}
				else
				{
					Object.Instantiate<GameObject>(_unachievedBlock, transform);
				}
			}
		}
		_summary.text = GetEndingName(end, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		NgoEx.ChangeCursor(isLoading: false);
		AudioManager.Instance.StopAll();
		AudioManager.Instance.PlaySeByType(SoundType.SE_bluescreen);
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(((Component)this).GetComponent<Button>()), (Action<Unit>)delegate
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			UniTaskExtensions.Forget(OnAnykeyAsync(end, token));
		}), ((Component)this).gameObject);
		SingletonMonoBehaviour<Settings>.Instance.mitaEnd.Add(end);
		SingletonMonoBehaviour<Settings>.Instance.Save();
		if (SingletonMonoBehaviour<EventManager>.Instance.nowEnding != EndingType.Ending_Jisatu)
		{
			string text = (SingletonMonoBehaviour<Settings>.Instance.checkAllZipUnlocked() ? "BiosToLoad" : "ChooseZip");
			asyncLoad = SceneManager.LoadSceneAsync(text);
			asyncLoad.allowSceneActivation = false;
		}
	}

	[AsyncStateMachine(typeof(_003COnAnykeyAsync_003Ed__10))]
	private UniTask OnAnykeyAsync(EndingType end, CancellationToken token = default(CancellationToken))
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003COnAnykeyAsync_003Ed__10 _003COnAnykeyAsync_003Ed__11 = default(_003COnAnykeyAsync_003Ed__10);
		_003COnAnykeyAsync_003Ed__11._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003COnAnykeyAsync_003Ed__11._003C_003E4__this = this;
		_003COnAnykeyAsync_003Ed__11._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003COnAnykeyAsync_003Ed__11._003C_003Et__builder)).Start<_003COnAnykeyAsync_003Ed__10>(ref _003COnAnykeyAsync_003Ed__11);
		return ((AsyncUniTaskMethodBuilder)(ref _003COnAnykeyAsync_003Ed__11._003C_003Et__builder)).Task;
	}

	private string GetEndingName(EndingType end, LanguageType lang)
	{
		EndingMaster.Param param = NgoEx.EndingFromType(end);
		return lang switch
		{
			LanguageType.JP => param.EndingNameJp, 
			LanguageType.CN => param.EndingNameCn, 
			LanguageType.KO => param.EndingNameKo, 
			LanguageType.TW => param.EndingNameTw, 
			LanguageType.VN => param.EndingNameVn, 
			LanguageType.FR => param.EndingNameFr, 
			LanguageType.IT => param.EndingNameIt, 
			LanguageType.GE => param.EndingNameGe, 
			LanguageType.SP => param.EndingNameSp, 
			LanguageType.RU => param.EndingNameRu, 
			_ => param.EndingNameEn, 
		};
	}
}
