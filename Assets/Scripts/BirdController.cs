using System;
using UnityEngine;
using VContainer;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    
    [Inject] public GameManager GameManager { get; set; }

    bool isDead = false;
    Vector3 startPosition;
    
    [Inject]
    public void Construct()
    {
        startPosition = transform.position;
        Physics2D.gravity = new Vector2(0, GameManager.Gravity);
        if (spriteRenderer && GameManager.GetBirdSkin(0) != null)
            spriteRenderer.sprite = GameManager.GetBirdSkin(0);
        rb.bodyType = RigidbodyType2D.Kinematic;
        isDead = false;
        GameManager.OnRestart += Restart;
    }
    
    private void OnDestroy()
    {
        GameManager.OnRestart -= Restart;
    }

    void Update()
    {
        if (!GameManager.IsGameActive) return;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isDead)
        {
            rb.linearVelocity = Vector2.up * GameManager.JumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.IsGameActive) return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("ScoreZone"))
        {
            GameManager.AddScore();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle") || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isDead = true;
            GameManager.GameOver();
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic; // чтобы не падала после проигрыша
        }
    }

    public void Restart()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // чтобы снова можно было прыгать
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        isDead = false;
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