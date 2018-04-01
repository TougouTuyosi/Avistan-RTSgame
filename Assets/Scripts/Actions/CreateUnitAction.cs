using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CreateUnitAction : ActionBehavior{
	public List<GameObject> Unit = new List<GameObject>();
	public List<GameObject> NowCreateUnit = new List<GameObject>();
	public float CreateSchedule = 0;
	private Action[] create;
    public GameObject ConcentrateFlag;

    public void CreateUnit(int i){
        if (GetComponent<Player> ().Info.Credits < Unit[i].GetComponent<UnitInfo>().Cash) {
			return;
		}
		GetComponent<Player>().Info.Credits -= Unit[i].GetComponent<UnitInfo>().Cash;
		NowCreateUnit.Add(Unit[i]);
	}
	public override Action GetClickAction(int i){
			return delegate () {
				CreateUnit (i);
			};
	}
    void Gototarget(GameObject go){
        go.GetComponent<RightClickNavigation>().target = ConcentrateFlag.gameObject.transform.position;
        go.GetComponent<NavMeshAgent>().SetDestination(ConcentrateFlag.gameObject.transform.position);
        go.GetComponent<NavMeshAgent>().isStopped = false;
        go.GetComponent<RightClickNavigation>().isActive = true;
        go.GetComponent<UnitInfo>().AnimationName = "run";
    }
	void Update () {
		if (NowCreateUnit.Count == 0)
			return;
		CreateSchedule += Time.deltaTime * 10;
		if (CreateSchedule >= 100) {
			var go = Instantiate(NowCreateUnit[0], transform.position, transform.rotation);
			var player = go.AddComponent<Player>();
			player.Info = GetComponent<Player>().Info;
			Gototarget(go);
			CreateSchedule = 0;
			NowCreateUnit.Remove (NowCreateUnit [0]);
			return;
		}
    }
}
