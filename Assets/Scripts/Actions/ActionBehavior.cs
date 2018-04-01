using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ActionBehavior : MonoBehaviour {
	public abstract Action GetClickAction(int i);
	public Sprite[] ButtonPic;
}
