using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFire : MonoBehaviour {

    private UnitInfo target;
    private int dmg;
    private float speed = 30.0f;

    public void AddTarget(UnitInfo u,int d){
        target = u;
        dmg = d;
        transform.LookAt(target.gameObject.transform);
    }

    void Start(){
    }
    // Update is called once per frame
    void Update () {
        transform.LookAt(target.gameObject.transform);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(Vector3.Distance(target.transform.position, transform.position) <= 1){
            target.CurrentHitPoints -= dmg;
            Destroy(gameObject);
        }
    }
}
