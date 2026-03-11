using UnityEngine;

public class Pendulo : MonoBehaviour
{
    [SerializeField] private float angleComeAndBack = 30f;
    [SerializeField] private float velocity = 5f;
    
    private HingeJoint hj;
    private JointMotor motor;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hj = GetComponent<HingeJoint>();
        motor = hj.motor;
        motor.targetVelocity = velocity;
        motor.force = 50f;
        hj.motor = motor;
    }

    // Update is called once per frame
    void Update()
    {
        
        float angle = hj.angle;

        if (angle > angleComeAndBack)
        {
            motor.targetVelocity = -velocity;
        } else if (angle < -angleComeAndBack)
        {
            motor.targetVelocity = velocity;
        }
        
        hj.motor = motor;

    }
}
