using UnityEngine;

public class ShotDespawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void OnCollisionEnter(Collision other)
    {
        // Debug.Log("Collided");
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("PowerUp") 
            && !other.gameObject.CompareTag("Bullet") && !other.gameObject.CompareTag("dontCollide"))
        {
            Debug.Log(other.gameObject.name);;
            Destroy(this.gameObject);
        }
    }
}
