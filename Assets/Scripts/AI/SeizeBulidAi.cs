using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeizeBulidAi : AiBehaviour{

    private AiSupport support;
    private GameObject NeetSeize;

    private GameObject KnightToSeize;

    public override void Excute(){
        SeizeWho();
        if (KnightToSeize == null || NeetSeize == null)
            return;
        if(!support.MyWorkKnights.Contains(KnightToSeize))
            support.MyWorkKnights.Add(KnightToSeize);
        if (!support.SeizeBulids.Contains(KnightToSeize))
            support.SeizeBulids.Add(NeetSeize);
        if (KnightToSeize.GetComponent<RightClickNavigation>() == null)
            return;
        KnightToSeize.GetComponent<RightClickNavigation>().SendToTarget(NeetSeize.transform.position);
        KnightToSeize.GetComponent<RightClickNavigation>().SendToTarget();
        KnightToSeize.GetComponent<RightClickNavigation>().MustNavigation = false;
        NeetSeize.GetComponent<SeizeBuild>().SeizeUnit.Add(KnightToSeize);
    }

    public override float GetWeight(){
        if (support == null)
            support = AiSupport.GetSupport(gameObject);
        var Kfs = support.MyFreeKnights;
        if (Kfs.Count == 0)
            return 0;
        foreach (var p in Manager.Current.Players){
            if (p.Name != "Neutral")
                continue;
            if (p.ActiveUnits.Count == 0)
                return 0;
        }
        if (support.SeizeBulids.Count >= 2)
            return 0;
        return 1;
    }

    public void SeizeWho(){
        float MinDistance = 100000;
        var SeB = support.SeizeBulids;
        foreach (var k in support.MyFreeKnights){
            foreach(var p in Manager.Current.Players){
                if (p.Name != "Neutral")
                    continue;
                foreach(var b in p.ActiveUnits){
                    if (SeB.Contains(b))
                        continue;
                    if(Vector3.Distance(b.transform.position, k.transform.position) < MinDistance){
                        MinDistance = Vector3.Distance(b.transform.position, k.transform.position);
                        KnightToSeize = k;
                        NeetSeize = b;
                    }
                }
            }
        }
    }
}
