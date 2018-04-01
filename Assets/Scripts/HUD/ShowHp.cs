using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHp : Interaction{
    public Canvas Ui;
    public Slider hp;

    public override void Deselect(){
        Ui.gameObject.SetActive(false);
    }

    public override void Select(){
        Ui.gameObject.SetActive(true);
    }

    // Use this for initialization
    void Start () {
        hp.maxValue = GetComponent<UnitInfo>().MaxHitPoints;
        hp.value = GetComponent<UnitInfo>().CurrentHitPoints;
        Ui.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Ui.transform.rotation = Camera.main.transform.rotation;
        hp.value = GetComponent<UnitInfo>().CurrentHitPoints;
        foreach (var r in GetComponentsInChildren<Renderer>()){
            if (!r.enabled)
                return;
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
            Ui.gameObject.SetActive(true);
        if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt))
            Ui.gameObject.SetActive(false);
    }
}
