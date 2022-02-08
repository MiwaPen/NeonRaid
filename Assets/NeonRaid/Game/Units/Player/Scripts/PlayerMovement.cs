using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

namespace NeonRaid.GamePlay.Units.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [Inject] private RoadContainerScript roadContainer;
        [SerializeField] private float speedTime;
        private List<Transform> lines;
        private Rigidbody rigidBody;
        private int currentLine;
        private bool canMove;

        public enum MoveDirection
        {
            left,
            right
        }

        private void Start()
        {
            lines = roadContainer.lines;
            rigidBody = gameObject.GetComponent<Rigidbody>();
            currentLine = Mathf.RoundToInt(lines.Count / 2);
            rigidBody.DOMove(lines[currentLine].position, 0f);
            canMove = true;            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                TryDoMove(MoveDirection.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                TryDoMove(MoveDirection.right);
            }
        }

        public void TryDoMove(MoveDirection direction)
        {
            if (canMove == false) return;

            switch (direction)
            {
                case MoveDirection.left:
                    if (currentLine > 0)
                    {
                        currentLine--;
                        rigidBody.DORotate(new Vector3(0, 20, 0), 0.1f);
                        DoMove();
                    }
                    break;
                case MoveDirection.right:
                    if (currentLine < lines.Count-1)
                    {
                        currentLine++;
                        rigidBody.DORotate(new Vector3(0,-20,0),0.1f);
                        DoMove(); 
                    } 
                    break;
            }
        }

        private void DoMove()
        {
            canMove = false;
            rigidBody.DOMove(lines[currentLine].position, speedTime)
                            .OnComplete(() =>
                            {
                                canMove = true;
                                rigidBody.DORotate(new Vector3(0, 0, 0), 0.1f);
                               
                            });
        }
    }
}
