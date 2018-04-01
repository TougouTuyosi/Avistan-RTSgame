using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTeam : MonoBehaviour {

    public new GameObject camera;
    void Update () {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            return;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            getT(0, 0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            getT(0, 1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            getT(0, 2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            getT(0, 3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            getT(0, 4);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            getT(0, 5);
        if (Input.GetKeyDown(KeyCode.F2)){
            foreach (var sel in MouseManager.Current.Selections){
                if (sel != null)
                    sel.Deselect();
                MouseManager.Current.Selections.Clear();
            }
            foreach (var u in Manager.Current.Players[0].ActiveUnits){
                if (u.GetComponent<UnitInfo>().IsBuilding)
                    continue;
                MouseManager.Current.Selections.Add(u.GetComponent<Interactive>());
                u.GetComponent<Interactive>().Select();
            }
        }
    }

    public void getT(int p, int i){
        if (Manager.Current.Players[p].PlayerTeams[i].Unit.Count == 0)
            return;
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            return;
            if (Iamyou(MouseManager.Current.Selections,Manager.Current.Players[p].PlayerTeams[i].Unit)){
            var index = Random.Range(0, MouseManager.Current.Selections.Count);
            var u = MouseManager.Current.Selections[index];
            var V3 = new Vector3(u.gameObject.transform.position.x, camera.transform.position.y , u.gameObject.transform.position.z - 30 * Mathf.Tan((float)0.5774));
            camera.transform.position = V3;
            return;
        }
        for(int I = 0; I < MouseManager.Current.Selections.Count; I++){
            if (MouseManager.Current.Selections[I] != null)
                MouseManager.Current.Selections[I].Deselect();
            MouseManager.Current.Selections.Clear();
        }
        foreach (var u in Manager.Current.Players[p].PlayerTeams[i].Unit){
            MouseManager.Current.Selections.Add(u);
            u.Select();
        }
    }

    public bool Iamyou(List<Interactive> a, List<Interactive> b){
        if (a.Count != b.Count)
            return false;
        foreach(var c in a){
            if (!b.Contains(c))
                return false;
        }
        return true;
    }
}
