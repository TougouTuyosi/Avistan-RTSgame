using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ActionManager : MonoBehaviour {
	public static ActionManager Current;
	public Button[] Buttons;
	private List<Action> actionCalls = new List<Action>();
	public Button[] DeleteCreateButtons;
	private List<Action> actionDeleteCreates = new List<Action>();
	public ActionManager(){
		Current = this;
	}
	public void ClearButtons(){
		foreach(var b in Buttons){
			b.gameObject.SetActive(false);
		}
		actionCalls.Clear();
	}
	public void AddButton(Sprite pic, Action onClick,int i){
		Buttons[i].gameObject.SetActive(true);
		Buttons[i].GetComponent<Image>().sprite = pic;
		actionCalls.Add(onClick);
	}
	public void OnButtonClick(int index) {
		actionCalls[index] ();
	}
	public void ClearDeleteCreateButtons(){
		foreach(var b in DeleteCreateButtons){
			b.gameObject.SetActive(false);
		}
		actionDeleteCreates.Clear();
	}
	public void AddDeleteCreateButton(Sprite pic, Action onClick,int i){
		DeleteCreateButtons[i].gameObject.SetActive(true);
		DeleteCreateButtons[i].GetComponent<Image>().sprite = pic;
		actionDeleteCreates.Add(onClick);
	}		
	public void OnDeleteCreateButtonClick(int index) {
		actionDeleteCreates[index] ();
	}
	void Start () {
		Buttons[0].onClick.AddListener(delegate () {OnButtonClick(0);});
		Buttons[1].onClick.AddListener(delegate () {OnButtonClick(1);});
		Buttons[2].onClick.AddListener(delegate () {OnButtonClick(2);});
        Buttons[3].onClick.AddListener(delegate () {OnButtonClick(3);});
        ClearButtons();

		DeleteCreateButtons[0].onClick.AddListener(delegate () {OnDeleteCreateButtonClick(0);});
		DeleteCreateButtons[1].onClick.AddListener(delegate () {OnDeleteCreateButtonClick(1);});
		DeleteCreateButtons[2].onClick.AddListener(delegate () {OnDeleteCreateButtonClick(2);});
		DeleteCreateButtons[3].onClick.AddListener(delegate () {OnDeleteCreateButtonClick(3);});
		DeleteCreateButtons[4].onClick.AddListener(delegate () {OnDeleteCreateButtonClick(4);});
		DeleteCreateButtons[5].onClick.AddListener(delegate () {OnDeleteCreateButtonClick(5);});
		DeleteCreateButtons[6].onClick.AddListener(delegate () {OnDeleteCreateButtonClick(6);});
		DeleteCreateButtons[7].onClick.AddListener(delegate () {OnDeleteCreateButtonClick(7);});
		DeleteCreateButtons[8].onClick.AddListener(delegate () {OnDeleteCreateButtonClick(8);});
		ClearDeleteCreateButtons ();
	}
}
