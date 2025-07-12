using UnityEngine;
using VContainer;

public class ObstacleMover : MonoBehaviour
{
    [Inject] private GameManager GameManager;
    [Inject] private GameSettings GameSettings;
    [Inject] private ObstacleSpawner ObstacleSpawner;

    void Update()
    {
        if (!GameManager.IsGameActive) return;
        transform.position += Vector3.left * GameSettings.ObstacleSpeed * Time.deltaTime;

        if (transform.position.x < -10)
            ObstacleSpawner.RemoveObstacle(gameObject);
    }
}