using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Map : MonoBehaviour {
    //public RectTransform ViewPort;
    public Transform Corner1, Corner2;
    public GameObject BlipPrefab;
    public static Map Current;
    private Vector2 terrainSize;
    private RectTransform mapRect;
    public new GameObject camera;

    public Map() {
        Current = this;
    }

    private bool IsMap(float x,float y){
        if (x < 175 * ((float)Screen.width / 1024) && x > 10 * ((float)Screen.width / 1024)
            && y < 175 * ((float)Screen.width / 1024)&& y > 10 * ((float)Screen.width / 1024))
            return true;
        return false;
    }


    // Use this for initialization
    void Start(){
        terrainSize = new Vector2(
            Corner2.position.x - Corner1.position.x,
            Corner2.position.z - Corner1.position.z);
        mapRect = GetComponent<RectTransform>();
    }
    public Vector2 WorldPositionToMap(Vector3 point){
        //var pos = point - Corner1.position;
        var mapPos = new Vector2(
            point.x / terrainSize.x * (mapRect.rect.width) * ((float)Screen.width / 1024) + 10 * ((float)Screen.width / 1024),
            point.z  / terrainSize.y * (mapRect.rect.height) * ((float)Screen.width / 1024) + 10 * ((float)Screen.width / 1024));
        return mapPos;
    }
    public Vector3 MapPositionToWorld(Vector2 point){
        var worldPos = new Vector3(
            (point.x -10) * terrainSize.x / mapRect.rect.width / ((float)Screen.width / 1024),
            camera.transform.position.y,
            (point.y -10) * terrainSize.y / mapRect.rect.height / ((float)Screen.width / 1024) - 30*Mathf.Tan((float)0.5774));
        return worldPos;
    }
    // Update is called once per frame
    void Update(){
        //ViewPort.position = WorldPositionToMap(Camera.main.transform.position);
        if (Input.GetMouseButtonDown(0) 
            && EventSystem.current.IsPointerOverGameObject() 
            && IsMap(Input.mousePosition.x,Input.mousePosition.y)
            )
            camera.transform.position = MapPositionToWorld(Input.mousePosition);
    }
}
