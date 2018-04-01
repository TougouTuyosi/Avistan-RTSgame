using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour {
    public abstract void Select();
    public abstract void Deselect();
}
