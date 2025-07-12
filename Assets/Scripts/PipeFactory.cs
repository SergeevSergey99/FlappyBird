using UnityEngine;
using VContainer;
using VContainer.Unity;

public class PipeFactory
{
    [Inject] private IObjectResolver Container;
    private PipeController pipePrefab;
    
    public PipeFactory(IObjectResolver resolver, PipeController pipePrefab)
    {
        Container = resolver;
        this.pipePrefab = pipePrefab;
    }

    public PipeController CreateObstacle(Vector3 position)
    {
        var obstacle = Container.Instantiate(pipePrefab, position, Quaternion.identity);
        obstacle.transform.position = position;
        return obstacle;
    }
}
