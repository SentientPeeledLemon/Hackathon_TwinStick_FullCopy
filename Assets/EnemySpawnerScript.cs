using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnInterval = 1;
    private int spawnTimer;

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
            int rand = Random.Range(0, 4);

            switch (rand)
            {
                case 0:
                    Instantiate(enemyPrefab, new Vector3(-20, 1, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(enemyPrefab, new Vector3(50, 1, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemyPrefab, new Vector3(0, 1, 20), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(enemyPrefab, new Vector3(0, 1, -20), Quaternion.identity);
                    break;
            }

            spawnTimer = 0;
        }
    }

    void FixedUpdate()
    {
        spawnTimer++;
    }
}
