using UnityEngine;

[CreateAssetMenu(menuName = "Settings/SkinSettings")]
public class SkinSettings : ScriptableObject
{
    [SerializeField]
    private Sprite[] BirdSkins;
    [SerializeField]
    private Sprite[] ObstacleSkins;
    public Sprite GetBirdSkin(int index) => BirdSkins[index];
}