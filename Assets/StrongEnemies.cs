using UnityEngine;

public class StrongEnemies : MonoBehaviour
{
    private int hitCount = 0;
    private Transform playerTransform;
    public float enemySpeed = 7f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
        {
            float step = enemySpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            hitCount++;
            if(hitCount == 5)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        if(Manager.Instance != null)
        {
            Manager.Instance.AddKill();
        }
        Destroy(gameObject);
    }
}
