using Unity.Entities;

[System.Serializable]
public struct Slot {
    private EntityReferenceData pm_slotEntityReferenceData;
    public EntityReferenceData SlotEntityReferenceData {
        get {
            return pm_slotEntityReferenceData;
        }
        set {
            pm_slotEntityReferenceData = value;
            SlotEntityCount = 1;            // TEMP Set slot entity count to 1 for time being
        }
    }
    public int SlotEntityCount { get; set; }
}
