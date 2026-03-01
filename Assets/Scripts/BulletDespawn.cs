using UnityEngine;

public class bulletDespawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Collided");
        if (!other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
