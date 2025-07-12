using UnityEngine;

[CreateAssetMenu(menuName = "Settings/SkinSettings")]
public class SkinSettings : ScriptableObject
{
    [SerializeField]
    private Sprite[] BirdSkins;
    [SerializeField]
    private Color[] PipeColors;

    public Sprite GetBirdSkin(int index)
    {
        if (index < 0 || index >= BirdSkins.Length)
        {
            Debug.LogError("Index out of range for BirdSkins");
            return null; // Default skin or handle error appropriately
        }
        return BirdSkins[index];
    }

    public Color GetRandomPipeColor()
    {
        return PipeColors[Random.Range(0, PipeColors.Length)];
    }
    public Color GetPipeColor(int index)
    {
        if (index < 0 || index >= PipeColors.Length)
        {
            Debug.LogError("Index out of range for PipeColors");
            return Color.white; // Default color
        }
        return PipeColors[index];
    }
}