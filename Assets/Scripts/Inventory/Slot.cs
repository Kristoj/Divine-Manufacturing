
[System.Serializable]
public struct Slot {
    private EntityReferenceData pm_slotEntity;
    public EntityReferenceData SlotEntity {
        get {
            return pm_slotEntity;
        }
        set {
            pm_slotEntity = value;
            SlotEntityCount = 1;            // TEMP Set slot entity count to 1 for time being
        }
    }
    public int SlotEntityCount { get; set; }
}
