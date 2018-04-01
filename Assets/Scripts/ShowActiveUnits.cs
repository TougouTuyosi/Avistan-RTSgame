using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowActiveUnits : MonoBehaviour {
    public List<GameObject> PlayerActiveUnits;
    public List<GameObject> AiActiveUnits;
	public List<GameObject> NeutralUnits;
    // Update is called once per frame
    void Update () {
		foreach(var p in Manager.Current.Players){
			if (p.Name == "Neutral") {
				NeutralUnits = p.ActiveUnits;
				continue;
			}
            if (p.IsAi)
                AiActiveUnits = p.ActiveUnits;
            else
                PlayerActiveUnits = p.ActiveUnits;
        }
	}
}
