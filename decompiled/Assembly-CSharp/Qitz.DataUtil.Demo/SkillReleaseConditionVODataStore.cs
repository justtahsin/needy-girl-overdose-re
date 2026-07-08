using UnityEngine;

namespace Qitz.DataUtil.Demo;

public class SkillReleaseConditionVODataStore : BaseDataStore<SkillReleaseConditionVO>
{
	[ContextMenu("サーバーからデータを読み込む")]
	protected override void LoadDataFromServer()
	{
		base.LoadDataFromServer();
	}
}
