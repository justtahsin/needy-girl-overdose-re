using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace ngov3;

public class LogWriter
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CLogWriteLoop_003Ed__6 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public LogWriter _003C_003E4__this;

		public CancellationToken cancellationToken;

		private StreamWriter _003CstreamWriter_003E5__2;

		private object _003C_003E7__wrap2;

		private int _003C_003E7__wrap3;

		private Awaiter _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			LogWriter logWriter = _003C_003E4__this;
			try
			{
				TaskAwaiter taskAwaiter;
				if ((uint)num > 1u)
				{
					if (num == 2)
					{
						taskAwaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_01d3;
					}
					_003CstreamWriter_003E5__2 = null;
					_003C_003E7__wrap2 = null;
					_003C_003E7__wrap3 = 0;
				}
				try
				{
					if (num != 0)
					{
						if (num != 1)
						{
							DirectoryInfo directory = new FileInfo(logWriter.LogPath).Directory;
							if (directory != null && !directory.Exists)
							{
								directory.Create();
							}
							_003CstreamWriter_003E5__2 = new StreamWriter(logWriter.LogPath, append: true, Encoding.UTF8);
							goto IL_0075;
						}
						taskAwaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						goto IL_0155;
					}
					Awaiter val = _003C_003Eu__1;
					_003C_003Eu__1 = default(Awaiter);
					num = (_003C_003E1__state = -1);
					goto IL_00df;
					IL_0155:
					taskAwaiter.GetResult();
					goto IL_0075;
					IL_00df:
					((Awaiter)(ref val)).GetResult();
					string value = logWriter.logQueue.Take(cancellationToken);
					taskAwaiter = _003CstreamWriter_003E5__2.WriteLineAsync(value).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = taskAwaiter;
						((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLogWriteLoop_003Ed__6>(ref taskAwaiter, ref this);
						return;
					}
					goto IL_0155;
					IL_0075:
					if (!cancellationToken.IsCancellationRequested)
					{
						SwitchToThreadPoolAwaitable val2 = UniTask.SwitchToThreadPool();
						val = ((SwitchToThreadPoolAwaitable)(ref val2)).GetAwaiter();
						if (!((Awaiter)(ref val)).IsCompleted)
						{
							num = (_003C_003E1__state = 0);
							_003C_003Eu__1 = val;
							((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<Awaiter, _003CLogWriteLoop_003Ed__6>(ref val, ref this);
							return;
						}
						goto IL_00df;
					}
				}
				catch (object obj)
				{
					_003C_003E7__wrap2 = obj;
				}
				if (_003CstreamWriter_003E5__2 != null)
				{
					taskAwaiter = _003CstreamWriter_003E5__2.FlushAsync().GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 2);
						_003C_003Eu__2 = taskAwaiter;
						((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CLogWriteLoop_003Ed__6>(ref taskAwaiter, ref this);
						return;
					}
					goto IL_01d3;
				}
				goto IL_01f0;
				IL_01d3:
				taskAwaiter.GetResult();
				_003CstreamWriter_003E5__2.Close();
				_003CstreamWriter_003E5__2.Dispose();
				goto IL_01f0;
				IL_01f0:
				object obj2 = _003C_003E7__wrap2;
				if (obj2 != null)
				{
					ExceptionDispatchInfo.Capture((obj2 as Exception) ?? throw obj2).Throw();
				}
				_003C_003E7__wrap2 = null;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003CstreamWriter_003E5__2 = null;
				((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003CstreamWriter_003E5__2 = null;
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncUniTaskVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public readonly string LogPath;

	private readonly Dictionary<int, string> logLevelCase = new Dictionary<int, string>
	{
		{ 0, "E" },
		{ 1, "A" },
		{ 2, "W" },
		{ 3, "L" },
		{ 4, "Ex" }
	};

	private const string DateTimeFormat = "yyyyMMddHHmmss";

	private readonly BlockingCollection<string> logQueue = new BlockingCollection<string>(new ConcurrentQueue<string>());

	public LogWriter(string logPath, CancellationToken cancellationToken)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		LogPath = logPath;
		Application.logMessageReceivedThreaded += new LogCallback(OnLogMessageReceivedThreaded);
		UniTaskVoid val = LogWriteLoop(cancellationToken);
		((UniTaskVoid)(ref val)).Forget();
	}

	private void OnLogMessageReceivedThreaded(string condition, string stacktrace, LogType type)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected I4, but got Unknown
		logQueue.Add(DateTimeOffset.Now.ToString("yyyyMMddHHmmss") + " [" + logLevelCase[(int)type] + "] " + condition);
	}

	[AsyncStateMachine(typeof(_003CLogWriteLoop_003Ed__6))]
	private UniTaskVoid LogWriteLoop(CancellationToken cancellationToken)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_003CLogWriteLoop_003Ed__6 _003CLogWriteLoop_003Ed__7 = default(_003CLogWriteLoop_003Ed__6);
		_003CLogWriteLoop_003Ed__7._003C_003Et__builder = AsyncUniTaskVoidMethodBuilder.Create();
		_003CLogWriteLoop_003Ed__7._003C_003E4__this = this;
		_003CLogWriteLoop_003Ed__7.cancellationToken = cancellationToken;
		_003CLogWriteLoop_003Ed__7._003C_003E1__state = -1;
		((AsyncUniTaskVoidMethodBuilder)(ref _003CLogWriteLoop_003Ed__7._003C_003Et__builder)).Start<_003CLogWriteLoop_003Ed__6>(ref _003CLogWriteLoop_003Ed__7);
		return ((AsyncUniTaskVoidMethodBuilder)(ref _003CLogWriteLoop_003Ed__7._003C_003Et__builder)).Task;
	}
}
