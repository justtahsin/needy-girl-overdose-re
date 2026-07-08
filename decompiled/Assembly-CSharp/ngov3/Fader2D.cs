using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace ngov3;

public class Fader2D : MonoBehaviour, IFader
{
	[SerializeField]
	private List<SpriteRenderer> spriteRendererList;

	[SerializeField]
	private List<TMP_Text> textList;

	[SerializeField]
	[Range(0f, 1f)]
	private float alpha = 1f;

	public float Alpha => alpha;

	public void SetAlpha(float alpha)
	{
		this.alpha = alpha;
		spriteRendererList.ForEach(delegate(SpriteRenderer s)
		{
			Color color = s.color;
			color.a = alpha;
			s.color = color;
		});
		textList.ForEach(delegate(TMP_Text t)
		{
			Color color = t.color;
			color.a = alpha;
			t.color = color;
		});
	}

	public async UniTask DOFade(float duration, float endValue, CancellationToken cancellationToken = default(CancellationToken))
	{
		await DOTween.To(() => alpha, delegate(float num)
		{
			alpha = num;
		}, endValue, duration).Play().WithCancellation(cancellationToken);
	}

	public async UniTask DOFade(float duration, float endValue, Ease ease, CancellationToken cancellationToken = default(CancellationToken))
	{
		await DOTween.To(() => alpha, delegate(float num)
		{
			alpha = num;
		}, endValue, duration).SetEase(ease).Play()
			.WithCancellation(cancellationToken);
	}

	private void Start()
	{
		(from _ in this.UpdateAsObservable()
			select Alpha).DistinctUntilChanged().Subscribe(delegate(float alpha)
		{
			spriteRendererList.ForEach(delegate(SpriteRenderer s)
			{
				Color color = s.color;
				color.a = alpha;
				s.color = color;
			});
			textList.ForEach(delegate(TMP_Text t)
			{
				Color color = t.color;
				color.a = alpha;
				t.color = color;
			});
		}).AddTo(base.gameObject);
	}
}
