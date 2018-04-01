using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MeumButton : MonoBehaviour {

    public GameObject meum;
    public Button meumbutton,overgameButton,startgamebutton,exitgamebutton;
    // Use this for initialization
    void Meum(){
        meum.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void Overgame(){
        meum.gameObject.SetActive(false);
        Time.timeScale = 1;
        foreach(var u in Manager.Current.Players[0].ActiveUnits){
            Destroy(u);
        }
    }

    void startgame(){
        meum.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void exitgame(){
        Time.timeScale = 1;
        SceneManager.LoadScene("start Scene", LoadSceneMode.Single);
    }


    void Start () {
        meum.gameObject.SetActive(false);
        meumbutton.GetComponent<Button>().onClick.AddListener(delegate () { Meum(); });
        overgameButton.GetComponent<Button>().onClick.AddListener(delegate () { Overgame(); });
        startgamebutton.GetComponent<Button>().onClick.AddListener(delegate () { startgame(); });
        exitgamebutton.GetComponent<Button>().onClick.AddListener(delegate () { exitgame(); });
    }
}
