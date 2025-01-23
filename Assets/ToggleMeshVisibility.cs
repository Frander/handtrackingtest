using UnityEngine;

public class ToggleMeshVisibility : MonoBehaviour
{
    public GameObject targetObject; // Objeto cuyo MeshRenderer se activará/desactivará.
    public float toggleInterval = 1f; // Intervalo en segundos.

    private MeshRenderer meshRenderer;
    private float timer;

    void Start()
    {
        if (targetObject != null)
        {
            meshRenderer = targetObject.GetComponent<MeshRenderer>();
        }

        if (meshRenderer == null)
        {
            Debug.LogError("El objeto objetivo no tiene un MeshRenderer asignado o no se encontró.");
        }
    }

    void Update()
    {
        if (meshRenderer == null) return;

        timer += Time.deltaTime;

        if (timer >= toggleInterval)
        {
            meshRenderer.enabled = !meshRenderer.enabled; // Alterna la visibilidad del MeshRenderer.
            timer = 0f; // Reinicia el temporizador.
        }
    }
}
