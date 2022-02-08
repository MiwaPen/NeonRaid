using UnityEngine;
using Zenject;

public class EnemyPoolInstaller : MonoInstaller
{
    [SerializeField] private EnemyPool enemyPool;
    public override void InstallBindings()
    {
        Container.Bind<EnemyPool>()
            .FromInstance(enemyPool)
            .AsSingle()
            .NonLazy();
    }
}