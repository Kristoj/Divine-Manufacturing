using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

namespace Dima.Modules {
    public static class EntitySpawner {
        
        /// <summary>
        /// Spawns a entity in the gameworld.
        /// </summary>
        public static void SpawnEntity(EntityReferenceData entityReferenceData, Vector3 spawnPos) {

            Entity entity = BootStrapper.entityManager.Instantiate
                (Database.Instance.GetDummyEntity(entityReferenceData.Value));                                              // Spawn the entity
            BootStrapper.entityManager.SetComponentData(entity, new Position { Value = spawnPos });                         // Set entitys position              
            EntityColliders.AddEntityCollider(spawnPos, entity);                                    // Spawn a collider for the entity 
        }

        public static void DestroyEntity(Entity entityToDestroy) {
            // Get every component data from the entity that we need
            EntityLinkedColliderData colData = 
                BootStrapper.entityManager.GetComponentData<EntityLinkedColliderData>(entityToDestroy);

            EntityColliders.RemoveEntityCollider(colData);                                                                  // Remove the collider that is linked to the entity
            EntityComponentStrapper.AddEntityComponentData(entityToDestroy,                                                 // Tag the entity to be destroyed
                new EntityDestroyTagData { Value = 1 });
        }
    }
}