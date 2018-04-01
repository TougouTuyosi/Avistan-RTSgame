using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureDown : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(0, Time.deltaTime, 0);
        if(transform.position.y <= 0){
            Destroy(gameObject);
        }
    }
}
