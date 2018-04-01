using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializationManager : MonoBehaviour {
	public List<GameObject> PlayerUnits;
	public List<GameObject> AIUnits;
	public List<GameObject> NeutralUnits;
    void Start () {
		foreach (var p in Manager.Current.Players) {
			if (p.Name == "Neutral") {
				foreach (var u in NeutralUnits) {
					u.GetComponent<Player> ().Info = p;
					p.ActiveUnits.Add (u);
				}
			}
		}
	}
}
