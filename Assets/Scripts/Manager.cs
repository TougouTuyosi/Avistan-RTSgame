using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public static Manager Current = null;
    public TerrainCollider MapCollider;
    public List<PlayerSetupDefinition> Players = new List<PlayerSetupDefinition>();
    public Manager(){
        Current = this;
    }
    public Vector3? ScreenPointToMapPosition(Vector2 point){
        var ray = Camera.main.ScreenPointToRay(point);
        RaycastHit hit;
        if (!MapCollider.Raycast(ray, out hit, Mathf.Infinity))
            return null;
        return hit.point;
    }
    void Start () {
        foreach (var p in Players){
            foreach (var u in p.StartingUnits){
                var go = Instantiate(u, p.Location.position, p.Location.rotation);
                var player = go.GetComponent<Player>();
                player.Info = p;
                if (!p.IsAi){
                    if (Player.Default == null)
                        Player.Default = p;
                }
            }
        }
    }
	void Update () {
	}
}