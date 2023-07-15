using UnityEngine;

public class GetRandomEnemyTransformStrategyBase : MonoBehaviour
{
    public virtual Vector3 GetRandomTransform(Transform[] spawnPoints)
    {
        return Vector3.zero;
    }

    public virtual Vector3 GetRandomTransform()
    {
        return Vector3.zero;
    }
}