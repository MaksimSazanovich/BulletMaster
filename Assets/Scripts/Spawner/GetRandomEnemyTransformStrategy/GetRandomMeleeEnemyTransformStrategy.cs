using UnityEngine;

public class GetRandomMeleeEnemyTransformStrategy : GetRandomEnemyTransformStrategyBase
{
    public override Vector3 GetRandomTransform(Transform[] spawnPoints)
    {
        int index;
        index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index].position;
    }
}