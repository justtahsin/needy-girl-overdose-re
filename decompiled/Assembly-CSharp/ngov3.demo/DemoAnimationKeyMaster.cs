using System.Linq;
using UnityEngine;

namespace ngov3.demo;

public class DemoAnimationKeyMaster : MonoBehaviour
{
	[SerializeField]
	private Transform categoryParent;

	[SerializeField]
	private Transform animationKeyParent;

	[SerializeField]
	private AnimationCategoryVODataStore animationCategoryVODataStore;

	[SerializeField]
	private AnimationKeyVODataStore animationKeyVODataStore;

	[SerializeField]
	private DemoCategoryItem demoCategoryItemPrefab;

	[SerializeField]
	private DemoAnimationKeyItem demoAnimationKeyItemPrefab;

	private void Start()
	{
		foreach (AnimationCategoryVO item in animationCategoryVODataStore.Items)
		{
			PrefabFolder.InstantiateTo<DemoCategoryItem>(demoCategoryItemPrefab, categoryParent).Initialize(item, delegate(AnimationCategoryVO vo)
			{
				foreach (AnimationKeyVO item2 in animationKeyVODataStore.Items.Where((AnimationKeyVO akv) => akv.AnimationCategory == vo.AnimationCategory))
				{
					PrefabFolder.InstantiateTo<DemoAnimationKeyItem>(demoAnimationKeyItemPrefab, animationKeyParent).Initialize(item2);
				}
			});
		}
	}
}
