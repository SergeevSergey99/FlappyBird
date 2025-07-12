using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class PipePool
{
    [Inject] private PipeFactory pipeFactory;
    
    private readonly Queue<GameObject> pipePool = new();
    
    public GameObject CreatePipe(Vector3 position)
    {
        GameObject pipe;
        if (pipePool.Count > 0)
        {
            pipe = pipePool.Dequeue();
            pipe.transform.position = position;
            pipe.SetActive(true);
        }
        else
        {
            pipe = pipeFactory.CreateObstacle(position);
        }
        return pipe;
    }
    public void ReturnPipe(GameObject pipe)
    {
        if (pipe != null)
        {
            pipe.SetActive(false);
            pipePool.Enqueue(pipe);
        }
    }
}