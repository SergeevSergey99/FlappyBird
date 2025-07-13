using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Text scoreText;

    private void Start()
    {
        SetScore(0);
        restartButton.onClick.AddListener(gameManager.RestartGame);
        gameManager.OnScoreChanged += SetScore;
        gameManager.OnGameOver += ShowGameOverPanel;
    }

    private void OnDestroy()
    {
        if (gameManager != null)
        {
            gameManager.OnScoreChanged -= SetScore;
            gameManager.OnGameOver -= ShowGameOverPanel;
        }
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    void SetScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
