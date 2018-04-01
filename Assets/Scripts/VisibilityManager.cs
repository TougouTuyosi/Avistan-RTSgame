using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour {
    public float TimeBetweenChecks = 1;
    public float VisibleRange = 100;
    private float waited = 2500;
    public List<GameObject> nBlips;
    // Update is called once per frame
    void Update(){
        waited += Time.deltaTime;
        if (waited <= TimeBetweenChecks)
            return;
        waited = 0;
        List<MapBlip> pBlips = new List<MapBlip>();
        List<MapBlip> oBlips = new List<MapBlip>();
        foreach(var u in nBlips){
            var blip = u.GetComponent<MapBlip>();
            if (u.GetComponent<Player>().Info == Player.Default)
                pBlips.Add(blip);
            else
                oBlips.Add(blip);
        }
        foreach (var p in Manager.Current.Players){
            foreach (var u in p.ActiveUnits){
                var blip = u.GetComponent<MapBlip>();
                if (p == Player.Default)
                    pBlips.Add(blip);
                else
                    oBlips.Add(blip);
            }
        }

        foreach (var o in oBlips){
            bool active = false;
            foreach (var p in pBlips){
                var distance = Vector3.Distance(o.transform.position, p.transform.position);
                if (distance <= VisibleRange){
                    active = true;
                    break;
                }
            }
            o.Blip.SetActive(active);
            foreach (var r in o.GetComponentsInChildren<Renderer>()){
                r.enabled = active;
            }
        }
    }
}
