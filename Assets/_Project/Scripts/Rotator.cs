using UnityEngine;

/// <summary>
/// Fa ruotare l'oggetto sull'asse Y a una velocità regolabile dall'Inspector.
/// Attacca questo script all'oggetto "Core".
/// </summary>
public class Rotator : MonoBehaviour
{
    [Tooltip("Velocità di rotazione in gradi al secondo. Valori negativi invertono il senso.")]
    [SerializeField] private float rotationSpeed = 90f;

    private void Update()
    {
        // Ruota attorno all'asse Y locale, indipendente dal frame rate
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}

