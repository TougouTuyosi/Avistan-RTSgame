using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBlip : MonoBehaviour {
    private GameObject blip;
    public GameObject Blip{
        get{
            return blip;
        }
    }
    void Start(){
        blip = Instantiate(Map.Current.BlipPrefab);
        blip.transform.parent = Map.Current.transform;
        var color = GetComponent<Player>().Info.AccentColor;
        blip.GetComponent<Image>().color = color;
        if(GetComponent<UnitInfo>().IsBuilding)
            blip.transform.localScale = new Vector2(2.4f, 2.4f);
    }
    void Update(){
        var color = GetComponent<Player>().Info.AccentColor;
        blip.GetComponent<Image>().color = color;
        blip.transform.position = Map.Current.WorldPositionToMap(transform.position);
    }
    private void OnDestroy(){
        Destroy(blip);
    }
}
