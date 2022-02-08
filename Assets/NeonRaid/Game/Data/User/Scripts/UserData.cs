using System;
using UnityEngine;

public class UserData : MonoBehaviour
{
    const string maxScoreKey = "MAXSCORE";
    public event Action OnScoreChange;
    public int MaxScore { get; private set; }

    private void Start()
    {
        MaxScore = PlayerPrefs.GetInt(maxScoreKey);
    }

    public void TrySaveScore(int newScore)
    {
        if (newScore <= MaxScore)
        {
            return;
        }

        PlayerPrefs.SetInt(maxScoreKey, newScore);
        MaxScore = PlayerPrefs.GetInt(maxScoreKey);
        OnScoreChange?.Invoke();
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt(maxScoreKey, 0);
        MaxScore = PlayerPrefs.GetInt(maxScoreKey);
        OnScoreChange?.Invoke();
    }
}
