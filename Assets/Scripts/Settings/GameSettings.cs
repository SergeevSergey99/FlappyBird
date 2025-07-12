using UnityEngine;

[CreateAssetMenu(menuName = "Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    [field: SerializeField] public GameObject PipePrefab { get; private set; }
    [field: SerializeField] public float Gravity { get; private set; } = -9.8f;
    [field: SerializeField] public float BirdJumpForce { get; private set; } = 5f;
    [field: SerializeField] public float ObstacleSpeed { get; private set; } = 3f;
}