using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeizeBuild : MonoBehaviour {
    public float Seizelevel = 0;
    public float SeizeCounter = 0;
    public float SeizeCounterAi = 0;
    public float SeizeDistance;
    public GameObject SeizelevelSlider;

    public List<GameObject> SeizeUnit = new List<GameObject>();

    float WhoSeize(float pcCounter,float aiCounter){
        float seizelevel = 0;
        if (pcCounter >= 1)
            seizelevel += 5;
        if (aiCounter >= 1)
            seizelevel -= 5;
        return seizelevel;
    }
    float WhoIsAi(bool IsAi){
        if (IsAi)
            return Time.deltaTime;
        else
            return 0;
    }

    void Update () {
        if (Seizelevel == 0)
            SeizelevelSlider.gameObject.SetActive(false);
        if(Seizelevel != 0){
            SeizelevelSlider.gameObject.SetActive(true);
            if (Seizelevel > 0)
                SeizelevelSlider.GetComponent<MeshRenderer>().material.color = Manager.Current.Players[0].AccentColor;
            else
                SeizelevelSlider.GetComponent<MeshRenderer>().material.color = Manager.Current.Players[1].AccentColor;
            SeizelevelSlider.gameObject.transform.localScale = new Vector3(Math.Abs(Seizelevel) / 50, 1.0f, 0.01f); 
        }
        foreach (var u in GetComponent<Player>().Info.ActiveUnits){
            if (Vector3.Distance(u.transform.position, transform.position) < SeizeDistance 
                && !u.GetComponent<UnitInfo>().IsBuilding)
                return;
        }
		foreach(var p in Manager.Current.Players){
            if (GetComponent<Player>().Info != p ){
                foreach (var u in p.ActiveUnits){
                    if(!u.GetComponent<UnitInfo>().CanOccupy)
                        continue;
                    if (Vector3.Distance(u.transform.position, transform.position) < SeizeDistance){
                        SeizeCounter += WhoIsAi(!p.IsAi);
                        SeizeCounterAi += WhoIsAi(p.IsAi);
                        Seizelevel += WhoSeize(SeizeCounter, SeizeCounterAi);
                        if (SeizeCounter >= 1)
                            SeizeCounter = 0;
                        if (SeizeCounterAi >= 1)
                            SeizeCounterAi = 0;
                        if (Seizelevel == 100 || Seizelevel == -100){
                            GetComponent<Player>().Info.ActiveUnits.Remove(gameObject);
                            GetComponent<Player>().Info = p;
                            p.ActiveUnits.Add(gameObject);
                            Seizelevel = 0;
                            if (!GetComponent<Player>().Info.IsAi)
                                AudioManager.Current.SetSE(0);
							if (GetComponent<UnitInfo> ().UnitName == "兵营") {
								GetComponent<CreateUnitAction> ().NowCreateUnit.Clear ();
								GetComponent<CreateUnitAction> ().CreateSchedule = 0;
							}
                            return;
                        }
                    }
                }
            }
        }
    }
}
