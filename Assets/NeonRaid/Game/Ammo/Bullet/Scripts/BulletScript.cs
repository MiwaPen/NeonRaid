using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class BulletScript : MonoBehaviour, IPooledObject
{
    public float damage;
    [SerializeField] private BulletDirection direction;
    [SerializeField] private float time;
    [SerializeField] private float yOffset;
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    public void OnGetFromPool()
    {
        rigidBody.DOKill();
        
        switch (direction)
        {
            case BulletDirection.UP:
                rigidBody.DOMoveY(yOffset, time)
                    .From(rigidBody.transform.position);
                break;
            case BulletDirection.DOWN:
                rigidBody.DOMoveY(-yOffset, time)
                    .From(rigidBody.transform.position); ;
                break;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            rigidBody.DOKill();
            gameObject.SetActive(false);
        }   
    }
}
