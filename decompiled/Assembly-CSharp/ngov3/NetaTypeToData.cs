using System;

namespace ngov3;

[Serializable]
public class NetaTypeToData
{
	public string NetaGenreJP;

	public string NetaNameJP;

	public CmdType netaGenre;

	public TenCommentType netaName;

	public ActionType getJouken = ActionType.None;
}
