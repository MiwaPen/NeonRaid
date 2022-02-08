using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class EnemyScript : MonoBehaviour, IPooledObject
{
    public event Action<int> OnEnemyDestroy;
    public BulletPool bulletPool;
    [SerializeField] private float maxHeath;
    [SerializeField] private int score;
    private WeaponScript weapon;
    private float heath;
    private EnemyMovement movement;

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        weapon = GetComponentInChildren<WeaponScript>();
    }
   
    public void OnGetFromPool()
    {
        heath = maxHeath;
        movement.StartMoving();
        weapon.StartShooting();
    }

    public void ApplyDamage(float damage)
    {
        heath -= damage;
        CheckHP();
    }

    private void CheckHP()
    {
        if (heath <= 0)
        {
            weapon.StopShooting();
            gameObject.SetActive(false);
            OnEnemyDestroy?.Invoke(score);
        }
    }
}
