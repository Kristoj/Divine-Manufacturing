using Unity.Entities;
using Unity.Mathematics;

[System.Serializable]
public struct EntityBoundsData : IComponentData {
    public float3 Value;
}
public class EntityBoundsComponent : ComponentDataWrapper<EntityBoundsData> { }