using UnityEngine;

public class object_transforms : MonoBehaviour
{
[Header("Traslación aleatoria")]
    [Tooltip("Intervalo en segundos entre cambios de dirección")]
    public float translationInterval = 2f;
    [Tooltip("Distancia máxima por intervalo de traslación")]
    public float translationDistance = 1f;

    [Header("Rotación constante")]
    [Tooltip("Velocidad de rotación en grados/segundo por eje")]
    public Vector3 rotationSpeed = new Vector3(0f, 45f, 0f);

    [Header("Escalado oscilante")]
    [Tooltip("Amplitud del escalado oscilante")]
    public float scaleAmplitude = 0.2f;
    [Tooltip("Frecuencia del escalado oscilante")]
    public float scaleFrequency = 1f;

    private float translationTimer = 0f;
    private Vector3 translationVelocity;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
        SetRandomTranslationVelocity();
    }

    void Update()
    {
        // Traslación suave
        translationTimer += Time.deltaTime;
        if (translationTimer >= translationInterval)
        {
            translationTimer = 0f;
            SetRandomTranslationVelocity();
        }
        transform.Translate(translationVelocity * Time.deltaTime, Space.World);

        // Rotación constante
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);

        // Escalado oscilante
        float scaleFactor = 1f + scaleAmplitude * Mathf.Sin(Time.time * scaleFrequency);
        transform.localScale = originalScale * scaleFactor;
    }

    void SetRandomTranslationVelocity()
    {
        bool useX = Random.Range(0, 2) == 0;
        float randomDistance = Random.Range(-translationDistance, translationDistance);
        if (useX)
            translationVelocity = new Vector3(randomDistance / translationInterval, 0f, 0f);
        else
            translationVelocity = new Vector3(0f, randomDistance / translationInterval, 0f);
    }

}
