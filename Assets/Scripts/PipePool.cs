using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class PipePool
{
    [Inject] private PipeFactory pipeFactory;
    [Inject] private SkinSettings SkinSettings;
    
    private readonly Queue<PipeController> pipePool = new();
    
    public PipeController CreatePipe(Vector3 position)
    {
        PipeController pipe;
        if (pipePool.Count > 0)
        {
            pipe = pipePool.Dequeue();
            pipe.transform.position = position;
            pipe.gameObject.SetActive(true);
        }
        else
        {
            pipe = pipeFactory.CreateObstacle(position);
        }
        pipe.SetColor(SkinSettings.GetRandomPipeColor());
        return pipe;
    }
    public void ReturnPipe(PipeController pipe)
    {
        if (pipe != null)
        {
            pipe.gameObject.SetActive(false);
            pipePool.Enqueue(pipe);
        }
    }
}