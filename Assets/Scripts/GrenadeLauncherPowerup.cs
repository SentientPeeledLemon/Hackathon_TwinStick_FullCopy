using UnityEngine;

public class GrenadeLauncherPowerup : MonoBehaviour
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
            firingScript.damage = 150;
            firingScript.speed = 10f;
            firingScript.coolDown = 40;
            firingScript.flashToUse = powerupFlash;
            firingScript.weaponType = "Grenade Launcher";
            Destroy(this.gameObject);
        }
    }
}
