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
    [System.NonSerialized] public int ShaderSize;
    [System.NonSerialized] public int ShaderMagnification;
    [System.NonSerialized] public int ShaderWaveDistanceFromCenter;
    [System.NonSerialized] public int ShaderXDistortion;
    [System.NonSerialized] public int ShaderYDistortion;

    // Outline, highlight variables.
    [System.NonSerialized] public int ShaderOutlinePulseAmount;
    [System.NonSerialized] public int ShaderOutlinePulseThickness;
    [System.NonSerialized] public int ShaderOutlinePulseSpeed;
    [System.NonSerialized] public int ShaderHighlightWhitener;
    [System.NonSerialized] public int ShaderPulseTime;

    private void OnEnable()
    {
        ShaderSize = Shader.PropertyToID("_Size");
        ShaderMagnification = Shader.PropertyToID("_Magnification");
        ShaderWaveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");
        ShaderXDistortion = Shader.PropertyToID("_XDistortion");
        ShaderYDistortion = Shader.PropertyToID("_YDistortion");

        ShaderOutlinePulseAmount = Shader.PropertyToID("_OutlinePulseAmount");
        ShaderOutlinePulseThickness = Shader.PropertyToID("_OutlinePulseThickness");
        ShaderOutlinePulseSpeed = Shader.PropertyToID("_OutlinePulseSpeed");
        ShaderHighlightWhitener = Shader.PropertyToID("_HighlightWhitener");
        ShaderPulseTime = Shader.PropertyToID("_PulseTime");

    }

}
