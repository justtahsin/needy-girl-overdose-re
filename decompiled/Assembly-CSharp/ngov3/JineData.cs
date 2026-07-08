using System;
using NGO;

namespace ngov3;

[Serializable]
public class JineData
{
	public JineUserType user;

	public JineType id;

	public ResponseType responseType;

	public StampType stampType;

	public int day;

	public string freeMessage;

	public JineData()
	{
		user = JineUserType.ame;
		id = JineType.LineWeekDay015;
		responseType = ResponseType.IdMessage;
		stampType = StampType.None;
		freeMessage = string.Empty;
		day = 0;
	}

	public JineData(string message)
	{
		user = JineUserType.ame;
		id = JineType.None;
		responseType = ResponseType.Freeform;
		stampType = StampType.None;
		freeMessage = message;
		day = 0;
	}

	public JineData(JineType type, int day = 0)
	{
		user = JineUserType.ame;
		id = type;
		responseType = ResponseType.IdMessage;
		stampType = StampType.None;
		freeMessage = string.Empty;
		this.day = day;
	}

	public JineData(JineType type, JineUserType user, int day = 0)
	{
		this.user = user;
		id = type;
		responseType = ResponseType.IdMessage;
		stampType = StampType.None;
		freeMessage = string.Empty;
		this.day = day;
	}

	public JineData(JineUserType user, JineType id = JineType.None, ResponseType responseType = ResponseType.IdMessage, StampType stamp = StampType.None, string freeMessage = "", int day = 0)
	{
		this.user = user;
		this.responseType = responseType;
		stampType = stamp;
		this.id = id;
		this.freeMessage = freeMessage;
		this.day = day;
	}
}
