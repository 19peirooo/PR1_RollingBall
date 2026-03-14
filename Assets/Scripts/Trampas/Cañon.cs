using System;
using System.Collections;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    [Header("Timer")] 
    [SerializeField] private float spawnDelay;

    [Header("Objeto Spawneado")] 
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private float timeToDestroy = 4f;
    [SerializeField] private float moveForce = 0.1f;
    [SerializeField] private Vector3 moveDirection = new Vector3(0f, 0f, -1f);

    private void Start()
    {
        StartCoroutine(spawn());
    }

    private IEnumerator spawn() 
    {
        while (true)
        {
            GameObject spawnedObject = Instantiate(spawnObject, transform.position, Quaternion.Euler(0, 0, 90));
            Destroy(spawnedObject, timeToDestroy);
            yield return new WaitForSeconds(spawnDelay);
        }
        
    }
}    
