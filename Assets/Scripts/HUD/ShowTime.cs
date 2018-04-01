using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour {
    int hour;
    int minute;
    int second;
    // 已经花费的时间 
    float timeSpend = 0.0f;
    // 显示时间区域的文本 
    Text text_timeSpend;
    // Use this for initialization 
    void Start(){
        text_timeSpend = GetComponent<Text>();
    }
    // Update is called once per frame 
    void Update(){
        timeSpend += Time.deltaTime;
        // GlobalSetting.timeSpent = timeSpend;
        hour = (int)timeSpend / 3600;
        minute = ((int)timeSpend - hour * 3600) / 60;
        second = (int)timeSpend - hour * 3600 - minute * 60;
        text_timeSpend.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
    }
}
