using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
