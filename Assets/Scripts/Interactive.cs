using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour {
    public bool Swap = false;
    private bool _Selected = false;
    public bool Selecter{
        get{
            return _Selected;
        }
    }
    public void Select(){
        _Selected = true;
        foreach (var selection in GetComponents<Interaction>()){
            selection.Select();
        }
    }
    public void Deselect(){
        _Selected = false;
        foreach (var selection in GetComponents<Interaction>()){
            selection.Deselect();
        }
    }
    void Update(){
        if (Swap){
            Swap = false;
            if (_Selected)
                Deselect();
            else
                Select();
        }
    }
}
