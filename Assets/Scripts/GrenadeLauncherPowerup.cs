using UnityEngine;

public class GrenadeLauncherPowerup : MonoBehaviour
{
    private GameObject weapon;
    public GameObject powerupPrefab;
    public GameObject powerupFlash;

    private int timer;
    public int duration = 5;

    private bool isActive = false;
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
            firingScript.damage = 300;
            firingScript.speed = 10f;
            firingScript.coolDown = 40;
            firingScript.flashToUse = powerupFlash;
            firingScript.weaponType = "Grenade Launcher";

            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            isActive = true;
        }
    }

    void FixedUpdate()
    {
        if(isActive)
        {
            timer++;
            if(timer >= duration * 50)
            {
                Firing firingScript = weapon.GetComponent<Firing>();
                firingScript.prefabToUse = firingScript.defaultPrefab;
                firingScript.damage = 20;
                firingScript.speed = 20;
                firingScript.coolDown = 5;
                firingScript.flashToUse = firingScript.defaultFlash;
                firingScript.weaponType = "Basic";
                Destroy(this.gameObject);
            }
        }
    }
}
