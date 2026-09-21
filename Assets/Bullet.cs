using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    private float lifetime = 3f;
    private Rigidbody2D bulletRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.linearVelocity = transform.right * speed;

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
