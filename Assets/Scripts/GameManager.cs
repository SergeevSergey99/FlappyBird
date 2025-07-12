using System;
using UnityEngine;
using VContainer.Unity;

public class GameManager
{
    public int CurrentScore { get; private set; }
    public bool IsGameActive { get; private set; } = false;

    public event Action OnGameOver;
    public event Action OnScoreChanged;
    public event Action OnRestart;


    public void AddScore(int value = 1)
    {
        if (!IsGameActive) return;
        CurrentScore += value;
        OnScoreChanged?.Invoke();
    }

    public void Restart()
    {
        OnRestart?.Invoke();
        CurrentScore = 0;
        OnScoreChanged?.Invoke();
        IsGameActive = true;
    }

    public void GameOver()
    {
        if (!IsGameActive) return;
        IsGameActive = false;
        OnGameOver?.Invoke();
    }
}