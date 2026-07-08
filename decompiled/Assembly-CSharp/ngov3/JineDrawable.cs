namespace ngov3;

public struct JineDrawable(JineUserType jineUserType, string bodyJp, string bodyEn, string bodyCn, string bodyKo, string bodyTw, string bodyVn, string bodyFr, string bodyIt, string bodyGe, string bodySp, string bodyRu, string imageId, StampType stampType, bool isAmeHead = false, int day = 0, int kidokumillisecond = 1000)
{
	public JineUserType JineUserType = jineUserType;

	public string BodyJp = bodyJp;

	public string BodyEn = bodyEn;

	public string BodyCn = bodyCn;

	public string BodyKo = bodyKo;

	public string BodyTw = bodyTw;

	public string BodyVn = bodyVn;

	public string BodyFr = bodyFr;

	public string BodyIt = bodyIt;

	public string BodyGe = bodyGe;

	public string BodySp = bodySp;

	public string BodyRu = bodyRu;

	public string ImageId = imageId;

	public StampType StampType = stampType;

	public int Day = day;

	public int kidokumillisecond = kidokumillisecond;

	public bool isAmeHead = isAmeHead;
}
