using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ngov3;

public class LogWriter
{
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
		LogPath = logPath;
		Application.logMessageReceivedThreaded += OnLogMessageReceivedThreaded;
		LogWriteLoop(cancellationToken).Forget();
	}

	private void OnLogMessageReceivedThreaded(string condition, string stacktrace, LogType type)
	{
		logQueue.Add(DateTimeOffset.Now.ToString("yyyyMMddHHmmss") + " [" + logLevelCase[(int)type] + "] " + condition);
	}

	private async UniTaskVoid LogWriteLoop(CancellationToken cancellationToken)
	{
		StreamWriter streamWriter = null;
		try
		{
			DirectoryInfo directory = new FileInfo(LogPath).Directory;
			if (directory != null && !directory.Exists)
			{
				directory.Create();
			}
			streamWriter = new StreamWriter(LogPath, append: true, Encoding.UTF8);
			while (!cancellationToken.IsCancellationRequested)
			{
				await UniTask.SwitchToThreadPool();
				string value = logQueue.Take(cancellationToken);
				await streamWriter.WriteLineAsync(value);
			}
		}
		finally
		{
			if (streamWriter != null)
			{
				await streamWriter.FlushAsync();
				streamWriter.Close();
				streamWriter.Dispose();
			}
		}
	}
}
