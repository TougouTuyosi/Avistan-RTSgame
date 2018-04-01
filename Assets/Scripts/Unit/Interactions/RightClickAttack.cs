using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RightClickAttack : Interaction{
    private bool selected = false;
    private PlayerSetupDefinition player;
    public UnitInfo target;
    private PlayerSetupDefinition Noplayer;
    private UnitInfo unitinfo;
    private bool DistanceCanAttack = false;
    public bool NeedNavMeshAgent = false;
    private NavMeshAgent agent;
    private float attackCounter;

    public GameObject Fire,Cure;

    public override void Deselect(){
        selected = false;
    }
    public override void Select(){
        selected = true;
    }
    public void Attack(){
        double dmg = (1 + 0.01 * player.Atklevel) * unitinfo.Damage * (1 - 0.01 * (Noplayer.Deflevel + target.defense));
        if (GetComponent<UnitInfo>().UnitName == "法师"){
            var go = Instantiate(Fire, transform.position, transform.rotation);
            go.GetComponent<FlyFire>().AddTarget(target,(int)dmg);
            return;
        }
        if (unitinfo.IsDoctor){
            var go = Instantiate(Cure, target.transform.position + new Vector3(0,3,0), transform.rotation);
            dmg *= -1;
        }
        target.CurrentHitPoints -= (int)dmg;
        if (AudioManager.Current.BGM.clip != AudioManager.Current.bgm[3])
            AudioManager.Current.SetBGM(3);
        if(!unitinfo.IsDoctor)
            AudioManager.Current.SetSE(3);
    }
    void Start(){
        player = GetComponent<Player>().Info;
        unitinfo = GetComponent<UnitInfo>();
        agent = GetComponent<NavMeshAgent>();
    }


    void Update () {
        if (selected && Input.GetMouseButtonDown(1)){
            DistanceCanAttack = false;
            NeedNavMeshAgent = false;
            target = null;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit))
                return;
            var interact = hit.transform.GetComponent<UnitInfo>();
            if (interact == null)
                return;
            if (interact.IsBuilding)
                return;
            Noplayer = hit.transform.GetComponent<Player>().Info;
            target = interact;
			GetComponent<RightClickNavigation> ().MustNavigation = false;
            if (hit.transform.GetComponent<Player>().Info.Name != player.Name && unitinfo.IsDoctor)
                return;
            if (hit.transform.GetComponent<Player>().Info.Name == player.Name && !unitinfo.IsDoctor)
                return;
            if (Vector3.Distance(target.transform.position, transform.position) >= unitinfo.AttackDistance){
                NeedNavMeshAgent = true;
                return;
            }
            DistanceCanAttack = true;
            return;
        }
        if (NeedNavMeshAgent){
            if(target == null){
                NeedNavMeshAgent = false;
                return;
            }
            DistanceCanAttack = false;
            if (Vector3.Distance(target.transform.position, transform.position) < unitinfo.AttackDistance){
                DistanceCanAttack = true;
                NeedNavMeshAgent = false;
                return;
            }
            agent.SetDestination(target.transform.position);
            agent.isStopped = false;
            GetComponent<UnitInfo>().AnimationName = "run";
            return;
        }
        if (DistanceCanAttack){
            GetComponent<UnitInfo>().AnimationName = "walk";
            NeedNavMeshAgent = false;
            if (target == null){
                DistanceCanAttack = false;
                return;
            }
            agent.isStopped = true;
            if (target.GetComponent<UnitInfo>().CurrentHitPoints <= 0){
                DistanceCanAttack = false;
                target = null;
                return;
            }
            if (Vector3.Distance(target.transform.position, transform.position) >= unitinfo.AttackDistance){
                NeedNavMeshAgent = true;
                return;
            }
            if (unitinfo.IsDoctor && target.CurrentHitPoints == target.MaxHitPoints){
                target = null;
                return;
            }
            transform.LookAt(target.gameObject.transform);
            Noplayer = target.transform.GetComponent<Player>().Info;
            attackCounter += Time.deltaTime;
            GetComponent<UnitInfo>().AnimationName = "attack";
            if (attackCounter >= GetComponent<UnitInfo>().AttackWait){
                Attack();
                attackCounter = 0;
                return;
            }
            return;
        }
    }
}
