using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float pushForce;
    [SerializeField] private int damage;

    void Start() {

    }

    void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            Vector2 direction = (Player.Instance.transform.position - collision.transform.position).normalized;
            collision.GetComponent<Zombie>().Hit(damage, direction, pushForce);
            Destroy(gameObject);
        }
    }
}
