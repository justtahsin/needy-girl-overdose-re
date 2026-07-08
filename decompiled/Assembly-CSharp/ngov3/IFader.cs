using System.Threading;
using Cysharp.Threading.Tasks;

namespace ngov3;

public interface IFader
{
	void SetAlpha(float alpha);

	UniTask DOFade(float duration, float endValue, CancellationToken cancellationToken);
}
