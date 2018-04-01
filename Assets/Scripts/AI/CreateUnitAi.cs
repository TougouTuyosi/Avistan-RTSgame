using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnitAi : AiBehaviour{

    private AiSupport support;

    public override void Excute(){
        //Debug.Log("生产士兵");
        var Castles = support.MyCastles;
        var index = Random.Range(0, Castles.Count);
        var Castle = Castles[index];
        Castle.GetComponent<CreateUnitAction>().CreateUnit(CreatWho());
    }

    public bool CastleIsNull(){
        var Castles = support.MyCastles;
        foreach (var C in Castles){
            if (C.GetComponent<CreateUnitAction>().NowCreateUnit.Count == 0)
                return true;
        }
        return false;
    }

    public override float GetWeight(){
        if (support == null)
            support = AiSupport.GetSupport(gameObject);
        if (!CastleIsNull())
            return 0;
        if (CreatWho() == 1 || CreatWho() == 2)
            if (GetComponent<AiSupport>().Player.Credits < 300)
                return 0;
        if (CreatWho() == 0 && GetComponent<AiSupport>().Player.Credits < 200)
            return 0;
        return 2;
    }

    public bool NeetPriest(){
        var Pfs = support.MyFreePriests;
        var Pws = support.MyWorkPriests;
        foreach (var p in Manager.Current.Players){
            if(p.Name == GetComponent<AiController>().PlayerName){
                if((Pfs.Count + Pws.Count) * 5 < p.ActiveUnits.Count){
                    foreach (var u in p.ActiveUnits){
                        if (u.GetComponent<UnitInfo>().CurrentHitPoints < u.GetComponent<UnitInfo>().MaxHitPoints)
                            return true;
                    }
                }
            }
        }
        return false;
    }

    public int CreatWho(){
        var Kfs = support.MyFreeKnights;
        var Kws = support.MyWorkKnights;

        var Mfs = support.MyFreeMagicians;
        var Mws = support.MyWorkMagicians;

        if (Kfs.Count + Kws.Count < 2)
            return 0;
        if (NeetPriest())
            return 2;
        if ((Kfs.Count + Kws.Count) * 2 < Mfs.Count + Mws.Count)
            return 0;
        return 1;
    }
}
