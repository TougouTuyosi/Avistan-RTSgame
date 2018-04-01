using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfo : MonoBehaviour {
    public string UnitName, UnitTag;
	public Sprite Unitimage;
    public float MaxHitPoints, CurrentHitPoints;
    public float defense,Damage,AttackDistance,AttackWait;
    public bool IsDoctor,IsBuilding, CanOccupy;
    public string AnimationName = "walk";
	public float Cash;
}
