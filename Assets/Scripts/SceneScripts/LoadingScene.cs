using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour {

    private AsyncOperation async;//异步加载操作   
    public Slider process;

    // Use this for initialization
    void Start () {
        process.GetComponent<Slider>().value = 0;
        StartCoroutine(loading());//利用协程来进行加载，也就是异步加载  
    }

    IEnumerator loading(){
        async = SceneManager.LoadSceneAsync(Global.global_name);
        yield return async;
    }
    // Update is called once per frame
    void Update () {
        process.GetComponent<Slider>().value =(int)(async.progress * 100);
    }
}
