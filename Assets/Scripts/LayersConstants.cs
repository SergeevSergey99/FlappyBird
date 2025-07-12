using UnityEngine;

public class LayersConstants
{
    public static int ScoreZoneLayer { get; } = LayerMask.NameToLayer("ScoreZone");
    public static int ObstacleLayer { get; } = LayerMask.NameToLayer("Obstacle");
    public static int GroundLayer { get; } = LayerMask.NameToLayer("Ground");
}
