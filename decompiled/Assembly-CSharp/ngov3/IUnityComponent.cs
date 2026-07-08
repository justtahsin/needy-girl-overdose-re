using UnityEngine;

namespace ngov3;

public interface IUnityComponent
{
	GameObject UnityGameObject { get; }

	Transform GameObjectTransform { get; }
}
