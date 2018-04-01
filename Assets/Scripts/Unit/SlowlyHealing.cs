using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyHealing : MonoBehaviour {
    // Update is called once per frame
    private float cheaktime;
	void Update () {
        if (GetComponent<UnitInfo>().CurrentHitPoints <= 0)
            return;
        if (GetComponent<UnitInfo>().CurrentHitPoints < GetComponent<UnitInfo>().MaxHitPoints){
            cheaktime += Time.deltaTime;
            if(cheaktime >= 1){
                GetComponent<UnitInfo>().CurrentHitPoints++;
                cheaktime = 0;
            }
        }
        else
            GetComponent<UnitInfo>().CurrentHitPoints = GetComponent<UnitInfo>().MaxHitPoints;
    }
}
