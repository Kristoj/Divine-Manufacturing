using UnityEngine;
using System.Collections;
using Unity.Entities;
using Unity.Mathematics;

public class Debug_Scene_Main : ComponentSystem {

    protected override void OnStartRunning() {
        base.OnStartRunning();
        SpawnEntities();
    }

    void SpawnEntities() {
        const bool spawnEntitiesOnStart = true;
        if (spawnEntitiesOnStart) {
            EntitySpawner.SpawnEntity(new EntityReferenceData(2), new float3(-3.5f, .5f, -4.5f));
            Database.Instance.StartCoroutine(InserterSpawnDelay());
        }
    }

    IEnumerator InserterSpawnDelay() {
        yield return new WaitForSeconds(.25f);
        EntitySpawner.SpawnEntity(new EntityReferenceData(3), new float3(-3.5f, .5f, -2.5f));
    }


    protected override void OnUpdate() {
        // Piss off abstract method
    }
}
