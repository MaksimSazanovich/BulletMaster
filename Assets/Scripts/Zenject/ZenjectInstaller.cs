using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    [SerializeField] private GameObject targetPlayer;
    [SerializeField] private GameObject bulletsPool;
    [SerializeField] private GameObject enemyesPool;
    [SerializeField] private GameObject enemyBulletsPool;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject bonusSpawner;

    public override void InstallBindings()
    {
        Container.Bind<PlayerHealth>().FromComponentOn(targetPlayer).AsSingle();

        Container.Bind<BulletsPool>().FromComponentOn(bulletsPool).AsSingle();
        Container.Bind<EnemyBulletsPool>().FromComponentOn(enemyBulletsPool).AsSingle();

        Container.Bind<EnemyesPool>().FromComponentOn(enemyesPool).AsSingle();

        Container.Bind<LosePanel>().FromComponentOn(losePanel).AsSingle();

        Container.Bind<BonusSpawner>().FromComponentOn(bonusSpawner).AsSingle();
    }
}