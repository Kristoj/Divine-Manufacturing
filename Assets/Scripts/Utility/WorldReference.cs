using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldReference {

    public static void OnAwake() {
        SetReferences();
    }

    /// <summary>
    /// Used to get reference to the parent of every world entity collider in the world
    /// </summary>
    public static Transform SectorColliderParent { get; set; } 

    static void SetReferences() {
        Transform db = Database.Instance.transform;

        // Sector colider parent ref
        for (int i = 0; i < db.transform.childCount; i++) {
            if (db.GetChild(i).name == "Sectors") {
                for (int j = 0; j < db.GetChild(i).childCount; j++) {
                    if (db.GetChild(i).GetChild(j).name == "Colliders") {
                        SectorColliderParent = db.GetChild(i).GetChild(j);
                    }
                }
            }
        }
    }
}
