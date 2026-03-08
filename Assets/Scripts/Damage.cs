using UnityEngine;

public class Damage : MonoBehaviour
{

    [SerializeField] private float damageAmount;
    
    public float ObtenerDamageAmount()
    {
        return damageAmount;
    }

}