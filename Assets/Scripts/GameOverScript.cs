using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<Image>().enabled = true;
        Debug.Log("Game Over"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
