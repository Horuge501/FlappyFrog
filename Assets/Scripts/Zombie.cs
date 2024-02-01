using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int maxLifes;
    [SerializeField] private float attackTimeFrequency;
    [SerializeField] private int damage;

    private Rigidbody2D rb;
    private int life;
    private bool canAttack;
    private float attackTimer;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        life = maxLifes;
        canAttack = false;
        attackTimer = attackTimeFrequency;
    }

    private void Update() {
        Attack();
    }

    void FixedUpdate() {
        Move();
    }

    private void Move() {
        if (Player.Instance != null) {
            Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;
            rb.AddForce(direction * speed);
        } else {
            rb.velocity = Vector2.zero;
        }
    }

    public void Hit(int damage, Vector2 direction, float pushForce) {
        life -= damage;

        if (life <= 0) {
            Destroy(gameObject);
        }

        Push(direction, pushForce);
    }
    private void Push(Vector2 direction, float pushForce) {
        rb.AddForce(-direction * pushForce, ForceMode2D.Impulse);
    }

    private void Attack() {
        if (canAttack) {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackTimeFrequency) {
                Player.Instance.Hit(damage);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == Player.Instance.gameObject) {
            canAttack = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject == Player.Instance.gameObject) {
            canAttack = false;
            attackTimer = attackTimeFrequency;
        }
    }
}
