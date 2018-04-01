using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionRectManager : MonoBehaviour {
    public RectTransform SelectionRect;
    private bool MouseDown = false;
    Vector3 SelectionStartingPosition;
	
	void Update () {
        if (MouseManager.Current.IsAction)
            return;
        SelectionRect.gameObject.SetActive(MouseDown);
        if (Input.GetMouseButtonDown(0)){
            MouseDown = true;
            SelectionStartingPosition = Input.mousePosition;
            SelectionRect.position = SelectionStartingPosition;
        }
        if (MouseDown){
            Vector3 dist = Input.mousePosition - SelectionStartingPosition;
			SelectionRect.localScale = new Vector3(dist.x < 0 ? -1 : 1, dist.y < 0 ? -1 : 1, 1);
			SelectionRect.sizeDelta = new Vector2(Mathf.Abs(dist.x), Mathf.Abs(dist.y));
        }
        if (Input.GetMouseButtonUp(0)){
            MouseDown = false;
            Vector3 RectSize = Input.mousePosition - SelectionStartingPosition;
            Rect sssr = new Rect(SelectionStartingPosition.x, SelectionStartingPosition.y, RectSize.x, RectSize.y);
            if(MouseManager.Current.Selections.Count > 0){
                if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift)){
                    var es = UnityEngine.EventSystems.EventSystem.current;
                    if (es != null && es.IsPointerOverGameObject()) 
                        return;
                    foreach (var sel in MouseManager.Current.Selections){
                        if (sel != null)
                            sel.Deselect();
                    }
                    MouseManager.Current.Selections.Clear();
                }
            }
            foreach (var p in Manager.Current.Players){
                if (p.IsAi)
                    continue;
                foreach(var u in p.ActiveUnits){
                    if (u.GetComponent<UnitInfo>().IsBuilding)
                        continue;
                    Vector3 ScreenPoint = Camera.main.WorldToScreenPoint(u.transform.position);
                    if (sssr.Contains(ScreenPoint, true)){
                        MouseManager.Current.Selections.Add(u.GetComponent<Interactive>());
                        u.GetComponent<Interactive>().Select();
                    }
                }
            }
        }

    }
}
