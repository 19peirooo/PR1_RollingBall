using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private Camera freeCam;
    
    [Header("Movement")]
    [SerializeField] private float jumpForce = 15;
    [SerializeField] private float baseMoveForce = 40;
    [SerializeField] private float sprintMultiplier = 2;
    [SerializeField] private Transform orientation;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip jumpSfx;
    [SerializeField] private AudioClip freezeSfx;
    [SerializeField] private AudioClip shrinkSfx;
    [SerializeField] private AudioClip growSfx;
    [SerializeField] private AudioClip dmgSfx;
    
    private Rigidbody rb;
    private float hInput;
    private float vInput;
    private float moveForce;
    private Vector3 baseSize;
    private float gravMultiplier = 1f;
    
    //Variables de Estados Internos del Jugador
    private bool isSprinting = false;
    private bool isMini = false;
    private bool frozen = false;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        baseSize = transform.localScale;
    }

    private void Start()
    {
        UIManager.Instance.LivesText.SetText(GameManager.Instance.Lives.ToString());
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y);
    }
    
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        isMini =  Input.GetKey(KeyCode.LeftControl);
        moveForce = isSprinting ? baseMoveForce * sprintMultiplier : baseMoveForce;
        transform.localScale = isMini ? baseSize/2 : baseSize;
        orientation.position = transform.position;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            AudioManager.Instance.PlaySfx(shrinkSfx);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            AudioManager.Instance.PlaySfx(growSfx);
        }
        
        Jump();
        ChangeCameraOrientation();
        
    }

    void FixedUpdate()
    {
        if (frozen) return;
        Vector3 movement;
        if (freeCam)
        {
            movement = freeCam.transform.forward * vInput + freeCam.transform.right * hInput;
        }
        else
        {

            movement = orientation.right * hInput + Vector3.forward * vInput;
        }
        
        movement.y = 0f;
        rb.AddForce(movement.normalized * moveForce, ForceMode.Force);
        
    }
    
    private void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        
        if (isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce * gravMultiplier, ForceMode.Impulse);
            AudioManager.Instance.PlaySfx(jumpSfx);
        }
    }

    private void ChangeCameraOrientation()
    {
        if (vInput >= 0)
        {
            orientation.rotation = Quaternion.Euler(0, 0, 0);    
        } 
        else if (vInput == -1)
        {
            orientation.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Damage damage))
        {
            int damageAmount = damage.ObtenerDamageAmount();
            AudioManager.Instance.PlaySfx(dmgSfx);
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = GameManager.Instance.SpawnPoint;
            GameManager.Instance.TakeDamage(damageAmount);
            int newLives = GameManager.Instance.Lives;
            UIManager.Instance.LivesText.SetText(newLives.ToString());
            if (newLives <= 0)
            {
                GameManager.Instance.Defeat();
            }
        }
        else if (other.gameObject.TryGetComponent(out Portal portal))
        {
            portal.Enter();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Life life))
        {
            GameManager.Instance.Heal(life.getLives());
            UIManager.Instance.LivesText.SetText(GameManager.Instance.Lives.ToString());
        }
        else if (other.gameObject.TryGetComponent(out LowGravZone lgz))
        {
            gravMultiplier = lgz.getGravMultiplier();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LowGravZone lgz))
        {
            gravMultiplier = 1f;
        }
    }
    
    public void Freeze(float time)
    {
        AudioManager.Instance.PlaySfx(freezeSfx);
        StartCoroutine(FreezeCoroutine(time));
    }

    private IEnumerator FreezeCoroutine(float time)
    {
        frozen = true;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(time);

        frozen = false;
    }
}
