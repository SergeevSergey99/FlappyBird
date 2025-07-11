using UnityEngine;
using VContainer;

public class ObstacleMover : MonoBehaviour
{
    [Inject] GameManager GameManager { get; set; }
    [Inject] ObstacleSpawner ObstacleSpawner { get; set; }

    void Update()
    {
        if (!GameManager.IsGameActive) return;
        transform.position += Vector3.left * GameManager.ObstacleSpeed * Time.deltaTime;

        if (transform.position.x < -10)
            ObstacleSpawner.RemoveObstacle(gameObject);
    }
}