using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

public static class EntityColliders {

    private static Dictionary<int, EntityCollider> colliders = new Dictionary<int, EntityCollider>();
    private static int collidersSpawned = 0;

    public static void AddEntityCollider(Vector3 colliderPosition, Entity entityToLink) {

        /* TODO We will eventually reach INT_MAX with collidersSpawned.
         We need to change the solution. */

        // Spawn new gameobject and attach box collider to it
        GameObject gm = new GameObject("Sector Collider" + collidersSpawned);
        EntityCollider entityCollider = gm.AddComponent<EntityCollider>();
        // Modify components
        entityCollider.EntityColliderIndex = collidersSpawned;
        entityCollider.LinkedEntity = entityToLink;
        colliders.Add(entityCollider.EntityColliderIndex, entityCollider);
        collidersSpawned++;
        // Link the collider to the entity
        BootStrapper.Entity_Manager.SetComponentData(entityToLink, new EntityLinkedColliderData { Value = entityCollider.EntityColliderIndex});
        // Orientate the gameobject
        entityCollider.transform.position = colliderPosition;
        entityCollider.transform.SetParent(WorldReference.SectorColliderParent);
        // Add a collider to the gameobject
        entityCollider.Collider = gm.AddComponent<BoxCollider>();
        entityCollider.Collider.size = (BootStrapper.Entity_Manager.GetComponentData<EntityBoundsData> (entityToLink)).Value;
    }

    public static void RemoveEntityCollider(EntityLinkedColliderData colliderData) {

        try {
            EntityCollider temp = GetEntityCollider(colliderData);
            colliders.Remove(colliderData.Value);
            MonoBehaviour.Destroy(temp.gameObject);
        }
        catch (Exception e) {
            Debug.LogException(e);
        }
    }

    public static EntityCollider GetEntityCollider(EntityLinkedColliderData colliderToFind) {
        try {
            //return colliderList[index];
            //return colliderList.Find(Predicate<entityC>);
            colliders.TryGetValue(colliderToFind.Value, out EntityCollider value);
            return value;
        }
        catch (Exception e) {
            Debug.LogException(e);
            return null;
        }
    }
    
}
