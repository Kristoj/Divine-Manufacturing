using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolbar : MonoBehaviour {

    public WorldEntity[] startingEntities;
    private Slot[] Slots;
    [SerializeField] private int maxSlots = 5;

    void Awake() {
        
    }

    public Slot SelectedSlot { get; set; }
    [SerializeField]
    public int GetSlotCount() {
        return startingEntities.Length <= maxSlots ? maxSlots : startingEntities.Length + 1;
    }

    void Update() {
        CheckInput();
    }

    void CheckInput() {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
            //Slots[1].slotEntity = startingEntities[1];

    }

}
