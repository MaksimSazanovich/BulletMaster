using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] protected Transform[] spawnPoints;
    private ObjectsPool enemyesPool;

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int enemyesCount;

    [SerializeField] private int minEnemyCount;
    [SerializeField] private int maxEnemyCount;

    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float deltaTime;
    private float nextSpawnTime;

    private PlayerHealth playerHealth;

    private GetRandomTransformStrategyBase getRandomEnemyTransformStrategy;

    [Inject]
    private void Init(EnemyesPool enemyesPool, PlayerHealth playerHealth)
    {
        this.enemyesPool = enemyesPool;
        this.playerHealth = playerHealth;
    }
    private void OnEnable()
    {
        playerHealth.OnDie += Disactivate;
    }

    private void OnDisable()
    {
        playerHealth.OnDie -= Disactivate;
    }

    private void Start()
    {
        getRandomEnemyTransformStrategy = new GetRandomMeleeEnemyTransformStrategy();

        for (int i = 0; i < enemyesCount; i++)
        {
            enemyesPool.AddObject(GetRandomEnemy());
        }
    }

    protected virtual void Update()
    {
        nextSpawnTime += Time.deltaTime;

        if (nextSpawnTime >= timeBetweenSpawns)
        {
            for (int i = 0; i < GetRandomEnemyCount(); i++)
            {
                Spawn();
            }
            timeBetweenSpawns -= deltaTime;
            nextSpawnTime = 0;
        }
    }

    protected void Spawn()
    {
        var enemy = enemyesPool.GetRandomObject();

        if (enemy == null)
            Debug.Log("! enemy");
        else
        {
            if (enemy.TryGetComponent(out EnemyMeleeAttack enemyMeleeAttack))
            {
                ChangeStrategyToMeleeEnemy();
                enemy.transform.position = getRandomEnemyTransformStrategy.GetRandomTransform(spawnPoints);
            }
            else if (enemy.TryGetComponent(out EnemyRangedAttack enemyRangedAttack))
            {
                ChangeStrategyToRangedEnemy();
                enemy.transform.position = getRandomEnemyTransformStrategy.GetRandomTransform();
            }
            enemy.SetActive(true);
        }
    }

    private GameObject GetRandomEnemy()
    {
        int index;
        index = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[index];
    }

    private int GetRandomEnemyCount()
    {
        return Random.Range(minEnemyCount, maxEnemyCount);
    }

    private void ChangeStrategy(GetRandomTransformStrategyBase strategy)
    {
        getRandomEnemyTransformStrategy = strategy;
    }

    private void ChangeStrategyToMeleeEnemy() => ChangeStrategy(new GetRandomMeleeEnemyTransformStrategy());
    private void ChangeStrategyToRangedEnemy() => ChangeStrategy(new GetRandomTransformInBoundariesOfCameraStrategy());

    private void Disactivate() => gameObject.SetActive(false);
}