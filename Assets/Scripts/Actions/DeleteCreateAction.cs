using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeleteCreateAction : ActionBehavior {


	public void DeleteCreate(int i){
		GetComponent<Player> ().Info.Credits += GetComponent<CreateUnitAction> ().NowCreateUnit [i].GetComponent<UnitInfo> ().Cash;
		GetComponent<CreateUnitAction> ().NowCreateUnit.Remove(GetComponent<CreateUnitAction> ().NowCreateUnit[i]);
		if(i == 0)
			GetComponent<CreateUnitAction> ().CreateSchedule = 0;
	}
	public override Action GetClickAction(int i){
		return delegate () {
			DeleteCreate(i);
		};
	}
	void Update () {
		if (GetComponent<CreateUnitAction> ().NowCreateUnit.Count == 0)
			return;
		for (int i = 0; i < GetComponent<CreateUnitAction> ().NowCreateUnit.Count; i++) {
			ButtonPic [i] = GetComponent<CreateUnitAction> ().NowCreateUnit [i].GetComponent<UnitInfo> ().Unitimage;
		}
	}
}
