using System;
using System.Collections.Generic;
using NGO;
using UniRx;

namespace ngov3;

public sealed class WristcutModel : IDisposable
{
	public List<Cut> _history;

	private int _cutCount;

	public Subject<Cut> OnCut;

	public int CutCount => _cutCount;

	public WristcutModel(int day)
	{
		Initialize(day);
	}

	private void Initialize(int day)
	{
		OnCut = new Subject<Cut>();
		_cutCount = FetchCutCount();
		IDisposable dispose = null;
		dispose = ObservableExtensions.Subscribe<Cut>((IObservable<Cut>)OnCut, (Action<Cut>)delegate
		{
			AudioManager.Instance?.PlaySeByType(SoundType.SE_zubasi);
		}, (Action)delegate
		{
			dispose.Dispose();
		});
	}

	private int FetchCutCount()
	{
		return 3;
	}

	public void Dispose()
	{
		OnCut.OnCompleted();
		OnCut.Dispose();
	}
}
