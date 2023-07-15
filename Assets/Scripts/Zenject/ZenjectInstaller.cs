using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    [SerializeField] private GameObject targetPlayer;
    [SerializeField] private GameObject bulletsPool;
    [SerializeField] private GameObject enemyesPool;

    public override void InstallBindings()
    {
        Container.Bind<PlayerHealth>().FromComponentOn(targetPlayer).AsSingle();
        Container.Bind<BulletsPool>().FromComponentOn(bulletsPool).AsSingle();
        Container.Bind<EnemyesPool>().FromComponentOn(enemyesPool).AsSingle();
    }
}