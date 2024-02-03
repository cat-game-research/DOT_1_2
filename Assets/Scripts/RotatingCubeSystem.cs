using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct RotatingCubeSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (localTransform, rotateSpeed)
            in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>())
        {
            localTransform.ValueRW = localTransform.ValueRW.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime);
        }
    }
}
