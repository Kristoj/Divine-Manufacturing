using UnityEngine;
using Unity.Entities;

public class BootStrapper : ComponentSystem {

    // Fields
    private static EntityManager pm_entity_manager;
    public static EntityManager Entity_Manager {
        get {
            if (pm_entity_manager == null) {
                Debug.LogError("CRITIKAL ERROR: Trying to get reference to the entity manager that doesn't exist yet.");
                return null;
            }
            return pm_entity_manager;
        }
        set {
            pm_entity_manager = value;
        }
    }

    void Setman() {

    }

    // When the game start create the entity manager and 
    // setup needed archetypes
    protected override void OnStartRunning() {
        Entity_Manager = World.GetOrCreateManager<EntityManager>();
    }

    protected override void OnUpdate() {
        // TODO ?
    }

}
