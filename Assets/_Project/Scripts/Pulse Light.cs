using UnityEngine;

/// <summary>
/// Fa pulsare l'intensità dell'emissione di un materiale URP Lit con un'onda sinusoidale.
/// Attacca lo script all'oggetto con il Renderer del cristallo (es. "Mesh"),
/// oppure assegna il Renderer a mano.
/// </summary>
public class PulseLight : MonoBehaviour
{
    private static readonly int EmissionColorId = Shader.PropertyToID("_EmissionColor");

    [Header("Target")]
    [Tooltip("Renderer del cristallo. Se vuoto viene cercato su questo oggetto o nei figli.")]
    [SerializeField] private Renderer targetRenderer;

    [Tooltip("Indice del materiale da animare (se il renderer ne ha più di uno).")]
    [SerializeField] private int materialIndex = 0;

    [Header("Emissione")]
    [Tooltip("Colore base dell'emissione. Usa il selettore HDR; il suo valore viene moltiplicato per l'intensità.")]
    [ColorUsage(false, false)]
    [SerializeField] private Color emissionColor = Color.cyan;

    [Tooltip("Intensità nel punto 'spento' dell'onda.")]
    [Min(0f)]
    [SerializeField] private float minIntensity = 0.5f;

    [Tooltip("Intensità nel punto 'acceso' dell'onda.")]
    [Min(0f)]
    [SerializeField] private float maxIntensity = 3f;

    [Header("Animazione")]
    [Tooltip("Pulsazioni al secondo (Hz). 0.5 = un ciclo ogni 2 secondi.")]
    [Min(0f)]
    [SerializeField] private float frequency = 0.5f;

    [Tooltip("Sfasamento iniziale del ciclo, da 0 a 1. Utile per desincronizzare più cristalli.")]
    [Range(0f, 1f)]
    [SerializeField] private float phaseOffset = 0f;

    [Tooltip("Se attivo, usa il tempo non scalato (continua a pulsare anche con Time.timeScale = 0).")]
    [SerializeField] private bool useUnscaledTime = false;

    private Material materialInstance;

    private void Awake()
    {
        if (targetRenderer == null)
            targetRenderer = GetComponentInChildren<Renderer>();

        if (targetRenderer == null)
        {
            Debug.LogWarning($"{nameof(PulseLight)}: nessun Renderer trovato su {name}.", this);
            enabled = false;
            return;
        }

        // .materials restituisce istanze: non modifichiamo l'asset condiviso.
        Material[] mats = targetRenderer.materials;
        materialIndex = Mathf.Clamp(materialIndex, 0, mats.Length - 1);
        materialInstance = mats[materialIndex];

        // Necessario perché l'emissione di URP Lit venga renderizzata.
        materialInstance.EnableKeyword("_EMISSION");
        materialInstance.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
    }

    private void Update()
    {
        float t = (useUnscaledTime ? Time.unscaledTime : Time.time) * frequency + phaseOffset;

        // Seno normalizzato da [-1, 1] a [0, 1]
        float wave = Mathf.Sin(t * Mathf.PI * 2f) * 0.5f + 0.5f;
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, wave);

        // Emissione HDR: colore in spazio lineare moltiplicato per l'intensità.
        materialInstance.SetColor(EmissionColorId, emissionColor.linear * intensity);
    }

    private void OnDestroy()
    {
        if (materialInstance != null)
            Destroy(materialInstance);
    }

    private void OnValidate()
    {
        if (maxIntensity < minIntensity)
            maxIntensity = minIntensity;
    }
}