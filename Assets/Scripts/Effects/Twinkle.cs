using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Twinkle : MonoBehaviour {

    //public Image AnyKey;
    private Color color = new Color(255,255,255,0);
    private bool Add = true;
    public float TwinkleSpeed = 2.0f;

	// Use this for initialization
	void Start () {
        GetComponent<Image>().color = color;

    }
	
	// Update is called once per frame
	void Update () {
        if (Add)
            color.a += Time.deltaTime * TwinkleSpeed;
        else
            color.a -= Time.deltaTime * TwinkleSpeed;
        if (color.a >= 1)
            Add = false;
        if (color.a <= 0)
            Add = true;
            GetComponent<Image>().color = color;
	}
}
