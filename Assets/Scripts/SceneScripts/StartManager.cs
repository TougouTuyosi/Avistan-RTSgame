using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

	public Button StartStory,StartBattle,LoadGame,Menu, GameExit;

    public Button Back;

	public Image StartPage,StoryPage;

	// Use this for initialization

	void StoryMenu(bool s){
		StartPage.gameObject.SetActive (!s);
		StoryPage.gameObject.SetActive (s);
	}

    void ToLoading(string Scenename){
        AudioManager.Current.SetSE(1);
        Global.global_name = Scenename;
        SceneManager.LoadScene("Loading Scene", LoadSceneMode.Single);
    }

	void Start () {
		StartPage.gameObject.SetActive (true);
		StoryPage.gameObject.SetActive (false);
        /* StartStory.GetComponent<Button>().onClick.AddListener(
			delegate () { StoryMenu(true); });
       Back.GetComponent<Button>().onClick.AddListener(
            delegate () { StoryMenu(false); });*/
        StartBattle.GetComponent<Button>().onClick.AddListener(
			delegate () { ToLoading("Battle Scene"); });
		GameExit.GetComponent<Button>().onClick.AddListener(
			delegate () { AudioManager.Current.SetSE(1); Application.Quit(); });
    }
}
