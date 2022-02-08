using UnityEngine;
using Zenject;

public class BulletPoolInstaller : MonoInstaller
{
    [SerializeField] private BulletPool bulletPool;
    public override void InstallBindings()
    {
        Container.Bind<BulletPool>()
            .FromInstance(bulletPool)
            .AsSingle()
            .NonLazy();
        Container
            .QueueForInject(bulletPool);
    }
}