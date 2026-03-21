using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;

    Firing firingScript;

    public int health;

    private GameObject weapon;

    public int knockbackTimer;

    private Rigidbody rb;

    public ParticleSystem hitEffect;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        knockbackTimer = 1000;
        agent = transform.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = GameObject.Find("Gun");
        health = GameObject.Find("Arena").GetComponent<EnemySpawnerScript>().enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled){
            agent.SetDestination(player.transform.position);
        }
    }

    void FixedUpdate()
    {

    }

    public void knockBack(Vector3 explosionPos, float force)
    {
        StartCoroutine(knockBackEnumerator(explosionPos, force));
    }

    private IEnumerator knockBackEnumerator(Vector3 explosionPos, float force)
    {
        agent.enabled = false;
        agent.updatePosition = false;
        agent.updateRotation = false;

        rb.isKinematic = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddExplosionForce(force, explosionPos + Vector3.down, 150f, 1f, ForceMode.Impulse);

        yield return new WaitForSeconds(5f);

        rb.isKinematic = true;
        agent.enabled = true;
        agent.updatePosition = true;
        agent.updateRotation = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Firing firingScript = weapon.GetComponent<Firing>();
            if (!(firingScript.weaponType == "Grenade Launcher"))
            {
                health -= firingScript.damage;
                Debug.Log("Enemy hit, health is now " + health);
            }
            else
            {
                float distance = Vector3.Distance(this.transform.position, other.gameObject.transform.position);
                health -= firingScript.damage/(int)Mathf.Clamp(distance, 1f, 5f);
            }
            if (health <= 0)
            {
                Debug.Log("Enemy died");
                Destroy(this.gameObject);
            }
            Instantiate(hitEffect, gameObject.transform.position, Quaternion.identity);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerScript>().health -= 1;
            Instantiate(hitEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
