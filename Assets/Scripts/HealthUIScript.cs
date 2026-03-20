using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthUIScript : MonoBehaviour
{
    private int health;
    public Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().health;

        healthText.text = "Health: " + health;

        if(health <= 0)
        {
            GameObject.Find("GameOverBackground").GetComponent<Image>().enabled = true;
            GameObject.Find("GameOverButton").GetComponent<Image>().enabled = true;
            GameObject.Find("GameOverButtonText").GetComponent<Text>().enabled = true;
            GameObject.Find("GameOverText").GetComponent<Text>().enabled = true;

            GameObject.Find("Arena").GetComponent<EnemySpawnerScript>().enabled = false;
            GameObject.Find("Arena").GetComponent<PowerupSpawnerScript>().enabled = false;
            GameObject.Find("Gun").GetComponent<Firing>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().enabled = false;
        }
    }

    public void restartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
