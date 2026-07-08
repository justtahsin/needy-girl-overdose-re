using UnityEngine;

namespace ngov3;

[RequireComponent(typeof(Button2D))]
[RequireComponent(typeof(DraggableObject))]
public class WindowCover2D : MonoBehaviour
{
	[SerializeField]
	private Button2D button2D;

	[SerializeField]
	private DraggableObject draggableObject;

	public Button2D Button2D => button2D;

	public DraggableObject DraggableHandle => draggableObject;

	private void Awake()
	{
	}
}
