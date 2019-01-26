using UnityEngine;

public class PlayerToolbar : MonoBehaviour {

    private Slot[] Slots = new Slot[5];

    void Awake() {
        Init();    
    }

    void Init() {
        Slots[0].SlotEntityReferenceData = new EntityReferenceData(1);           // Set the slot0's world entity to default world entity
        Slots[1].SlotEntityReferenceData = new EntityReferenceData(2);           
        SelectedSlot = Slots[0];                                    // Select the first slot by default
    }

    void Update() {
        CheckInput();
    }

    void CheckInput() {
        // Slot 0
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectedSlot = Slots[0];
        // Slot 1
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectedSlot = Slots[1];
        // Slot 2
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectedSlot = Slots[2];
        // Slot 3
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SelectedSlot = Slots[3];
        // Slot 4
        if (Input.GetKeyDown(KeyCode.Alpha5))
            SelectedSlot = Slots[4];
    }

    public Slot SelectedSlot { get; set; }
    [SerializeField]
    public int GetSlotCount() {
        return Slots.Length + 1;
    }
}
