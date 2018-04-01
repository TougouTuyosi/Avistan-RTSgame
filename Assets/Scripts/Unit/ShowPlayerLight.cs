using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayerLight : MonoBehaviour {
    public Light L;
    // Use this for initialization
    void Start () {
        L.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Player>().Info.Name == "Player 1")
            L.gameObject.SetActive(true);
    }
}
