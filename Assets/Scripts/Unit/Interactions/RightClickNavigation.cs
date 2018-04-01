using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RightClickNavigation : Interaction {

    public float RelaxDistance = 1;
    private NavMeshAgent agent;
    public Vector3 target = Vector3.zero;
    private bool selected = false;
    public bool isActive = false;
    public bool MustNavigation = false;
    public override void Deselect(){
        selected = false;
    }
    public override void Select(){
        selected = true;
    }
    public void SendToTarget(Vector3 pos){
        target = pos;
    }
    public void SendToTarget(){
        agent.SetDestination(target);
        agent.isStopped = false;
        isActive = true;
        MustNavigation = true;
    }
    void Start(){
        agent = GetComponent<NavMeshAgent>();
    }
    void Update(){
        if (transform.GetComponent<Player>().Info.IsAi)
            return;
        /*if(agent.isStopped)
            GetComponent<UnitInfo>().AnimationName = "walk";*/
        if (selected && Input.GetMouseButtonDown(1)){
            var tempTarget = Manager.Current.ScreenPointToMapPosition(Input.mousePosition);
            if (tempTarget.HasValue){
                target = tempTarget.Value;
                SendToTarget();
            }
            GetComponent<UnitInfo>().AnimationName = "run";
        }
        if (isActive && Vector3.Distance(target, transform.position) < RelaxDistance){
            agent.isStopped = true;
            isActive = false;
            MustNavigation = false;
            target = Vector3.zero;
            GetComponent<UnitInfo>().AnimationName = "walk";
        }
    }
}
