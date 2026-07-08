using System.Collections.Generic;
using System.Linq;
using System.Text;
using Qitz.DataUtil;
using UnityEngine;

namespace ngov3;

public class AnimationCategoryVODataStore : BaseDataStore<AnimationCategoryVO>
{
	[SerializeField]
	private TextAsset animationCategoryEnum;

	[ContextMenu("サーバーかcsvからデータを読み込む")]
	protected override void LoadDataFromServer()
	{
		List<AnimationCategoryVO> source = new List<AnimationCategoryVO>(base.Items);
		base.LoadDataFromServer();
		foreach (AnimationCategoryVO item in base.Items)
		{
			AnimationCategoryVO animationCategoryVO = source.FirstOrDefault((AnimationCategoryVO i) => i.Id == item.Id);
			if (animationCategoryVO != null)
			{
				item.SetSprite(animationCategoryVO.IconSprite);
			}
			item.UpdateAnimationCategoryFromKeyString();
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("public enum AnimationCategoryEnum");
		stringBuilder.AppendLine("{");
		foreach (AnimationCategoryVO item2 in base.Items)
		{
			if (!string.IsNullOrEmpty(item2.Id))
			{
				stringBuilder.AppendLine("    " + item2.Id + ",");
			}
		}
		stringBuilder.AppendLine("}");
	}
}
