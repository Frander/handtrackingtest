using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeMaterial : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private GameObject KitGuide;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject c1; // First material
    [SerializeField] private GameObject c2; // Second material
    [SerializeField] private GameObject c3; // Second material
    [SerializeField] private Text text; // Second material

    [SerializeField] private GameObject c1v; // First material
    [SerializeField] private GameObject c2v; // Second material
    [SerializeField] private GameObject c3v; // Second material



    int count = 0;
    private MeshRenderer meshRenderer; 
    private bool useMaterial1 = true; 

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(count == 0) KitGuide.SetActive(false);

        if(count == 0){
            timer.enabled = true;
            text.text = "Componente #1";
            c1.SetActive(true);
            c2.SetActive(false);
            c3.SetActive(false);

            c1v.SetActive(true);
            c2v.SetActive(false);
            c3v.SetActive(false);
            count++;
            StartCoroutine(DeactivateForSeconds(3));

            return;
        }
        if(count == 1){
            text.text = "Componente #2";
            c1.SetActive(false);
            c2.SetActive(true);
            c3.SetActive(false);

            c1v.SetActive(false);
            c2v.SetActive(true);
            c3v.SetActive(false);
            count++;
            StartCoroutine(DeactivateForSeconds(3));

            return;
        }
        if(count == 2){
            text.text = "Componente #3";
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(true);
            
            c1v.SetActive(false);
            c2v.SetActive(false);
            c3v.SetActive(true);
            count++;
            StartCoroutine(DeactivateForSeconds(3));

            return;
        }

        if(count > 2){
            text.text = "Proceso Finalizado";
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            
            c1v.SetActive(false);
            c2v.SetActive(false);
            c3v.SetActive(false);
            count++;
            StartCoroutine(DeactivateForSeconds(1000));

            return;
        }
    }

    private IEnumerator DeactivateForSeconds(float seconds)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(seconds);
gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
