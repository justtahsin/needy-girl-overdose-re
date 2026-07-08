using System;
using System.Collections.Generic;
using SFB;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Events;
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		((UnityEvent)selectMergeTarget.onClick).AddListener((UnityAction)delegate
		{
			ExtensionFilter[] extensions = new ExtensionFilter[1]
			{
				new ExtensionFilter("対象CSVを選択", "csv")
			};
			string[] array = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, multiselect: true);
			selectMergeTargetPath.text = array[0];
		});
		((UnityEvent)selectMergeSideToBe.onClick).AddListener((UnityAction)delegate
		{
			ExtensionFilter[] extensions = new ExtensionFilter[1]
			{
				new ExtensionFilter("対象CSVを選択", "csv")
			};
			string[] array = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, multiselect: true);
			selectMergeSideToBePath.text = array[0];
		});
		((UnityEvent)mergeButton.onClick).AddListener((UnityAction)delegate
		{
			string outPutPath = StandaloneFileBrowser.SaveFilePanel("保存先を選択", "", "", "csv");
			NGOMasterMergUseCase nGOMasterMergUseCase = new NGOMasterMergUseCase();
			List<List<string>> list = nGOMasterMergUseCase.LoadCSV(selectMergeTargetPath.text);
			List<List<string>> list2 = nGOMasterMergUseCase.LoadCSV(selectMergeSideToBePath.text);
			List<string> list3 = list[0];
			List<string> list4 = list2[0];
			if (!list3.Contains(idCloumnName.text) || !list4.Contains(idCloumnName.text))
			{
				Debug.LogError((object)"CSVのHeaderにIDのカラムが含まれていません！");
				errorDisplay.SetActive(true);
			}
			else
			{
				List<List<string>> alignCSVColumn = nGOMasterMergUseCase.GetAlignCSVColumn(list, list2);
				List<Dictionary<string, string>> valueMergedCSV = nGOMasterMergUseCase.GetValueMergedCSV(idCloumnName.text, list, alignCSVColumn);
				nGOMasterMergUseCase.ExportCSV(outPutPath, valueMergedCSV);
			}
		});
		DisposableExtensions.AddTo<IDisposable>(ObservableExtensions.Subscribe<bool>(Observable.Select<Unit, bool>(ObservableTriggerExtensions.UpdateAsObservable((Component)(object)this), (Func<Unit, bool>)((Unit _) => selectMergeTargetPath.text != "" && selectMergeSideToBePath.text != "")), (Action<bool>)delegate(bool selectedCSV)
		{
			((Selectable)mergeButton).interactable = selectedCSV;
		}), ((Component)this).gameObject);
	}
}
