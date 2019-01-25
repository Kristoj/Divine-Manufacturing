using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;

namespace Dima.Modules {
    public static class ModuleSpawner {
        
        /// <summary>
        /// Spawns a world entity in the gameworld.
        /// </summary>
        public static void SpawnWorldEntity(int moduleId, Vector3 spawnPos) {
            Entity entity = BootStrapper.entityManager.Instantiate(Database.Instance.modulePrefab);     // Create entity
            BootStrapper.entityManager.SetComponentData(entity, new Position { Value = spawnPos });     // Set entity component data
            SectorColliders.AddEntityCollider(spawnPos, Vector3.one, entity);                           // Add collider for the entity
        }

        public static void DestroyWorldEntity(Entity entityToDestroy) {
            
        }
    }
}