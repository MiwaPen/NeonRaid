using UnityEngine;
using Zenject;

public class RoadInstaller : MonoInstaller
{
    [SerializeField] private RoadContainerScript roadContainer;
    public override void InstallBindings()
    {
        Container.Bind<RoadContainerScript>()
            .FromInstance(roadContainer)
            .AsSingle()
            .NonLazy();
    }
}