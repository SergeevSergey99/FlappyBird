using System;
using UnityEngine;
using VContainer.Unity;

public class GameManager
{
    readonly GameSettings gameSettings;
    readonly SkinSettings skinSettings;

    public int CurrentScore { get; private set; }
    public bool IsGameActive { get; private set; } = false;

    public event Action OnGameOver;
    public event Action OnRestart;

    public GameManager(GameSettings gameSettings, SkinSettings skinSettings)
    {
        this.gameSettings = gameSettings;
        this.skinSettings = skinSettings;
    }

    public float Gravity => gameSettings.Gravity;
    public float JumpForce => gameSettings.BirdJumpForce;
    public float ObstacleSpeed => gameSettings.ObstacleSpeed;

    public Sprite GetBirdSkin(int index) => skinSettings.BirdSkins[index];

    public void AddScore(int value = 1)
    {
        if (!IsGameActive) return;
        CurrentScore += value;
    }

    public void Restart()
    {
        OnRestart?.Invoke();
        CurrentScore = 0;
        IsGameActive = true;
    }

    public void GameOver()
    {
        if (!IsGameActive) return;
        IsGameActive = false;
        OnGameOver?.Invoke();
    }
}