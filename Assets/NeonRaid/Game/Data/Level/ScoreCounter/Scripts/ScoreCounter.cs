using System;
using UnityEngine;
using Zenject;

public class ScoreCounter : MonoBehaviour
{
    public event Action OnChangeLVLScore;
    public int Score { get; set; }
    [Inject] private UserData userData;

    public void ResetScore()
    {
        Score = 0;
    }

    public void UpdateScore(int score)
    {
        Score += score;
        Debug.Log(Score);
        OnChangeLVLScore?.Invoke();
    }
    
    public void TrySaveScore()
    {
        userData.TrySaveScore(Score);
    }
}
