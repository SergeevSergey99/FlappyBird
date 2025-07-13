using System;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    
    public event Action OnCollision;
    public event Action OnTrigger;
    
    public void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision?.Invoke();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        OnTrigger?.Invoke();
    }
}
