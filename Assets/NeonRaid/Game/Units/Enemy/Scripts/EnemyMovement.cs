using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float yOffset;
    private Rigidbody rigidBody;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    public void StartMoving()
    {
        rigidBody.DOKill();
        rigidBody.DOMoveY(-yOffset, time)
            .SetEase(Ease.Linear)
            .OnComplete(
            () => { this.gameObject.SetActive(false); });
    }
}
