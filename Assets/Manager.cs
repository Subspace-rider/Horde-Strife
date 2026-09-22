using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    public float timer = 0;
    public int kills = 0;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI killcountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        killcountText.text = "Enemies Killed: " + kills.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Run Time: " + timer.ToString("0.00");

        timer += Time.deltaTime;
    }
}
