using UnityEngine;
using Dima.Player;

public class Player : MonoBehaviour {

    // Reference classes
    public PlayerCamera Player_Camera { get; set; }
    public PlayerController Player_Controller { get; set; }
    public PlayerBuilding Player_Building { get; set; }
    public Transform Player_Head { get; set; }

    // Start is called before the first frame update
    void Awake() {
        GameWorld.LocalPlayer = this; // Register local player
        SetupReferences(); // Setup references that other classes might use
    }

    
    // On awake we find each objects reference
    void SetupReferences() {

        // Player components
        Player_Camera = GetComponent<PlayerCamera>();
        Player_Controller = GetComponent<PlayerController>();
        Player_Building = GetComponent<PlayerBuilding>();

        // Player head
        Transform t = transform.GetChild(0);
        if (t.name == "Head") {
            Player_Head = t;
        } else {
            Debug.LogError("Player HEAD gameobject must be the first child!");
        }

    }
}
