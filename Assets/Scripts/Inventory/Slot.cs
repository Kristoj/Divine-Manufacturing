using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Slot {

    private int pm_slotData;
    public int SlotData {
        get {
            return pm_slotData;
        }
        set {
            pm_slotData = value;
        }
    }
}
