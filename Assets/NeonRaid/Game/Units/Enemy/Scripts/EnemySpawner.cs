using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject] private readonly EnemyPool enemyPool;
    [Inject] private RoadContainerScript roadContainer;
    [SerializeField] private float yOffset;
    [SerializeField] private int spawnDelayMS;
    private bool canSpawnEnemy;
    private List<Transform> lines;

    private void Awake()
    {
        lines = roadContainer.lines;
        canSpawnEnemy = true;
        Spawner();
    }

 /*   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canSpawnEnemy = !canSpawnEnemy;
            Spawner();
        }
    }*/

    public void EnableEnemySpawner()
    {
        canSpawnEnemy = true;
        Spawner();
    }

    public void DisableSpawner()
    {
        canSpawnEnemy = false;
    }
    private async void Spawner()
    {
        while (canSpawnEnemy)
        {
            await UniTask.Delay(spawnDelayMS);
            enemyPool.GetFromPool(GetRandomPos(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomPos()
    {
        var rand =new  System.Random();
        int index = rand.Next(0, lines.Count);
        Vector3 result = new Vector3(0,
            lines[index].position.y + yOffset,
            lines[index].position.z); 
        return result;
    }
}
