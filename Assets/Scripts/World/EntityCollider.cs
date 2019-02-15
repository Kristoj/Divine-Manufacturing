using UnityEngine;
using Unity.Entities;

/// <summary>
/// This is attached to the collider gameobject and holds reference to the linked entity.
/// </summary>
public class EntityCollider : MonoBehaviour {

    public int EntityColliderIndex { get; set; }
    /// <summary>
    /// Collider attached to this object.
    /// </summary>
    public BoxCollider Collider { get; set; }
    public Entity LinkedEntity { get; set; }

}