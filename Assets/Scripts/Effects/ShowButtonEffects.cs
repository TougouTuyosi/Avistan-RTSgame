using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowButtonEffects : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler{

    public GameObject Effects;
    private Color color = new Color(255, 255, 255, 128);

    public void OnPointerEnter(PointerEventData eventData){
        Effects.gameObject.SetActive(true);
        Effects.transform.position = transform.position;
        color.a = 1.0f;
        GetComponent<Image>().color = color;
    }

    public void OnPointerExit(PointerEventData eventData){
        Effects.gameObject.SetActive(false);
        color.a = 0.5f;
        GetComponent<Image>().color = color;
    }

    // Use this for initialization
    void Start () {
        color.a = 0.5f;
        GetComponent<Image>().color = color;
        Effects.SetActive(false);
    }
}
