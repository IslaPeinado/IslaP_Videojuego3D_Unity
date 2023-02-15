using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
public float Speed = 1.0f;

public float RotationSpeed = 1.0f;

public Animator animator;

public float JumpForce = 1f;



public Rigidbody Physicas;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Physicas = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * Speed);
        
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed * 100, 0));
        
        
        animator.SetFloat("VelX", horizontal);
        animator.SetFloat("VelY", vertical);

        
        
        if (Input.GetKey("space")){
            animator.Play("Jump");
            Physicas.AddForce(Vector3.up*JumpForce, ForceMode.Impulse);
        }
        
    }
    

}