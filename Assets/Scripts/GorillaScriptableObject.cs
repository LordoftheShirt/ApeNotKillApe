using UnityEngine;

[CreateAssetMenu(fileName = "GorillaScriptableObject", menuName = "ScriptableObjects/GorillaCotainer")]
public class GorillaScriptableObject : ScriptableObject
{
    // Sprites
    [SerializeField] public Sprite neutralSprite;
    [SerializeField] public Sprite sereneSprite;
    [SerializeField] public Sprite sadSprite;

    [SerializeField] public Sprite mouthfulSprite;
    [SerializeField] public Sprite distressedSprite;
    [SerializeField] public Sprite ragefulSprite;

    [SerializeField] public Sprite restingSprite;
    [SerializeField] public Sprite dyingSprite;
    [SerializeField] public Sprite deadSprite;


    // Shader Graph materials
    [SerializeField] public Material[] distortions;

}
