using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System;

public static class SectorColliders {

    private static Dictionary<int, EntityCollider> colliders = new Dictionary<int, EntityCollider>();
    private static int collidersSpawned = 0;

    public static void AddEntityCollider(Vector3 colliderPosition, Vector3 colliderSize, Entity entityToLink) {

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
        // Orientate the gameobject
        entityCollider.transform.position = colliderPosition;
        entityCollider.transform.SetParent(WorldReference.SectorColliderParent);
        // Add a collider to the gameobject
        entityCollider.Collider = gm.AddComponent<BoxCollider>();
        entityCollider.Collider.size = colliderSize;
    }

    public static void RemoveEntityCollider(EntityCollider entityColliderToRemove) {

        try {
            //colliders.Remove(entityColliderToRemove);
            colliders.Remove(entityColliderToRemove.EntityColliderIndex);
            MonoBehaviour.Destroy(entityColliderToRemove.gameObject);
        }
        catch (Exception e) {
            Debug.LogException(e);
        }
    }

    public static EntityCollider GetEntityCollider(EntityCollider entityColliderToFind) {
        try {
            //return colliderList[index];
            //return colliderList.Find(Predicate<entityC>);
            colliders.TryGetValue(entityColliderToFind.EntityColliderIndex, out EntityCollider value);
            return value;
        }
        catch (Exception e) {
            Debug.LogException(e);
            return null;
        }
    }
    
}
