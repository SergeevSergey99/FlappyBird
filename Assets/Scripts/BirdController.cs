using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text scoreText;
    
    int score = 0;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
        scoreText.text = "Score: " + score;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        score++;
    }
}
