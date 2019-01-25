using Unity.Entities;

public struct EntityReferenceData : IComponentData {
    public short Value;

    public EntityReferenceData(short entityId) {
        Value = entityId;
    }
}

public class EntityReferenceComponent : ComponentDataWrapper<EntityReferenceData> { }