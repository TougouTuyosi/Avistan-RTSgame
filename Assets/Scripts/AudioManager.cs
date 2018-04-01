using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Current = null;
    public AudioManager(){
        Current = this;
    }

    public AudioSource BGM,SE;

    public List<AudioClip> bgm= new List<AudioClip>();
    public List<AudioClip> se = new List<AudioClip>();

    float bgmtime = 0;

    public void SetSE(int i){
        if (se[i] == null)
            return;
        SE.clip = se[i];
        SE.Play();
    }
    public void SetBGM(int i)
    {
        if (bgm[i] == null)
            return;
        BGM.clip = bgm[i];
        BGM.Play();
    }

    void Update(){
        if (BGM.clip != bgm[3])
            return;
        bgmtime += Time.deltaTime;
        if (bgmtime >= 300)
            BGM.clip = bgm[2];
    }
}
