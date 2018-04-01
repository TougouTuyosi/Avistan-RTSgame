using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSupport : MonoBehaviour {
    public List<GameObject> MyCastles = new List<GameObject>();
    public List<GameObject> MyFarms = new List<GameObject>();

    public List<GameObject> MyFreeKnights = new List<GameObject>();
    public List<GameObject> MyWorkKnights = new List<GameObject>();

    public List<GameObject> MyFreeMagicians = new List<GameObject>();
    public List<GameObject> MyWorkMagicians = new List<GameObject>();

    public List<GameObject> MyFreePriests = new List<GameObject>();
    public List<GameObject> MyWorkPriests = new List<GameObject>();

    public List<GameObject> SeizeBulids = new List<GameObject>();

    public PlayerSetupDefinition Player = null;

    public float SeizeTime = 0.0f;


    public static AiSupport GetSupport(GameObject go){
        return go.GetComponent<AiSupport>();
    }

    public void Refresh(){

        MyCastles.Clear();
        MyFarms.Clear();
        MyFreeKnights.Clear();
        MyFreeMagicians.Clear();
        MyFreePriests.Clear();
        foreach (var u in Player.ActiveUnits){
            if (u.GetComponent<UnitInfo>().UnitName == "剑兵"){
                if (!MyWorkKnights.Contains(u))
                    MyFreeKnights.Add(u);
            }

            if (u.GetComponent<UnitInfo>().UnitName == "法师")
                if (!MyWorkMagicians.Contains(u))
                    MyFreeMagicians.Add(u);

            if (u.GetComponent<UnitInfo>().UnitName == "牧师")
                if (!MyWorkPriests.Contains(u))
                    MyFreePriests.Add(u);

            if (u.GetComponent<UnitInfo>().UnitName == "兵营"){
                if (SeizeBulids.Contains(u)){
                    WorkClear(u);
                    SeizeBulids.Remove(u);
                }
                MyCastles.Add(u);
            }
            if (u.GetComponent<UnitInfo>().UnitName == "农场"){
                if (SeizeBulids.Contains(u)){
                    WorkClear(u);
                    SeizeBulids.Remove(u);
                }
                MyFarms.Add(u);
            }
        }
    }
    public void WorkClear(GameObject u){
        foreach(var a in u.GetComponent<SeizeBuild>().SeizeUnit){
            if (MyWorkKnights.Contains(a)){
                MyWorkKnights.Remove(a);
            }
        }
        u.GetComponent<SeizeBuild>().SeizeUnit.Clear();
    }
}
