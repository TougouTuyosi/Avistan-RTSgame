using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : Interaction {
    public GameObject Displayitem;
    public override void Select(){
        Displayitem.SetActive(true);
    }
    public override void Deselect(){
        Displayitem.SetActive(false);
    }
    // Use this for initialization
    void Start(){
        Displayitem.SetActive(false);
    }
}
