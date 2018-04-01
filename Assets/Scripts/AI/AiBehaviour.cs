using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiBehaviour : MonoBehaviour {
    public float WeightMultiplier = 1;
    public float TimePassed = 0;
    public abstract float GetWeight();  //AI重要度
    public abstract void Excute();  //执行决策
}
