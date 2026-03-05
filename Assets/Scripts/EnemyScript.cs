using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    Firing firingScript;

    public int health;

    private int hitCooldown = 100;
    private GameObject weapon;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = GameObject.Find("Gun");
        health = GameObject.Find("Arena").GetComponent<EnemySpawnerScript>().enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    void FixedUpdate()
    {
        if (hitCooldown<50)
        {
            hitCooldown++;
        }    
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Firing firingScript = weapon.GetComponent<Firing>();
            if (!(firingScript.weaponType == "Grenade Launcher"))
            {
                health -= firingScript.damage;
            }
            else
            {
                float distance = Vector3.Distance(this.transform.position, other.gameObject.transform.position);
                health -= firingScript.damage/(int)Mathf.Clamp(distance, 1f, 5f);;
            }
            if (health <= 0)
            {
                Debug.Log("Enemy died");
                Destroy(this.gameObject);
            }
        }
        if (other.gameObject.CompareTag("Player") && hitCooldown>=50)
        {
            hitCooldown=0;
            Debug.Log("Player hit");
        }
    }
}
