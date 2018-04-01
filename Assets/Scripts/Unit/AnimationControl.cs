using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationControl : MonoBehaviour {
    private string LastAnimation = "walk";
    private float attackCounter;

    void Start(){
    }

    // Update is called once per frame
    void Update () {
        if (LastAnimation != GetComponent<UnitInfo>().AnimationName){
            GetComponent<Animation>().CrossFade(GetComponent<UnitInfo>().AnimationName);
            LastAnimation = GetComponent<UnitInfo>().AnimationName;
            return;
        }
        if(LastAnimation == "attack"){
            attackCounter += Time.deltaTime;
            if(attackCounter >= GetComponent<UnitInfo>().AttackWait){
                GetComponent<Animation>().CrossFade(GetComponent<UnitInfo>().AnimationName);
                attackCounter = 0;
                return;
            }
        }
        if (GetComponent<UnitInfo>().AnimationName == "run" && GetComponent<NavMeshAgent>().isStopped)
            GetComponent<UnitInfo>().AnimationName = "walk";
        if(GetComponent<UnitInfo>().AnimationName == "attack" && GetComponent<RightClickAttack>().target == null)
            GetComponent<UnitInfo>().AnimationName = "walk";
    }
}
