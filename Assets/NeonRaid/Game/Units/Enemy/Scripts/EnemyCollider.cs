using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private EnemyScript enemyScript;
    private void Awake()
    {
        enemyScript = gameObject.GetComponent<EnemyScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        BulletScript bullet;
        if (other.gameObject.TryGetComponent(out bullet))
        {
            enemyScript.ApplyDamage(bullet.damage);
        }
    }
}
