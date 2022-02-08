using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    [SerializeField] private int maxFrameRate;
    private void Start()
    {
        Application.targetFrameRate = maxFrameRate;
    }

}
