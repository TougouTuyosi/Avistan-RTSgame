using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetConcentrateFlag : Interaction{
    public GameObject ConcentrateFlag;
    private bool IsSelect = false;
    void Start(){
    }
    void Update () {
        if (!IsSelect)
            return;
        if (MouseManager.Current.IsAction)
            return;
        if (Input.GetKeyDown(KeyCode.F)){
            GetComponent<SetConcentrateFlagAction>().SetConcentrate();
            return;
        }
        if (Input.GetMouseButtonDown(1)){
            var tempTarget = Manager.Current.ScreenPointToMapPosition(Input.mousePosition);
            if (tempTarget.HasValue){
                ConcentrateFlag.gameObject.transform.position = tempTarget.Value;
            }
        }
    }
    public override void Select(){
        IsSelect = true;
        if (GetComponent<Player>().Info.IsAi)
            return;
        ConcentrateFlag.gameObject.SetActive(true);
        var ab = GetComponent<SetConcentrateFlagAction>();
        ActionManager.Current.AddButton(ab.ButtonPic[0], ab.GetClickAction(0),3);
    }

    public override void Deselect(){
        IsSelect = false;
        ConcentrateFlag.gameObject.SetActive(false);
    }
}
