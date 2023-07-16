using UnityEngine;

public class GetRandomTransformInBoundariesOfCameraStrategy : GetRandomTransformStrategyBase
{
     private float offset = 0.5f;
    public override Vector3  GetRandomTransform()
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        Vector3 spawnPosition = new Vector3(Random.Range(-screenBounds.x + offset, screenBounds.x - offset), Random.Range(-screenBounds.y + offset, screenBounds.y - offset), 0);
        return spawnPosition;
    }
}