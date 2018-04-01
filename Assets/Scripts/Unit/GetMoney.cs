using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoney : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        if (GetComponent<Player>().Info.Name == "Neutral")
            return;
        GetComponent<Player>().Info.Credits += 4*Time.deltaTime;
    }
}
