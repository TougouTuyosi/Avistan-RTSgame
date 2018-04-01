using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadOnNoHitPoint : MonoBehaviour {
    private float DeadCounter;
    void Update () {
        if (GetComponent<UnitInfo>().CurrentHitPoints <= 0){
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject.GetComponent<AutoAttackAi>());
            Destroy(gameObject.GetComponent<RightClickAttack>());
            Destroy(gameObject.GetComponent<RightClickNavigation>());
            GetComponent<UnitInfo>().AnimationName = "die";
            DeadCounter += Time.deltaTime;
            if(DeadCounter >= 2.0f)
                Destroy(gameObject);
        }
    }
}
