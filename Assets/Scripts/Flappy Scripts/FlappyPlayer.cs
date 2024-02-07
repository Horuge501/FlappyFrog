using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlappyPlayer : MonoBehaviour
{
    private FlappyControl controller;

    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        controller = new FlappyControl();
        controller.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (controller.Flight.Jump.ReadValue<float>() == 1)
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Destroy(gameObject);
    }
}
