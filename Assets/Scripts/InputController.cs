using UnityEngine;
using VContainer;
using VContainer.Unity;

public class InputController : ITickable
{
    [Inject] private BirdController birdController;

    public void Tick()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            birdController.Jump();
        }
    }
}