using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttackAi : MonoBehaviour {

    public UnitInfo targer;
    public float See;
	// Update is called once per frame
	void Update () {
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.right,out hit, 10) && !GetComponent<Player>().Info.IsAi){
            targer = hit.transform.GetComponent<UnitInfo>();
        }*/
        if (GetComponent<RightClickAttack>().target != null)
            return;
		foreach(var p in Manager.Current.Players){
            if(p == GetComponent<Player>().Info && !GetComponent<UnitInfo>().IsDoctor)
                continue;
            if(p != GetComponent<Player>().Info && GetComponent<UnitInfo>().IsDoctor)
                continue;
            foreach (var u in p.ActiveUnits){
                if(GetComponent<UnitInfo>().IsDoctor 
                    && u.GetComponent<UnitInfo>().CurrentHitPoints == u.GetComponent<UnitInfo>().MaxHitPoints)
                    continue;
                if (!u.GetComponent<UnitInfo>().IsBuilding 
                    && Vector3.Distance(u.transform.position, transform.position) <= See
                    && !GetComponent<RightClickNavigation>().MustNavigation){
                    //&& GetComponent<UnitInfo>().AnimationName == "walk"
                    GetComponent<RightClickAttack>().target = u.GetComponent<UnitInfo>();
                    GetComponent<RightClickAttack>().NeedNavMeshAgent = true;
                    return;
                }
            }   
        }
    }
}
