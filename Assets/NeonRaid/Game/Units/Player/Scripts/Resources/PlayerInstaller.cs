using UnityEngine;
using Zenject;

namespace NeonRaid.GamePlay.Units.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerDamageController playerDamage;
        public override void InstallBindings()
        {
            Container.Bind<PlayerData>()
                .FromComponentInNewPrefab(playerData)
                .AsSingle();

            Container.Bind<PlayerMovement>()
                .FromComponentInNewPrefab(playerMovement)
                .AsSingle();

            Container.Bind<PlayerDamageController>()
                .FromComponentInNewPrefab(playerDamage)
                .AsSingle();
        }
    }
}
