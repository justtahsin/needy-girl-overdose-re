using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(TMP_Text))]
public class TMPStencilSetter : MonoBehaviour
{
	[SerializeField]
	private int _stencil;

	[SerializeField]
	private bool _active;

	private TMP_Text _tmpText;

	private List<Material> _matInstances = new List<Material>();

	private IDisposable _subMeshSubscribe;

	private void Awake()
	{
		SetStencil();
	}

	public void SetStencil()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		if (!_active)
		{
			_subMeshSubscribe?.Dispose();
			_matInstances = new List<Material>();
			_tmpText = ((Component)this).GetComponent<TMP_Text>();
			Material val = new Material(_tmpText.fontMaterial);
			val.SetFloat("_StencilComp", 3f);
			val.SetFloat("_Stencil", (float)_stencil);
			_tmpText.fontSharedMaterial = val;
			_matInstances.Add(val);
			_subMeshSubscribe = DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<int>(ObserveExtensions.ObserveEveryValueChanged<Transform, int>(((Component)this).transform, (Func<Transform, int>)((Transform x) => x.childCount), (FrameCountType)0, false), (Action<int>)delegate
			{
				SetSubmeshMaterial();
			}), (Component)(object)this);
		}
	}

	private async void SetSubmeshMaterial()
	{
		await UniTask.DelayFrame(1, (PlayerLoopTiming)8, default(CancellationToken), false);
		MeshRenderer[] componentsInChildren = ((Component)this).GetComponentsInChildren<MeshRenderer>();
		if (componentsInChildren.Length == 1)
		{
			return;
		}
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			if (((Renderer)componentsInChildren[i]).material.GetFloat("_Stencil") != (float)_stencil)
			{
				Material val = new Material(((Renderer)componentsInChildren[i]).material);
				val.SetFloat("_StencilComp", 3f);
				val.SetFloat("_Stencil", (float)_stencil);
				((Renderer)componentsInChildren[i]).material = val;
				_matInstances.Add(val);
			}
		}
		_subMeshSubscribe.Dispose();
	}

	private void OnDestroy()
	{
		foreach (Material matInstance in _matInstances)
		{
			Object.Destroy((Object)(object)matInstance);
		}
	}
}
