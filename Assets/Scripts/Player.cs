using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerSetupDefinition Info;
    public static PlayerSetupDefinition Default;
    void Start(){
        Info.ActiveUnits.Add(gameObject);
    }
    void OnDestroy() {
        Info.ActiveUnits.Remove(gameObject);
    }
}
