using UnityEngine;

public class LifeCycleLogger : MonoBehaviour
{
    //Awake è eseguito alla prima attivazione in scena
    private void Awake()
    {
        Debug.Log($"Eseguo Awake {gameObject.name}");
    }

    //OnEnable è eseguito a ogni riattivazione dell'oggetto
    private void OnEnable()
    {
        Debug.Log($"Eseguo OnEable {gameObject.name}");
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"Eseguo Start {gameObject.name}");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Eseguo Update {gameObject.name}");
    }

    private void FixedUpdate()
    {
        Debug.Log($"Eseguo FixedUpdate {gameObject.name}");
    }

    private void LateUpdate()
    {
        Debug.Log($"Eseguo LateUpdate {gameObject.name}");
    }

    private void OnDisable()
    {
        Debug.Log($"Eseguo OnDisable {gameObject.name}");
    }

    private void OnDestroy()
    {
        Debug.Log($"Eseguo OnDestroy {gameObject.name}");
    }
}
