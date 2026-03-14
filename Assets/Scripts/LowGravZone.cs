using System;
using UnityEngine;

public class LowGravZone : MonoBehaviour
{
    
    [SerializeField] private float gravityMultiplier = 2f;

    public float getGravMultiplier()
    {
        return  gravityMultiplier;
    }
}
