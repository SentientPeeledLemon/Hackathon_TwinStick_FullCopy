using UnityEngine;

public class bulletDespawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void OnCollisionEnter(Collision other)
    {
        // Debug.Log("Collided");
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(this.gameObject);
        }
    }
}
