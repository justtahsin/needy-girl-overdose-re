namespace ngov3;

public struct StatusDiff(StatusType type, int diff)
{
	public StatusType statusType = type;

	public int delta = diff;
}
