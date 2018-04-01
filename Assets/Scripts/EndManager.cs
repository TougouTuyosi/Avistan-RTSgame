using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndManager : MonoBehaviour {
    public Image WinImage, LostImage;
    public Text EndText;
    public bool EndA;
    private float timeSpend = 0.0f,Endtime = 10.0f;
    private bool IsEnd = false;
    // Update is called once per frame
    void Start(){
        WinImage.gameObject.SetActive(false);
        LostImage.gameObject.SetActive(false);
        EndText.gameObject.SetActive(false);
    }

    void Update () {
        timeSpend += Time.deltaTime;
        if (timeSpend < 1)
            return;

        if(Endtime <= 0){
            SceneManager.LoadScene("Start Scene", LoadSceneMode.Single);
        }

        if (IsEnd){
            EndText.gameObject.SetActive(true);
            EndText.text = (int)Endtime + "秒后游戏结束";
            Endtime -= Time.deltaTime;
            return;
        }

        if (EndA){
            if (timeSpend <= 1800){
                foreach (var p in Manager.Current.Players){
                    if (p.ActiveUnits.Count == 0){
                        if (!p.IsAi){
                            WinImage.gameObject.SetActive(true);
                            IsEnd = true;
                        }
                    }
                }
                return;
            }
            WinImage.gameObject.SetActive(true);
            IsEnd = true;
            return;
        }
        foreach (var p in Manager.Current.Players){
            if (p.Name == "Neutral")
                continue;
            if (p.ActiveUnits.Count == 0){
                if (p.IsAi){
                    WinImage.gameObject.SetActive(true);
                    IsEnd = true;
                }
                else{
                    LostImage.gameObject.SetActive(true);
                    IsEnd = true;
                }
            }
        }
    }
}
