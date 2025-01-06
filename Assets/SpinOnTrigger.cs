using UnityEngine;

public class SpinOnTrigger : MonoBehaviour
{
    [Header("Target Object Settings")]
    [SerializeField] private GameObject targetObject; // The object that will spin

    [Header("Spin Settings")]
    [SerializeField] private Vector3 spinRotation = new Vector3(0, 360, 0); // Spin rotation (degrees per second)

    private bool isSpinning = false;
    private Coroutine spinCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (!isSpinning && targetObject != null)
        {
            spinCoroutine = StartCoroutine(SpinObject());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isSpinning && spinCoroutine != null)
        {
            StopCoroutine(spinCoroutine);
            isSpinning = false;
        }
    }

    private System.Collections.IEnumerator SpinObject()
    {
        isSpinning = true;

        while (true) 
        {
            targetObject.transform.Rotate(spinRotation * Time.deltaTime);
            yield return null;
        }
    }
}
