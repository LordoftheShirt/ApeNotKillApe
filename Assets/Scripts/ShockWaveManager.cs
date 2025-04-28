using System.Collections;
using UnityEngine;

public class ShockWaveManager : MonoBehaviour
{
    [SerializeField] private float shockWaveTime = 0.75f;

    [SerializeField] private float startPosition = -0.1f;

    [SerializeField] protected float endPosition = 5;

    private Coroutine shockWaveCoroutine;

    private Material material;

    private int waveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }


    private void OnEnable()
    {
        CallShockWave();
    }

    public void CallShockWave()
    {
        shockWaveCoroutine = StartCoroutine(ShockWaveAction(startPosition, endPosition));
    }

    private IEnumerator ShockWaveAction(float startPos, float endPos)
    {
        material.SetFloat(waveDistanceFromCenter, startPos);

        float lerpedAmount = 0f;

        float elapsedTime = 0f;

        while (elapsedTime < shockWaveTime)
        {
            elapsedTime += Time.deltaTime;

            lerpedAmount = Mathf.Lerp(startPos, endPos, (elapsedTime / shockWaveTime));
            material.SetFloat(waveDistanceFromCenter, lerpedAmount);
            //print(material.GetFloat(waveDistanceFromCenter));


            yield return null;
        }
        print("destroy");
        Destroy(gameObject);
    }
}
