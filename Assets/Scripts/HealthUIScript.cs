using UnityEngine;
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
    }
}
