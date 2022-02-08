using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [System.Serializable]
    public class PlayerBulletPool
    {
        public BulletScript bulletPrefab;
        public int size;
    }
    [System.Serializable]
    public class EnemyBulletPool
    {
        public BulletScript bulletPrefab;
        public int size;
    }

    public PlayerBulletPool playerBullets;
    public EnemyBulletPool enemyrBullets;
    Queue<GameObject> playerPool;
    Queue<GameObject> enemyPool;
    private void Start()
    {
        playerPool = new Queue<GameObject>();

        for (int i = 0; i < playerBullets.size; i++)
        {
            GameObject obj = Instantiate(
                playerBullets.bulletPrefab.gameObject);
            obj.SetActive(false);
            playerPool.Enqueue(obj);
        }

        enemyPool = new Queue<GameObject>();

        for (int i = 0; i < enemyrBullets.size; i++)
        {
            GameObject obj = Instantiate(
                enemyrBullets.bulletPrefab.gameObject);
            obj.SetActive(false);
            enemyPool.Enqueue(obj);
        }
    }

    public GameObject GetBullet (Units units ,Vector3 newpos, Quaternion rotation)
    {
        GameObject obj = null;

        switch (units)
        {
            case Units.Player:
                obj = playerPool.Dequeue();
                BulletSetup(obj, newpos, rotation);
                playerPool.Enqueue(obj);
                break;
            case Units.Enemy:
                obj = enemyPool.Dequeue();
                BulletSetup(obj,newpos,rotation);
                enemyPool.Enqueue(obj);
                break;
        }
        return obj;
    }

    private void BulletSetup(GameObject obj, Vector3 newpos, Quaternion rotation)
    {
        obj.transform.position = newpos;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        IPooledObject objInterface;
        obj.TryGetComponent<IPooledObject>(out objInterface);
        if (objInterface != null)
        {
            objInterface.OnGetFromPool();
        }
    }
}

