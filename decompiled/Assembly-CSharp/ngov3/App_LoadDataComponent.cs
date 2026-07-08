using System;
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

public class App_LoadDataComponent : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CStartGame_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public App_LoadDataComponent _003C_003E4__this;

		private Awaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			App_LoadDataComponent app_LoadDataComponent = _003C_003E4__this;
			try
			{
				Awaiter val2;
				if (num != 0)
				{
					AudioManager.Instance.StopBgm();
					PostEffectManager.Instance.ResetShader();
					SingletonMonoBehaviour<Settings>.Instance.nowSaveFile = "";
					SingletonMonoBehaviour<Settings>.Instance.isBackToLoad = false;
					AudioManager.Instance.PlaySeByType(SoundType.SE_command_execute);
					SingletonMonoBehaviour<Settings>.Instance.saveNumber = app_LoadDataComponent._DataNumber;
					UniTask val = UnityAsyncExtensions.ToUniTask(Resources.UnloadUnusedAssets(), (IProgress<float>)null, (PlayerLoopTiming)8, default(CancellationToken), false);
					val2 = ((UniTask)(ref val)).GetAwaiter();
					if (!((Awaiter)(ref val2)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = val2;
						((AsyncUniTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CStartGame_003Ed__6>(ref val2, ref this);
						return;
					}
				}
				else
				{
					val2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
				}
				((Awaiter)(ref val2)).GetResult();
				SceneManager.LoadScene("WindowUITestScene");
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
	private TMP_Text _Hyouji;

	[SerializeField]
	private int _DataNumber;

	[SerializeField]
	private Transform _DataContainer;

	[SerializeField]
	private DataPrefab _DataPrefab;

	[SerializeField]
	private Button _NewGame;

	public void Awake()
	{
		_Hyouji.text = $"Data{_DataNumber}";
		for (int num = 30; num >= 1; num--)
		{
			if (SaveRelayer.IsSlotDataExists($"Data{_DataNumber}_Day{num}{SaveRelayer.EXTENTION}"))
			{
				Object.Instantiate<DataPrefab>(_DataPrefab, _DataContainer).SetLoadable(_DataNumber, num);
			}
		}
		if (SaveRelayer.IsSlotDataExists($"Data{_DataNumber}_Day1{SaveRelayer.EXTENTION}"))
		{
			((Component)_NewGame).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame01, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		else
		{
			((Component)_NewGame).GetComponentInChildren<TMP_Text>().text = NgoEx.SystemTextFromType(SystemTextType.Start_Menu_Newgame00, SingletonMonoBehaviour<Settings>.Instance.CurrentLanguage.Value);
		}
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<Unit>(UnityUIComponentExtensions.OnClickAsObservable(_NewGame), (Action<Unit>)delegate
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			StartGame();
		}), ((Component)this).gameObject);
	}

	[AsyncStateMachine(typeof(_003CStartGame_003Ed__6))]
	private UniTask StartGame()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_003CStartGame_003Ed__6 _003CStartGame_003Ed__7 = default(_003CStartGame_003Ed__6);
		_003CStartGame_003Ed__7._003C_003Et__builder = AsyncUniTaskMethodBuilder.Create();
		_003CStartGame_003Ed__7._003C_003E4__this = this;
		_003CStartGame_003Ed__7._003C_003E1__state = -1;
		((AsyncUniTaskMethodBuilder)(ref _003CStartGame_003Ed__7._003C_003Et__builder)).Start<_003CStartGame_003Ed__6>(ref _003CStartGame_003Ed__7);
		return ((AsyncUniTaskMethodBuilder)(ref _003CStartGame_003Ed__7._003C_003Et__builder)).Task;
	}
}
