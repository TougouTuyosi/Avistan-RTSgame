using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCash : MonoBehaviour {
    public Text CashText;
	// Update is called once per frame
	void Update () {
		CashText.text = "" + (int)Player.Default.Credits;
        if (Player.Default.Credits < 0)
            Player.Default.Credits = 0;
    }
}
