using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour {

    public string PlayerName;

    public float Confusion = 1.0f;
    public float Frequency = 1;
    private float waited = 0;

    private List<AiBehaviour> Ais = new List<AiBehaviour>();

    public PlayerSetupDefinition player;
    public PlayerSetupDefinition Player{
        get{
            return player;
        }
    }

    // Use this for initialization
    void Start () {
        foreach (var ai in GetComponents<AiBehaviour>())
            Ais.Add(ai);
        foreach (var p in Manager.Current.Players){
            if (p.Name == PlayerName)
                player = p;
        }
        gameObject.AddComponent<AiSupport>().Player = player;
    }
	
	// Update is called once per frame
	void Update () {
        if (player.ActiveUnits.Count == 0)
            return;
        waited += Time.deltaTime;
        if (waited < Frequency)
            return;

        string aiLog = "";

        float bestAiValue = float.MinValue;
        AiBehaviour bestAi = null;
        AiSupport.GetSupport(gameObject).Refresh();

        foreach (var ai in Ais){
            ai.TimePassed += waited;
            var aiValue = ai.GetWeight() * ai.WeightMultiplier + Random.Range(0, Confusion);

            aiLog += ai.GetType().Name + ":" + aiValue + "\n";

            if (aiValue > bestAiValue){
                bestAiValue = aiValue;
                bestAi = ai;
            }
        }
        //Debug.Log(aiLog);
        bestAi.Excute();
        waited = 0;
    }
}
