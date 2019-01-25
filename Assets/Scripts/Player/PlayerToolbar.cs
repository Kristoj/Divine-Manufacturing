using UnityEngine;

public class PlayerToolbar : MonoBehaviour {

    [SerializeField] private Slot[] Slots = new Slot[5];

    void Awake() {
        Init();    
    }

    void Init() {
        Slots[0].SlotEntity = new EntityReferenceData(1);           // Set the slot0's world entity to default world entity
        SelectedSlot = Slots[0];                                    // Select the first slot by default
    }

    void Update() {
        CheckInput();
    }

    void CheckInput() {
        // Slot 0
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Slots[0].SlotEntity = Slots[0].SlotEntity;
        // Slot 1
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Slots[1].SlotEntity = Slots[1].SlotEntity;
        // Slot 2
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Slots[2].SlotEntity = Slots[2].SlotEntity;
        // Slot 3
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Slots[3].SlotEntity = Slots[3].SlotEntity;
        // Slot 4
        if (Input.GetKeyDown(KeyCode.Alpha5))
            Slots[4].SlotEntity = Slots[4].SlotEntity;
    }

    public Slot SelectedSlot { get; set; }
    [SerializeField]
    public int GetSlotCount() {
        return Slots.Length + 1;
    }
}
