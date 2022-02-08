using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;

public class WeaponScript : MonoBehaviour
{
    [Inject] private BulletPool bulletPool;
    [SerializeField] private Units units;
    [SerializeField] private int delayMS; 
    private bool canShoot = false;


    private void Start()
    {
        StartShooting();
    }

    private async void Shooting()
    {
        while (canShoot)
        {
            await UniTask.Delay(delayMS);
            bulletPool.GetBullet(units, transform.position, Quaternion.identity);
        }
    }

    public void StartShooting()
    {
        canShoot = true;
        Shooting();
    }

    public void StopShooting()=> canShoot = false;
}
