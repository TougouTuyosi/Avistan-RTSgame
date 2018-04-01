using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTeam : MonoBehaviour {


    //public PlayerTeam team;
    void Start(){
    }
    void Update () {
        if (MouseManager.Current.Selections.Count == 0)
            return;
        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
            return;
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            //Debug.Log("a");
            setT(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            setT(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            setT(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)){
            setT(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)){
            setT(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)){
            setT(5);
        }
    }

    public void setT(int i){
        foreach(var P in Manager.Current.Players){
            if (P.IsAi)
                continue;
            P.PlayerTeams[i].Unit.Clear();
            foreach (var u in MouseManager.Current.Selections)
            {
               P.PlayerTeams[i].Unit.Add(u);
            }
        }
    }
}
