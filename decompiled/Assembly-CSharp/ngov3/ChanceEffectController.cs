using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ngov3;

public sealed class ChanceEffectController : SingletonMonoBehaviour<ChanceEffectController>
{
	[SerializeField]
	private List<ChanceEffect> _chanceEffects = new List<ChanceEffect>();

	private ChanceEffect _currentEffect;

	public ReactiveProperty<ChanceEffectType> _current = new ReactiveProperty<ChanceEffectType>();

	public ReactiveProperty<string> _anim = new ReactiveProperty<string>();

	private static string _ANIM_DEFAULT = "default";

	private static string _ANIM_IN = "in";

	private static string _ANIM_WIN_STOP = "win_stop";

	private static string _ANIM_WIN = "win";

	private static string _ANIM_OUT = "out";

	public IReadOnlyList<ChanceEffect> ChanceEffects => _chanceEffects;

	private void Start()
	{
		_current.SkipLatestValueOnSubscribe().Subscribe(delegate(ChanceEffectType effect)
		{
			foreach (ChanceEffect chanceEffect in _chanceEffects)
			{
				bool flag = chanceEffect.Type == effect;
				chanceEffect.Anim.gameObject.SetActive(flag);
				if (flag)
				{
					_currentEffect = chanceEffect;
				}
			}
		}).AddTo(base.gameObject);
		_anim.SkipLatestValueOnSubscribe().Subscribe(delegate(string anim)
		{
			_currentEffect.Anim.Play(anim);
		}).AddTo(base.gameObject);
	}

	public void OnReach(ChanceEffectType type)
	{
		_current.Value = type;
		_currentEffect.Anim.Play(_ANIM_IN);
	}

	public void OnFever()
	{
		_currentEffect.Anim.Play(_ANIM_WIN);
	}

	public void OnFeverStart()
	{
		_currentEffect.Anim.Play(_ANIM_WIN_STOP);
	}

	public void OnOut()
	{
		_currentEffect.Anim.Play(_ANIM_OUT);
	}
}
