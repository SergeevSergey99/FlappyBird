using UnityEngine;
using VContainer;
using VContainer.Unity;

public class PipeFactory
{
    [Inject] private IObjectResolver Container;
    private GameObject pipePrefab;
    
    public PipeFactory(IObjectResolver resolver, GameObject pipePrefab)
    {
        Container = resolver;
        this.pipePrefab = pipePrefab;
    }

    public GameObject CreateObstacle(Vector3 position)
    {
        var obstacle = Container.Instantiate(pipePrefab, position, Quaternion.identity);
        obstacle.transform.position = position;
        return obstacle;
    }
}
