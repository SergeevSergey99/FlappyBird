using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BirdController birdController;
    int score = 0;
    
    public event Action<int> OnScoreChanged;
    public event Action OnGameOver;

    private void Start()
    {
        birdController.OnCollision += HandleGameOver;
        birdController.OnTrigger += HandleScoreIncrease;
    }
    private void OnDestroy()
    {
        if (birdController != null)
        {
            birdController.OnCollision -= HandleGameOver;
            birdController.OnTrigger -= HandleScoreIncrease;
        }
    }
    
    private void HandleScoreIncrease()
    {
        score++;
        OnScoreChanged?.Invoke(score);
    }

    private void HandleGameOver()
    {
        Time.timeScale = 0f;
        OnGameOver?.Invoke();
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
