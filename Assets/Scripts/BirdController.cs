using System;
using UnityEngine;
using VContainer;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [Inject] private GameManager GameManager;
    [Inject] private GameSettings GameSettings;
    [Inject] private SkinSettings SkinSettings;

    Vector3 startPosition;
    
    [Inject]
    public void Construct()
    {
        startPosition = transform.position;
        Physics2D.gravity = new Vector2(0, GameSettings.Gravity);
        if (spriteRenderer && SkinSettings.GetBirdSkin(0) != null)
            spriteRenderer.sprite = SkinSettings.GetBirdSkin(0);
        rb.bodyType = RigidbodyType2D.Kinematic;
        GameManager.OnRestart += OnRestart;
    }
    
    private void OnDestroy()
    {
        GameManager.OnRestart -= OnRestart;
    }
    public void Jump()
    {
        if (!GameManager.IsGameActive) return;
        rb.linearVelocity = Vector2.up * GameSettings.BirdJumpForce;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.IsGameActive) return;

        if (collision.gameObject.layer == LayersConstants.ScoreZoneLayer)
        {
            GameManager.AddScore();
        }
        else if (collision.gameObject.layer == LayersConstants.ObstacleLayer || collision.gameObject.layer == LayersConstants.GroundLayer)
        {
            GameManager.GameOver();
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic; // чтобы не падала после проигрыша
        }
    }

    void OnRestart()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // чтобы снова можно было прыгать
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
    }

    private void OnValidate()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}