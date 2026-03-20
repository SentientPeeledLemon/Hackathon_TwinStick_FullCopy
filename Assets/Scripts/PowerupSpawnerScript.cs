using Unity.VisualScripting;
using UnityEngine;

public class PowerupSpawnerScript : MonoBehaviour
{
    public GameObject fullerAutoPrefab;
    public GameObject shotgunPrefab;
    public GameObject poisonPrefab;

    public int spawnInterval = 10;
    private int spawnTimer;

    private bool exists = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //note that the default tick rate for fixed update is 50 ticks per second
        //go to project settings -> time to change this (first number)
        if(spawnInterval * 50 <= spawnTimer)
        {
            int rand = Random.Range(0, 3);

            switch (rand)
            {
                case 0:
                    Instantiate(fullerAutoPrefab, new Vector3(19, 0.75f, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(shotgunPrefab, new Vector3(19, 0.75f, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(poisonPrefab, new Vector3(19, 0.75f, 0), Quaternion.identity);
                    break;
            }

            spawnTimer = 0;
        }
    }

    void FixedUpdate()
    {
        if(GameObject.FindGameObjectsWithTag("PowerUp").Length != 0)
        {
            exists = true;
        }
        else
        {
            exists = false;
        }
        
        if(!exists)
        {
            spawnTimer++;
        }
    }
}
