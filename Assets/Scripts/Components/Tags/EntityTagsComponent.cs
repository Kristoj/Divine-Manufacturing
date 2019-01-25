using Unity.Entities;

/// <summary>
/// Used to mark an entity to be destroyed by a system
/// </summary>
public struct EntityDestroyTagData : IComponentData {
    public byte Value;
}
