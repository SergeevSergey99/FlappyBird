using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private BirdController birdController;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            birdController.Jump();
        }
    }
}
