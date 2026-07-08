using System;
using System.Collections.Generic;
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
		if (!_active)
		{
			_subMeshSubscribe?.Dispose();
			_matInstances = new List<Material>();
			_tmpText = GetComponent<TMP_Text>();
			Material material = new Material(_tmpText.fontMaterial);
			material.SetFloat("_StencilComp", 3f);
			material.SetFloat("_Stencil", _stencil);
			_tmpText.fontSharedMaterial = material;
			_matInstances.Add(material);
			_subMeshSubscribe = base.transform.ObserveEveryValueChanged((Transform x) => x.childCount).Subscribe(delegate
			{
				SetSubmeshMaterial();
			}).AddTo(this);
		}
	}

	private async void SetSubmeshMaterial()
	{
		await UniTask.DelayFrame(1);
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
		if (componentsInChildren.Length == 1)
		{
			return;
		}
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].material.GetFloat("_Stencil") != (float)_stencil)
			{
				Material material = new Material(componentsInChildren[i].material);
				material.SetFloat("_StencilComp", 3f);
				material.SetFloat("_Stencil", _stencil);
				componentsInChildren[i].material = material;
				_matInstances.Add(material);
			}
		}
		_subMeshSubscribe.Dispose();
	}

	private void OnDestroy()
	{
		foreach (Material matInstance in _matInstances)
		{
			UnityEngine.Object.Destroy(matInstance);
		}
	}
}
