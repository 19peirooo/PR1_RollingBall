using System.Collections;
using UnityEngine;

public class ActivarDesactivar : MonoBehaviour
{
    [SerializeField] private bool ordenInverso = false;
    [SerializeField] private float delay = 1f;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    
    //SetActive: Activa y Desactiva un gameobject vacio AL COMPLETO
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer =  this.GetComponent<MeshRenderer>();
        boxCollider = this.GetComponent<BoxCollider>();
        StartCoroutine(ActivateDeactivar());
    }
    

    private IEnumerator ActivateDeactivar()
    {
        while (true)
        {
            if (ordenInverso)
            {
                meshRenderer.enabled = false;
                boxCollider.enabled = false;
                yield return new WaitForSeconds(delay);
                boxCollider.enabled = true;
                meshRenderer.enabled = true;
                yield return new WaitForSeconds(delay);
            }
            else
            {
                meshRenderer.enabled = true;
                boxCollider.enabled = true;
                yield return new WaitForSeconds(delay);
                boxCollider.enabled = false;
                meshRenderer.enabled = false;
                yield return new WaitForSeconds(delay);
            }
            
        }
    }
}
