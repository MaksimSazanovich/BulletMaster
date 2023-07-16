using UnityEngine;
using Zenject;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawns;
    private float nextSpawnTime;

    [SerializeField] GameObject[] bonuses;

    private GetRandomTransformStrategyBase getRandomEnemyTransformStrategy;

    private void Start()
    {
        getRandomEnemyTransformStrategy = new GetRandomTransformInBoundariesOfCameraStrategy();
    }
    protected virtual void Update()
    {
        nextSpawnTime += Time.deltaTime;

        if (nextSpawnTime >= timeBetweenSpawns)
        {
            SpawnRandomBonus();
            nextSpawnTime = 0;
        }
    }

    private void SpawnRandomBonus()
    {
        Instantiate(GetRandomBonus(), getRandomEnemyTransformStrategy.GetRandomTransform(), Quaternion.identity);
    }

    public void SpawnCoin(Vector3 spawnPosition)
    {
        Instantiate(bonuses[(int)BonusType.Coin], spawnPosition, Quaternion.identity);
    }

    private GameObject GetRandomBonus()
    {
        int index;
        index = Random.Range(0, bonuses.Length - 1);
        return bonuses[index];
    }
}