using Unity.Entities;

[System.Serializable]
public struct EntityLinkedColliderData : IComponentData {
    public int Value;
}
public class EntityLinkedColliderComponent : ComponentDataWrapper<EntityLinkedColliderData> { }