using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class ScoreView : MonoBehaviour
{
    [Inject] public GameManager GameManager { get; set; }
    [SerializeField] Text scoreText;
    [SerializeField] Button restartButton;

    void Awake()
    {
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    void OnEnable()
    {
        GameManager.OnGameOver += ShowRestart;
        GameManager.OnScoreChanged += UpdateScore;
    }
    void OnDisable()
    {
        GameManager.OnGameOver -= ShowRestart;
        GameManager.OnScoreChanged -= UpdateScore;
    }

    void UpdateScore()
    {
        scoreText.text = $"Score: {GameManager.CurrentScore}";
    }

    void ShowRestart()
    {
        restartButton.gameObject.SetActive(true);
    }

    void RestartGame()
    {
        GameManager.Restart();

        restartButton.gameObject.SetActive(false);
    }
}