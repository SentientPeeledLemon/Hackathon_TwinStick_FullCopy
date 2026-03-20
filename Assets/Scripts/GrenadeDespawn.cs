using UnityEngine;

public class GrenadeDespawn : MonoBehaviour
{
    public GameObject flashToUse;
    public GameObject explosionCheck;
    public ParticleSystem explosionEffect;
    private int lifeTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeTimer=0;
    }

    void FixedUpdate()
    {
        if (lifeTimer >= 75)
        {
            Quaternion rotation = transform.rotation;
            GameObject flash = Instantiate(flashToUse, transform.position, rotation);
            GameObject explosionChecker = Instantiate(explosionCheck, transform.position, rotation);
            Instantiate(explosionEffect, transform.position, rotation);
            Destroy(this.gameObject);
        }
        else
        {
            lifeTimer++;
        }
    }
}
