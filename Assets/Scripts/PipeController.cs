using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float randomYRange = 2f;
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (transform.position.x < -10f)
        {
            transform.position = new Vector2(10f, Random.Range(-randomYRange, randomYRange));
        }
    }
}
