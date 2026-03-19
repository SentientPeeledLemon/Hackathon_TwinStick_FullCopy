using UnityEngine;

public class AutomaticRiflePowerup : MonoBehaviour
{
    private GameObject weapon;
    private GameObject bullet;
    public GameObject powerupPrefab;
    public GameObject powerupFlash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weapon = GameObject.Find("Gun");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Firing firingScript = weapon.GetComponent<Firing>();
            firingScript.prefabToUse.GetComponentInChildren<TrailRenderer>().startWidth = 0.5f;
            firingScript.prefabToUse.GetComponentInChildren<TrailRenderer>().endWidth = 0.5f;
            firingScript.prefabToUse.GetComponentInChildren<TrailRenderer>().time = 0.1f;
            firingScript.prefabToUse = powerupPrefab;
            firingScript.damage = 30;
            firingScript.speed = 20f;
            firingScript.coolDown = 0;
            firingScript.flashToUse = powerupFlash; 
            firingScript.weaponType = "Basic";
            Destroy(this.gameObject);
        }
    }
}
