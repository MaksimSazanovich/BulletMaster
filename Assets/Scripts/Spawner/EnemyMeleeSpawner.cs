using UnityEngine;
using Zenject;

public class EnemyMeleeSpawner : MonoBehaviour
{

    [SerializeField] protected Transform[] spawnPoints;
    //private ObjectsPool enemyesPool;

    [SerializeField, Inject] DiContainer container;

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int enemyesCount;

    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float deltaTime;
    private float nextSpawnTime;

    //[Inject]
    //private void Init(EnemyesPool enemyesPool)
    //{
    //    this.enemyesPool = enemyesPool;
    //}

    //private void Start()
    //{
    //    enemyesPool.AddObjects(GetRandomEnemy(), enemyesCount);
    //}

    protected void Update()
    {
        nextSpawnTime += Time.deltaTime;

        if (nextSpawnTime >= timeBetweenSpawns)
        {
            Spawn();
            timeBetweenSpawns -= deltaTime;
            nextSpawnTime = 0;
        }
    }

    protected void Spawn()
    {
        //var enemy = enemyesPool.GetObject();

        //if (enemy == null)
        //    Debug.Log("!");
        //else 
        //{
        //enemy.transform.position = GetRandomTransform().position;
        //enemy.SetActive(true);

        container.InstantiatePrefab(GetRandomEnemy(), GetRandomTransform().position, Quaternion.identity, null);
        //}
    }

    private Transform GetRandomTransform()
    {
        int index;
        index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index];
    }

    private GameObject GetRandomEnemy()
    {
        int index;
        index = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[index];
    }
}
