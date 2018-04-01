using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelect : Interaction {
    private bool IsSelect = false;
	public override void Deselect(){
        IsSelect = false;
        ActionManager.Current.ClearButtons();
	}
	public override void Select(){
        IsSelect = true;

        ActionManager.Current.ClearButtons();
		if (GetComponent<Player> ().Info.IsAi)
			return;
		var ab = GetComponent<CreateUnitAction>();
		for (int i = 0; i < ab.ButtonPic.Length; i++) {
			ActionManager.Current.AddButton(ab.ButtonPic[i], ab.GetClickAction(i),i);
		}
	}
    void Update(){
        if (!IsSelect)
            return;
        if (Input.GetKeyDown(KeyCode.Q))
            GetComponent<CreateUnitAction>().CreateUnit(0);
        if (Input.GetKeyDown(KeyCode.W))
            GetComponent<CreateUnitAction>().CreateUnit(1);
        if (Input.GetKeyDown(KeyCode.E))
            GetComponent<CreateUnitAction>().CreateUnit(2);
    }
}