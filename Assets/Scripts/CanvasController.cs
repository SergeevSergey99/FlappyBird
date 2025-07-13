using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private BirdController birdController;
    
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Text scoreText;

    private void Start()
    {
        SetScore(0);
        restartButton.onClick.AddListener(RestartGame);
        birdController.OnScoreChanged += SetScore;
        birdController.OnGameOver += ShowGameOverPanel;
    }

    private void OnDestroy()
    {
        if (birdController != null)
        {
            birdController.OnScoreChanged -= SetScore;
            birdController.OnGameOver -= ShowGameOverPanel;
        }
    }

    private void ShowGameOverPanel()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    void SetScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
    public void RestartGame()
    {
        // Reset the game state
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
