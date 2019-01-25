#pragma warning disable 0649
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;

public class EntityDestroyerSystem : JobComponentSystem {

    class EntityDestroyerBarrier : BarrierSystem { }
    [Inject] private EntityDestroyerBarrier barrier;
    [Inject] private Data data;

    struct Data {
        public readonly int Length;
        public EntityArray Entities;
        public ComponentDataArray<EntityDestroyTagData> Tags;
    }

    [BurstCompile]
    struct Job : IJobParallelFor {
        public EntityCommandBuffer.Concurrent CommandBuffer;
        public ComponentDataArray<EntityDestroyTagData> Tags;
        [ReadOnly] public EntityArray Entities;

        public void Execute(int index) {
            CommandBuffer.DestroyEntity(0, Entities[index]);
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps) {
        return new Job {
            CommandBuffer = barrier.CreateCommandBuffer().ToConcurrent(),
            Entities = data.Entities,
            Tags = data.Tags
        }.Schedule(data.Length, 64, inputDeps);
    }

}