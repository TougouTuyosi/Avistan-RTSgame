using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAi : AiBehaviour{

    private AiSupport support;
    private GameObject targer;

    public override void Excute(){
        SeizeWho(HaveBulid());
        foreach (var k in support.MyFreeKnights){
            if (k.GetComponent<RightClickNavigation>() == null)
                continue;
            k.GetComponent<RightClickNavigation>().SendToTarget(targer.transform.position);
            k.GetComponent<RightClickNavigation>().SendToTarget();
            k.GetComponent<RightClickNavigation>().MustNavigation = false;
        }
        foreach (var m in support.MyFreeKnights){
            if (m.GetComponent<RightClickNavigation>() == null)
                continue;
            m.GetComponent<RightClickNavigation>().SendToTarget(targer.transform.position);
            m.GetComponent<RightClickNavigation>().SendToTarget();
            m.GetComponent<RightClickNavigation>().MustNavigation = false;
        }
    }

    public override float GetWeight(){
        if (support == null)
            support = AiSupport.GetSupport(gameObject);
        var Mfs = support.MyFreeMagicians;
        var Kfs = support.MyFreeKnights;
        if (Mfs.Count < 4 || Kfs.Count < 2)
            return 0;
        if (TimePassed < 180)
            return 0;
        return 1;
    }

    public void SeizeWho(bool HB){
        if (HB){
            float MinDistance = 100000;
            var SeB = support.SeizeBulids;
            foreach (var B in support.MyCastles){
                foreach (var p in Manager.Current.Players){
                    if (p.IsAi)
                        continue;
                    foreach (var b in p.ActiveUnits){
                        if (SeB.Contains(b))
                            continue;
                        if (!b.GetComponent<UnitInfo>().IsBuilding)
                            continue;
                        if (Vector3.Distance(b.transform.position, B.transform.position) < MinDistance){
                            MinDistance = Vector3.Distance(b.transform.position, B.transform.position);
                            targer = b;
                        }
                    }
                }
            }
        }
        else{
            var index = Random.Range(0, Manager.Current.Players[0].ActiveUnits.Count);
            targer = Manager.Current.Players[0].ActiveUnits[index];
        }
    }

    public bool HaveBulid(){
        foreach(var u in Manager.Current.Players[0].ActiveUnits){
            if (u.GetComponent<UnitInfo>().IsBuilding)
                return true;
        }
        return false;
    }
}
