using UnityEngine;
using Unity.Entities;
using Unity.Jobs;

public static class EntityComponentStrapper {

    public static void AddEntityComponentData(Entity targetEntity, EntityDestroyTagData componentToAdd) {
        BootStrapper.Entity_Manager.AddComponentData(targetEntity, componentToAdd);
    }

    public static void RemoveEntityComponentData() {

    }

}
