using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
    public static MouseManager Current;
    public bool IsAction = false;
    public MouseManager(){
        Current = this;
    }
    public List<Interactive> Selections = new List<Interactive>();
    // Update is called once per frame
    void Update () {
        if (!Input.GetMouseButtonDown(0))
            return;
        var es = UnityEngine.EventSystems.EventSystem.current;
        if (es != null && es.IsPointerOverGameObject()) //&& es.IsPointerOverGameObject()
            return;
        if (Selections.Count > 0 && !IsAction){
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift)){
                foreach (var sel in Selections){
                    if (sel != null)
                        sel.Deselect();
                }
                Selections.Clear();
            }
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit))
            return;
        var interact = hit.transform.GetComponent<Interactive>();
        if (interact == null)
            return;
        foreach (var r in hit.transform.GetComponentsInChildren<Renderer>()){
            if (!r.enabled)
                return;
        }
        Selections.Add(interact);
        interact.Select();
    }
}
