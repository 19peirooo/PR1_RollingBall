using System;
using System.Collections;
using UnityEngine;

public class LavaPlatform : MonoBehaviour
{

    private Vector3 basePos;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    

    private void Awake()
    {
        basePos = transform.position;
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Player player)) StartCoroutine(sinkPlatform());
    }

    private IEnumerator sinkPlatform()
    {
        
        yield return new WaitForSeconds(1.5f);

        meshRenderer.enabled = false;
        meshCollider.enabled = false;
        
        yield return new WaitForSeconds(3f);
        meshRenderer.enabled = true;
        meshCollider.enabled = true;
        
    }
    
}
