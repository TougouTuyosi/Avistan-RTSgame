using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkColor : MonoBehaviour {
    public MeshRenderer[] Renderers;
    void Update(){
        var color = GetComponent<Player>().Info.AccentColor;
        foreach (var r in Renderers){
            r.material.color = color;
        }
    }
}
