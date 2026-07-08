using System.Collections.Generic;
using SFB;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace CSVUtil;

public class NGOMasterMerge : MonoBehaviour
{
	[SerializeField]
	private Button selectMergeTarget;

	[SerializeField]
	private Text selectMergeTargetPath;

	[SerializeField]
	private Button selectMergeSideToBe;

	[SerializeField]
	private Text selectMergeSideToBePath;

	[SerializeField]
	private Button mergeButton;

	[SerializeField]
	private InputField idCloumnName;

	[SerializeField]
	private GameObject errorDisplay;

	private void Start()
	{
		selectMergeTarget.onClick.AddListener(delegate
		{
			ExtensionFilter[] extensions = new ExtensionFilter[1]
			{
				new ExtensionFilter("対象CSVを選択", "csv")
			};
			string[] array = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, multiselect: true);
			selectMergeTargetPath.text = array[0];
		});
		selectMergeSideToBe.onClick.AddListener(delegate
		{
			ExtensionFilter[] extensions = new ExtensionFilter[1]
			{
				new ExtensionFilter("対象CSVを選択", "csv")
			};
			string[] array = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, multiselect: true);
			selectMergeSideToBePath.text = array[0];
		});
		mergeButton.onClick.AddListener(delegate
		{
			string outPutPath = StandaloneFileBrowser.SaveFilePanel("保存先を選択", "", "", "csv");
			NGOMasterMergUseCase nGOMasterMergUseCase = new NGOMasterMergUseCase();
			List<List<string>> list = nGOMasterMergUseCase.LoadCSV(selectMergeTargetPath.text);
			List<List<string>> list2 = nGOMasterMergUseCase.LoadCSV(selectMergeSideToBePath.text);
			List<string> list3 = list[0];
			List<string> list4 = list2[0];
			if (!list3.Contains(idCloumnName.text) || !list4.Contains(idCloumnName.text))
			{
				Debug.LogError("CSVのHeaderにIDのカラムが含まれていません！");
				errorDisplay.SetActive(value: true);
			}
			else
			{
				List<List<string>> alignCSVColumn = nGOMasterMergUseCase.GetAlignCSVColumn(list, list2);
				List<Dictionary<string, string>> valueMergedCSV = nGOMasterMergUseCase.GetValueMergedCSV(idCloumnName.text, list, alignCSVColumn);
				nGOMasterMergUseCase.ExportCSV(outPutPath, valueMergedCSV);
			}
		});
		(from _ in this.UpdateAsObservable()
			select selectMergeTargetPath.text != "" && selectMergeSideToBePath.text != "").Subscribe(delegate(bool selectedCSV)
		{
			mergeButton.interactable = selectedCSV;
		}).AddTo(base.gameObject);
	}
}
