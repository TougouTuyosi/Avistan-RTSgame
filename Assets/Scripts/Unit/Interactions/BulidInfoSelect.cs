using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulidInfoSelect : Interaction {

	private bool show = false;

	public override void Deselect(){
		ActionManager.Current.ClearDeleteCreateButtons ();
		InfoManager.Current.BulidInfo.gameObject.SetActive (false);
		show = false;
	}

	public override void Select(){
		ActionManager.Current.ClearDeleteCreateButtons ();
		if (GetComponent<Player> ().Info.IsAi)
			return;
		InfoManager.Current.BulidInfo.gameObject.SetActive (true);
		var dc = GetComponent<DeleteCreateAction> ();
		var ab = GetComponent<CreateUnitAction> ();
		for (int i = 0; i < ab.NowCreateUnit.Count; i++) {
			ActionManager.Current.AddDeleteCreateButton(dc.ButtonPic[i], dc.GetClickAction(i),i);
		}
		show = true;
	}

	void Update(){
		if (!show)
			return;
		ActionManager.Current.ClearDeleteCreateButtons ();
		if (GetComponent<Player> ().Info.IsAi)
			return;
		var dc = GetComponent<DeleteCreateAction> ();
		var ab = GetComponent<CreateUnitAction> ();
		for (int i = 0; i < ab.NowCreateUnit.Count; i++) {
			ActionManager.Current.AddDeleteCreateButton(dc.ButtonPic[i], dc.GetClickAction(i),i);
		}
		InfoManager.Current.SetCreateSchedule (GetComponent<CreateUnitAction> ().CreateSchedule);
		if (ab.NowCreateUnit.Count == 0)
			InfoManager.Current.SetCreateName ("");
		else
			InfoManager.Current.SetCreateName ("正在训练：" + GetComponent<CreateUnitAction> ().NowCreateUnit[0].GetComponent<UnitInfo> ().UnitName);
	}
}
