using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;

namespace Dima.Modules {
    public static class EntitySpawner {
        
        /// <summary>
        /// Spawns a world entity in the gameworld.
        /// </summary>
        public static void SpawnEntity(short moduleId, Vector3 spawnPos) {
            Entity entity = BootStrapper.entityManager.Instantiate(Database.Instance.GetDummyEntity(moduleId));     // Create entity
            BootStrapper.entityManager.SetComponentData(entity, new Position { Value = spawnPos });     // Set entity component data
            EntityColliders.AddEntityCollider(spawnPos, Vector3.one, entity);                           // Add collider for the entity
        }

        public static void DestroyEntity(Entity entityToDestroy) {
            
        }
    }
}