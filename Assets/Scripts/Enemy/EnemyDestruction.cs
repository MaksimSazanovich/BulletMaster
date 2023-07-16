using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemyDestruction : MonoBehaviour
{
    [SerializeField] private float bonusChance;
    private int maxCount;

    private BonusSpawner bonusSpawner;

    [Inject]
    private void Init(BonusSpawner bonusSpawner)
    {
        this.bonusSpawner = bonusSpawner;
    }

    private void Start()
    {
        maxCount = Mathf.RoundToInt(1 / bonusChance);
    }
    public void Activate()
    {
        if (Random.Range(0, maxCount + 1) == 0)
            bonusSpawner.SpawnCoin(transform.position);
    }

}