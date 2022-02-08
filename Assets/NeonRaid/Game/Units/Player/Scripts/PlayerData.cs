using System;
using UnityEngine;

namespace NeonRaid.GamePlay.Units.Player
{
    public class PlayerData : MonoBehaviour, IDamageable
    {
        public event Action OnHpChange;

        public float health { get; private set; }

        public void ApplyDamage(float damage)
        {
            health -= damage;
            OnHpChange?.Invoke();
        }
    }
}
