using UnityEngine;
using Zenject;

public class UserInstaller : MonoInstaller
{
    [SerializeField] private UserData userData;
    [SerializeField] private UserSettings userSettings;
    public override void InstallBindings()
    {
        Container.Bind<UserData>()
            .FromInstance(userData)
            .AsSingle();
        Container.Bind<UserSettings>()
            .FromInstance(userSettings)
            .AsSingle();
    }
}