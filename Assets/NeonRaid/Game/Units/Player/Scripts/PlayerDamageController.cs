using UnityEngine;

namespace NeonRaid.GamePlay.Units.Player
{
    [RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
    public class PlayerDamageController : MonoBehaviour 
    {
        private PlayerData playerData;
        private void Start()
        {
            gameObject.TryGetComponent<PlayerData>(out playerData);
        }

        private void OnTriggerEnter(Collider other)
        {  
            float damage = 0;
            playerData.ApplyDamage(damage); 
        }
    }
}
