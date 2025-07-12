using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [Inject] private GameManager GameManager;
    [Inject] private GameSettings GameSettings;
    [Inject] private PipePool PipePool;
    
    [SerializeField] Transform[] spawnPoints;

    Coroutine _spawnCoroutine = null;
    private HashSet<PipeController> obstaclePool = new();

    private void Awake()
    {
        GameManager.OnRestart += ResetGame;
        GameManager.OnGameOver += StopSpawnCoroutine;
    }

    private void OnDestroy()
    {
        GameManager.OnRestart -= ResetGame;
        GameManager.OnGameOver -= StopSpawnCoroutine;
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(GameSettings.SpawnInterval);
            Spawn();
        }
    }
    void StopSpawnCoroutine()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
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
        StopSpawnCoroutine();
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }
    
    public void RemoveObstacle(PipeController obstacle)
    {
        if (obstaclePool.Contains(obstacle))
        {
            obstaclePool.Remove(obstacle);
            PipePool.ReturnPipe(obstacle);
        }
    }
}