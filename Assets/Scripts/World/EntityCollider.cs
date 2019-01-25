using UnityEngine;
using Unity.Entities;

public class EntityCollider : MonoBehaviour {

    public int EntityColliderIndex { get; set; }
    /// <summary>
    /// Collider attached to this object.
    /// </summary>
    public BoxCollider Collider { get; set; }
    public Entity LinkedEntity { get; set; }

}