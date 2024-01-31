using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerControl controller;

    [SerializeField] private float speed;
    private PoolScript bulletPool;
    private Rigidbody2D rb;

    private void Awake()
    {
        controller = new PlayerControl();
    }

    void Start()
    {
        controller.Enable();
        rb = GetComponent<Rigidbody2D>();

        controller.Controller.Shoot.performed += Shoot;
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 direction = new Vector2(0, controller.Controller.Move.ReadValue<float>()).normalized;
        rb.AddForce(direction * speed);
    }

    private void Shoot(InputAction.CallbackContext callback)
    {
        Debug.Log("Dispara");
    }
}
