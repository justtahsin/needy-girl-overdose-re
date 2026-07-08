namespace ngov3;

public interface IStackable
{
	int OrderInLayer { get; }

	void SetOrderInLayer(int order);
}
