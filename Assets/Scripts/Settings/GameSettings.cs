using UnityEngine;

[CreateAssetMenu(menuName = "Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    public float Gravity = -9.8f;
    public float BirdJumpForce = 5f;
    public float ObstacleSpeed = 3f;
}