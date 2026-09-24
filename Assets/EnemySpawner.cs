using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemySpawner : MonoBehaviour
{
    public GameObject weakenemySpawn;
    public GameObject mediumenemySpawn;
    public GameObject strongenemySpawn;
    private float timer = 0;
    private float spawnInterval = 4.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        if(timer >= 25)
        {
            Instantiate(mediumenemySpawn, transform.position, Quaternion.identity);
        }
        if(timer >= 50)
        {
            Instantiate(strongenemySpawn, transform.position, Quaternion.identity);
        }
        Instantiate(weakenemySpawn, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
}
