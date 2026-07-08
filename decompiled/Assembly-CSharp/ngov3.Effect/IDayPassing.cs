using Cysharp.Threading.Tasks;

namespace ngov3.Effect;

public interface IDayPassing
{
	UniTask yearsPass(bool isBackObi = true);
}
