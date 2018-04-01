using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour {
 

    public static InfoManager Current = null;

    public InfoManager(){
        Current = this;
    }

	public Image Info,BulidInfo;
	public Slider CreateSchedule,UnitHp;
	public Text BulidName, BulidHP, CreateName;

	public void ShowInfo(){
		Info.gameObject.SetActive (true);
	}

	public void ClearInfo(){
		Info.gameObject.SetActive (false);
	}

	public void SetCreateSchedule(float c){
		CreateSchedule.value = c;
		if (c != 0) 
			CreateSchedule.gameObject.SetActive (true);
		else
			CreateSchedule.gameObject.SetActive (false);
	}

	public void SetUnitNameAndHp(string Name,string HP){
		BulidName.text = Name;
		BulidHP.text = HP;
	}

	public void SetHp(float CurrentHp,float MaxHp){
		UnitHp.maxValue = MaxHp;
		UnitHp.value = CurrentHp;
	}

	public void SetCreateName(string Name){
		CreateName.text = Name;
	}


    // Use this for initialization
    void Start () {
		Info.gameObject.SetActive (false);
    }
}
