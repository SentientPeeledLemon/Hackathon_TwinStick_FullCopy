using UnityEngine;

public class ExplosionChecker : MonoBehaviour
{
    private int lifeTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeTimer = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lifeTimer<=0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            lifeTimer--;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyScript enemy = other.gameObject.GetComponent<EnemyScript>();
            enemy.knockBack(transform.position, 100f);
        }else if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exploded with: " + other.gameObject.name);
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(100f, transform.position, 150f, 50f);
        }
    }
}
