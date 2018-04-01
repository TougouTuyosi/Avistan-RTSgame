using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWorkAi : AiBehaviour{
    public override void Excute(){
        return;
    }

    public override float GetWeight(){
        return 0;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
