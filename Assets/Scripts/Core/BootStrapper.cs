using Unity.Entities;

public class BootStrapper : ComponentSystem {

    // Fields
    public static EntityManager entityManager;

    // When the game start create the entity manager and 
    // setup needed archetypes
    protected override void OnStartRunning() {
        entityManager = World.GetOrCreateManager<EntityManager>();
    }

    protected override void OnUpdate() {
        // TODO ?
    }

}
