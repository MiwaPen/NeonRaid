using UnityEngine;
using Zenject;

public class ScoreCounterInstaller : MonoInstaller
{
    [SerializeField] private ScoreCounter scoreCounter;
    public override void InstallBindings()
    {
        Container.Bind<ScoreCounter>()
            .FromInstance(scoreCounter)
            .AsSingle();
    }
}