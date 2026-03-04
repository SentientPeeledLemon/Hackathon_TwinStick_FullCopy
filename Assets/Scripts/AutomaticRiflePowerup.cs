using UnityEngine;

public class AutomaticRiflePowerup : MonoBehaviour
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
            firingScript.damage = 30;
            firingScript.speed = 20f;
            firingScript.coolDown = 5;
            firingScript.flashToUse = powerupFlash;
            firingScript.weaponType = "Basic";
            Destroy(this.gameObject);
        }
    }
}
