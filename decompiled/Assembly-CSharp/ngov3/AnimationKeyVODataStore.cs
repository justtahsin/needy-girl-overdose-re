using Qitz.DataUtil;
using UnityEngine;

namespace ngov3;

[CreateAssetMenu]
public class AnimationKeyVODataStore : BaseDataStore<AnimationKeyVO>
{
	[ContextMenu("サーバーかcsvからデータを読み込む")]
	protected override void LoadDataFromServer()
	{
		base.LoadDataFromServer();
		foreach (AnimationKeyVO item in base.Items)
		{
			item.UpdateAnimationCategoryFromKeyString();
		}
	}
}
