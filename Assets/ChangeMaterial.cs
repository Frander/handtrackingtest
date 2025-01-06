using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material material1; // First material
    [SerializeField] private Material material2; // Second material

    private MeshRenderer meshRenderer; 
    private bool useMaterial1 = true; 

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Change the material when the trigger is entered
        if (meshRenderer != null)
        {
            meshRenderer.material = useMaterial1 ? material2 : material1;
            useMaterial1 = !useMaterial1; // Toggle the material
        }
    }
}
