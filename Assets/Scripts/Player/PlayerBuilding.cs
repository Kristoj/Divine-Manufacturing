using UnityEngine;
using System;
using Dima.Modules;

namespace Dima.Player {
    public class PlayerBuilding : MonoBehaviour {

        [Header("Building")]
        public float focusDistance = 3f;
        public LayerMask focusMask;
        private bool validPosition = false;
        private RaycastHit hit;

        [Header("Ghosting")]
        private GameObject ghostGameObject;
        public Mesh ghostMesh;
        public Material ghostMaterialValid;
        public Material ghostMaterialInvalid;
        private MeshFilter ghostFilter;
        private MeshRenderer ghostRenderer;

        // For debug, most likey will be removed in the future
        public string GreatestAxis { get; set; }

        // Update is called once per frame
        void Update() {
            CheckInput();
            CastRay();
        }

        void CheckInput() {
            // Placing
            if (Input.GetButtonDown("Fire1")) {
                PlaceWorldEntity();
            }
            // Removing
            if (Input.GetButtonDown("Fire2")) {
                RemoveWorldEntity();
            }
        }
        
        void CastRay() {
            Ray ray = new Ray(GameWorld.LocalPlayer.Player_Head.transform.position, GameWorld.LocalPlayer.Player_Head.transform.forward);
            if (Physics.Raycast(ray, out hit, focusDistance, focusMask, QueryTriggerInteraction.Collide)) {
                // Spawn ghost ?
                if (ghostGameObject == null) {
                    SpawnGhost();
                }
                OverLapCheck();
                UpdateGhost();
                return;
            }

            // Delete ghost ?
            if (ghostGameObject != null) {
                DestroyGhost();
            }
            validPosition = false;
        }

        void OverLapCheck() {
            // Check for overlapping colliders 
            Collider[] cols = Physics.OverlapBox(GetHitPosition(), new Vector3(.45f, .45f, .45f));
            if (cols.Length > 0) {
                validPosition = false;
                ghostRenderer.material = ghostMaterialInvalid;        // Update ghost material to invalid
                return;
            }
            validPosition = true;
            ghostRenderer.material = ghostMaterialValid;          // Update ghost material to valid
        }

        /* Divine solution by Kristo Johansson */
        /// <returns></returns>
        // Snap raycast hit to the grid
        public Vector3 GetHitPosition() {
            if (hit.collider != null) {
                Vector3 hitPos = hit.point;
                // Get the distance from the origin to the hit pos for each axis
                Vector3 originDistance = (hit.transform.position - hit.point);
                float longestDistance = 0;
                // Scale the length by colliders size
                originDistance.x /= hit.collider.bounds.size.x;
                originDistance.y /= hit.collider.bounds.size.y;
                originDistance.z /= hit.collider.bounds.size.z;

                /* Options for Dev-Stage */
                bool allowSmallerGrid = true;
                float gridSize = 1f;

                // Get the correct grid if target has a mesh collider
                if ((hit.collider as MeshCollider) != null) {
                    hitPos += hit.normal * .01f;
                }

                // Get the correct grid if the target has a primitive collider
                else {

                    float offset = gridSize * .5f;

                    /* Determine which axis has the longest distance from origin to hit position */
                    // Compare X and Y 
                    longestDistance = Mathf.Abs(originDistance.x) >= Mathf.Abs(originDistance.y) ? originDistance.x : originDistance.y;
                    // X was greater
                    if (longestDistance == originDistance.x) {
                        longestDistance = Mathf.Abs(originDistance.x) >= Mathf.Abs(originDistance.z) ? originDistance.x : originDistance.z;
                    }
                    // Y was greater
                    else {
                        longestDistance = Mathf.Abs(originDistance.y) >= Mathf.Abs(originDistance.z) ? originDistance.y : originDistance.z;
                    }

                    // X is greatest
                    if (longestDistance == originDistance.x) {
                        hitPos.x += (originDistance.x >= 0 ? -offset : offset);
                        GreatestAxis = originDistance.x >= 0 ? "-X" : "X";
                    }
                    // Y is greatest
                    else if (longestDistance == originDistance.y) {
                        hitPos.y += (originDistance.y >= 0 ? -offset * .5f : offset * .5f);
                        GreatestAxis = originDistance.y >= 0 ? "-Y" : "Y";
                    }
                    // Z is greatest
                    else {
                        hitPos.z += (originDistance.z >= 0 ? -offset : offset);
                        GreatestAxis = originDistance.z >= 0 ? "-Z" : "Z";
                    }
                }

                // Get rid of decimals
                hitPos.x = (float)(Math.Floor(hitPos.x));
                hitPos.y = (float)(Math.Floor(hitPos.y));
                hitPos.z = (float)(Math.Floor(hitPos.z));

                // Add grids half dimension
                hitPos.x += gridSize * .5f;
                hitPos.y += gridSize * .5f;
                hitPos.z += gridSize * .5f;

                // If smaller grids is enabled we potentialy need more work for the Y-Axis
                if (allowSmallerGrid && longestDistance == originDistance.y) {
                    float ySize = hit.collider.bounds.size.y;
                    if (originDistance.y <= 0)
                        hitPos.y += ySize - (float)(Math.Truncate(hit.collider.bounds.size.y));
                }
                return hitPos;
            }
            return Vector3.zero;
        }

        public RaycastHit GetRaycastInfo() {
            return hit;
        }

        void PlaceWorldEntity() {
            if (validPosition) {
                EntitySpawner.SpawnEntity(1, GetHitPosition());
                SoundSystem.PlaySound2D("item_place01");
            }
        }

        void RemoveWorldEntity() {
            if (hit.collider != null) {
                EntityCollider entityCollider = hit.collider.GetComponent<EntityCollider>();
                if (entityCollider != null) {
                    EntityColliders.RemoveEntityCollider(entityCollider);
                    EntityComponentStrapper.AddEntityComponentData(entityCollider.LinkedEntity, new EntityDestroyTagData{ Value = 1});
                }
            }
        }

        #region Ghosting
        // When ever player is placing a item show a ghost version of the model
        // that changes color depending if the target position is valid for placement

        void SpawnGhost() {
            // Instantiate ghost object and add necessary components to it
            ghostGameObject = new GameObject("Ghost GameObject");
            ghostFilter = ghostGameObject.AddComponent<MeshFilter>();
            ghostRenderer = ghostGameObject.AddComponent<MeshRenderer>();

            // Modify component values
            ghostFilter.mesh = ghostMesh;
            ghostRenderer.material = ghostMaterialValid;
            ghostRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            ghostRenderer.receiveShadows = false;
            ghostGameObject.transform.localScale = new Vector3(1.001f, 1.001f, 1.001f); // CHANGEMAYBE fast fix for z fighting
        }
        void UpdateGhost() {
            // Update ghost position ?
            if (ghostGameObject != null) {
                ghostGameObject.transform.position = GetHitPosition();
                return;
            }
        }

        void DestroyGhost() {
            Destroy(ghostGameObject);
            ghostGameObject = null;
        }
        #endregion
    }
}
