using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSetupDefinition{
    public string Name;  //玩家名字

    public Transform Location;  //初始位置

    public Color AccentColor;  //区别色

    public List<GameObject> StartingUnits = new List<GameObject>();  //初始单位列表，泛型

    private List<GameObject> activeUnits = new List<GameObject>();  //追踪活动的单位

    public List<GameObject> ActiveUnits{
        get{
            return activeUnits;
        }
    }

    public int Atklevel = 10, Deflevel = 10;

    public List<PlayerTeam> PlayerTeams = new List<PlayerTeam>(); //追踪小队信息

    public bool IsAi;  //判断是否为AI控制

    public float Credits;  //资源信息

}
