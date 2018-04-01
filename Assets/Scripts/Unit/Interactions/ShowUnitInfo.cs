using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnitInfo : Interaction {

	private bool show = false;

	public override void Deselect(){
		InfoManager.Current.ClearInfo ();
		show = false;
	}

	public override void Select(){
		InfoManager.Current.ShowInfo ();
		show = true;
	}

	// Update is called once per frame
	void Update () {
		if (!show)
			return;
		
		InfoManager.Current.SetUnitNameAndHp (
			GetComponent<UnitInfo> ().UnitName,
			GetComponent<UnitInfo> ().CurrentHitPoints + "/" + GetComponent<UnitInfo> ().MaxHitPoints);
		InfoManager.Current.SetHp (
			GetComponent<UnitInfo> ().CurrentHitPoints,
			GetComponent<UnitInfo> ().MaxHitPoints);
	}
}
