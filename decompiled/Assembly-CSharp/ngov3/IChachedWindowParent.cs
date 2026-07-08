namespace ngov3;

public interface IChachedWindowParent
{
	ChachedWindowType ChachedWindowType { get; }

	ChachedWindowObject Pop();
}
