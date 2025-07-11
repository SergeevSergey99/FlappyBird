using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [Inject] public GameManager GameManager { get; set; }
    [Inject] public IObjectResolver Container { get; set; }
    
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnInterval = 2f;

    float timer;
    private HashSet<GameObject> obstaclePool = new();

    private void Awake()
    {
        GameManager.OnRestart += ResetGame;
    }

    private void OnDestroy()
    {
        GameManager.OnRestart -= ResetGame;
    }

    void Update()
    {
        if (!GameManager.IsGameActive)
            return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        var point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        var obstacle = Container.Instantiate(obstaclePrefab, point.position, Quaternion.identity, transform);
        obstaclePool.Add(obstacle);
    }


    public void ResetGame()
    {
        // Удаляем старые препятствия
        foreach (var obstacle in obstaclePool)
        {
            if (obstacle != null)
            {
                Destroy(obstacle);
            }
        }
        obstaclePool.Clear();
    }
    
    public void RemoveObstacle(GameObject obstacle)
    {
        if (obstaclePool.Contains(obstacle))
        {
            obstaclePool.Remove(obstacle);
            Destroy(obstacle);
        }
    }
}