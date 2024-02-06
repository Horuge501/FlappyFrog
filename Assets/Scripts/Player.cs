using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private PlayerControl controller;

    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float timeToShoot;
    [SerializeField] private int maxLife;

    private PoolScript bulletPool;
    private Rigidbody2D rb;
    private bool canShoot;
    private float shootTimer;
    private int life;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

        controller = new PlayerControl();
        bulletPool = GameObject.Find("BulletPool").GetComponent<PoolScript>();
    }

    void Start()
    {
        canShoot = true;
        shootTimer = timeToShoot;
        life = maxLife;
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
        GameObject bullet = bulletPool.RequestObject();
        bullet.SetActive(true);
        bullet.transform.position = transform.position;
    }

    public void Hit(int damage) {
        life -= damage;
        if (life <= 0) {
            Destroy(gameObject);
        }
    }
}
