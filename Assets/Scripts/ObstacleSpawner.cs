using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [Inject] private GameManager GameManager;
    [Inject] private PipePool PipePool;
    
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
        var obstacle = PipePool.CreatePipe(point.position);
        obstaclePool.Add(obstacle);
    }


    public void ResetGame()
    {
        // Удаляем старые препятствия
        foreach (var obstacle in obstaclePool)
        {
            if (obstacle != null)
            {
                PipePool.ReturnPipe(obstacle);
            }
        }
        obstaclePool.Clear();
    }
    
    public void RemoveObstacle(GameObject obstacle)
    {
        if (obstaclePool.Contains(obstacle))
        {
            obstaclePool.Remove(obstacle);
            PipePool.ReturnPipe(obstacle);
        }
    }
}