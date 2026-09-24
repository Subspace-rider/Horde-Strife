using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; }
    public float timer = 0;
    public int killCount = 0;
    private int health = 50;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI killcountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        killcountText.text = "Enemies Killed: " + killCount.ToString("0");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(health > 0)
            {
                health--;
            } 
            UpdateTextVisual();
        }
    }
    private void UpdateTextVisual()
    {
        if(healthText != null)
        {
            healthText.text = "Health: " + health.ToString("0");
        }
        if(killcountText != null)
        {
            killcountText.text = "Enemies Killed: " + killCount.ToString("0");
        }
    }

    public void AddKill()
    {
        killCount++;
        UpdateTextVisual();
    }
    // Update is called once per frame
    void Update()
    {
        timeText.text = "Run Time: " + timer.ToString("0.00");
        killcountText.text = "Enemies Killed: " + killCount.ToString("0");
        healthText.text = "Health: " + health.ToString("0");

        timer += Time.deltaTime;

        if(health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(killCount == 100)
        {
            SceneManager.LoadScene("Win");
        }
    }

    
}
