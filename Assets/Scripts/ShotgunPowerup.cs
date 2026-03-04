using UnityEngine;

public class ShotgunPowerup : MonoBehaviour
{
    private GameObject player;
    public GameObject powerupPrefab;
    public GameObject powerupFlash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Gun");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Firing playerScript = player.GetComponent<Firing>();
            playerScript.prefabToUse = powerupPrefab;
            playerScript.damage = 5f;
            playerScript.speed = 20f;
            playerScript.coolDown = 25;
            playerScript.flashToUse = powerupFlash;
            playerScript.weaponType = "Shotgun";
            Destroy(this.gameObject);
        }
    }
}
