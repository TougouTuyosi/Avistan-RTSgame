using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float MoveSpeed = 20;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public Transform Location;


    // Use this for initialization
    void Start () {
        transform.Translate(Location.position.x, 0, Location.position.z - 10);
    }
	
	// Update is called once per frame
	void Update () {
        //通过鼠标移动到画面外进行移动
        Vector3 mp = Input.mousePosition;
        Vector3 moveDir = Vector3.zero;
        if (mp.x <= 0f)moveDir.x = -1;
        if (mp.x >= Screen.width - 2)moveDir.x = 1;
        if (mp.y <= 0f)moveDir.z = -1;
        if (mp.y >= Screen.height - 2)moveDir.z = 1;
        moveDir.Normalize();
        transform.Translate(moveDir * MoveSpeed * Time.deltaTime);
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        currentPosition.z = Mathf.Clamp(currentPosition.z, minZ, maxZ);
        transform.position = currentPosition;
        //以下通过方向键控制画面，亦可通过手柄操控。
        transform.Translate(
            Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime,
            0,
            Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime);
    }
}
