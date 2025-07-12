using UnityEngine;
using VContainer;

public class PipeController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    
    [Inject] private GameManager GameManager;
    [Inject] private GameSettings GameSettings;
    [Inject] private ObstacleSpawner ObstacleSpawner;

    public void SetColor(Color color)
    {
        foreach (var spriteRenderer in spriteRenderers)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.color = color;
            }
        }
    }

    void Update()
    {
        if (!GameManager.IsGameActive) return;
        transform.position += Vector3.left * GameSettings.ObstacleSpeed * Time.deltaTime;

        if (transform.position.x < -10)
            ObstacleSpawner.RemoveObstacle(this);
    }
}