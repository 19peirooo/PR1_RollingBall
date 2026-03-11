using UnityEngine;

public class Damage : MonoBehaviour
{

    [SerializeField] private int damageAmount;
    
    public int ObtenerDamageAmount()
    {
        return damageAmount;
    }

}