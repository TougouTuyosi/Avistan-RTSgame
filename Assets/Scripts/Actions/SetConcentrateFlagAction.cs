using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetConcentrateFlagAction : ActionBehavior{

    private Vector3 Flagposition;
    private bool IsAction = false;


    public override Action GetClickAction(int i){
        return delegate () {
            SetConcentrate();
        };
    }

    public void SetConcentrate(){
        Flagposition = GetComponent<SetConcentrateFlag>().ConcentrateFlag.transform.position;
        IsAction = true;
    }
    // Update is called once per frame
    void Update () {
        MouseManager.Current.IsAction = IsAction;
        if (!IsAction)
            return;
        if (Input.GetMouseButtonDown(1)|| Input.GetKeyDown(KeyCode.Escape)) {
            GetComponent<SetConcentrateFlag>().ConcentrateFlag.transform.position = Flagposition;
            IsAction = false;
            return;
        }
        if (Input.GetMouseButtonDown(0)){
            IsAction = false;
            return;
        }
        var tempTarget = Manager.Current.ScreenPointToMapPosition(Input.mousePosition);
        if (tempTarget.HasValue == false)
            return;
        GetComponent<SetConcentrateFlag>().ConcentrateFlag.transform.position = tempTarget.Value;
    }
}
