using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private PipeController pipePrefab;
    [SerializeField] private float spawnInterval = 2f;
    
    private float timer;
    private void Start()
    {
        timer = spawnInterval;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnPipe();
            timer = spawnInterval;
        }
    }
    private void SpawnPipe()
    {
        float randomY = Random.Range(-2f, 2f);
        Vector2 spawnPosition = new Vector2(10f, randomY);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
