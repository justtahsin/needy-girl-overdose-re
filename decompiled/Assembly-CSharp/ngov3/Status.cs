using System;
using UniRx;

namespace ngov3;

[Serializable]
public struct Status(StatusType type, int startValue, int max, int min = 0, bool dispAsPercent = false)
{
	public StatusType statusType = type;

	public ReactiveProperty<int> currentValue = new ReactiveProperty<int>(startValue);

	public ReactiveProperty<int> todaysDelta = new ReactiveProperty<int>(0);

	public ReactiveProperty<int> delta = new ReactiveProperty<int>(0);

	public ReactiveProperty<int> maxValue = new ReactiveProperty<int>(max);

	public int minValue = min;

	public bool dispAsPercent = dispAsPercent;
}
