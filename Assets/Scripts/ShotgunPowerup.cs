using UnityEngine;

public class ShotgunPowerup : MonoBehaviour
{
    private GameObject weapon;
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
            firingScript.prefabToUse = powerupPrefab;
            firingScript.damage = 10;
            firingScript.speed = 20f;
            firingScript.coolDown = 35;
            firingScript.flashToUse = powerupFlash;
            firingScript.weaponType = "Shotgun";
            Destroy(this.gameObject);
        }
    }
}
