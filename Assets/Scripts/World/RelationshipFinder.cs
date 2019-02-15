using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public static class RelationshipFinder {
    
    public static void UpdateEntityRelationships(Entity entityToUpdate) {

        // Get data that we need from the entity
        EntityBoundsData boundsData = BootStrapper.Entity_Manager.GetComponentData<EntityBoundsData>(entityToUpdate);
        Position posData = BootStrapper.Entity_Manager.GetComponentData<Position>(entityToUpdate);

        // Overlap check surroundings
        Collider[] overlaps = Physics.OverlapBox(posData.Value, boundsData.Value * .5f);
        if (overlaps.Length > 0) {
            List<EntityCollider> cols = new List<EntityCollider>();
            EntityCollider iterationCol;
            // Check if the overlapping colliders are actual entities
            for (int i = 0; i < overlaps.Length; i++) {
                iterationCol = overlaps[i].GetComponent<EntityCollider>();
                if (iterationCol != null) {
                    cols.Add(iterationCol);
                }
            }

            if (cols.Count > 0) {
                // Find if any of the entities that we hit is in a 
                for (int i = 0; i < cols.Count; i++) {

                    if (ValidateRelationship(entityToUpdate, cols[i].LinkedEntity)) {
                        
                    }
                }
            }
        }
    }

    public static bool ValidateRelationship(Entity sourceEntity, Entity entityToBeValidated) {
        // Entity reference data
        EntityReferenceData sourceRefData = BootStrapper.Entity_Manager.GetComponentData<EntityReferenceData>(entityToBeValidated);
        EntityReferenceData targetRefData = BootStrapper.Entity_Manager.GetComponentData<EntityReferenceData>(entityToBeValidated);
        //if ()
        Position sourcePosData = BootStrapper.Entity_Manager.GetComponentData<Position>(sourceEntity);
        Position targetPosData = BootStrapper.Entity_Manager.GetComponentData<Position>(entityToBeValidated);
        bool valid = false;


        //if ()
        // Not a valid entity
        return valid;
    }

}
