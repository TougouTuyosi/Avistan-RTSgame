using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButton : Interaction{
    public Canvas Ui;

    public override void Deselect(){
        Ui.gameObject.SetActive(false);
    }

    public override void Select(){
        if (GetComponent<Player>().Info.IsAi)
            return;
        Ui.gameObject.SetActive(true);
    }

    // Use this for initialization
    void Start () {
        Ui.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
    }
}
