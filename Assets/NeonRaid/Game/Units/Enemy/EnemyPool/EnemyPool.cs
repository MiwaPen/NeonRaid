using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyPool : MonoBehaviour
{
    [Inject] DiContainer diContainer;
    [Inject] private ScoreCounter scoreCounter;
    [System.Serializable]
    public class Pool
    {
        public EnemyScript enemyPrefab;
        public int size;
    }

    public Pool enemyPool;
    Queue<GameObject> objectPool;
    private void Start()
    {
        objectPool = new Queue<GameObject>();

            for (int i = 0; i < enemyPool.size; i++)
            {
                GameObject obj = diContainer
                    .InstantiatePrefab(enemyPool.enemyPrefab.gameObject);
                obj.GetComponent<EnemyScript>().OnEnemyDestroy+=scoreCounter.UpdateScore;
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
    }

    public GameObject GetFromPool(Vector3 pos, Quaternion rotation)
    {
        if (objectPool.Count == 0)
        {
            return null;
        }
        GameObject obj = objectPool.Dequeue();
        obj.transform.position = pos;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        IPooledObject objInterface;
        obj.TryGetComponent<IPooledObject>(out objInterface);
        if (objInterface != null)
        {
            objInterface.OnGetFromPool();
        }

        objectPool.Enqueue(obj);
        return obj;
    }
}

