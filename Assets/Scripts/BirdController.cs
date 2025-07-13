using System;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    
    public event Action<int> OnScoreChanged;
    public event Action OnGameOver;
    
    int score = 0;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        OnGameOver?.Invoke();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        OnScoreChanged?.Invoke(score);
    }
}
