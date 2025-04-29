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

    // distortion variables.
    public int ShaderSize = Shader.PropertyToID("_MorphSize");
    public int ShaderMagnification = Shader.PropertyToID("_Magnification");
    public int ShaderMorphDistanceFromCenter = Shader.PropertyToID("_MorphDistanceFromCenter");
    public int ShaderXDistortion = Shader.PropertyToID("_XDistortion");
    public int ShaderYDistortion = Shader.PropertyToID("_YDistortion");

    // Outline, highlight variables.
    public int ShaderOutlinePulseAmount = Shader.PropertyToID("_OutlinePulseAmount");
    public int ShaderOutlinePulseThickness = Shader.PropertyToID("_OutlinePulseThickness");
    public int ShaderOutlinePulseSpeed = Shader.PropertyToID("_OutlinePulseSpeed");
    public int ShaderHighlightWhitener = Shader.PropertyToID("_HighlightWhitener");
    public int ShaderPulseTime = Shader.PropertyToID("_PulseTime");

}
