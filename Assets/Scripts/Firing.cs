using UnityEngine;
using UnityEngine.InputSystem;

public class Firing : MonoBehaviour
{
    public int damage;
    public float speed;
    private int coolDownTimer;
    public int coolDown;
    public GameObject prefabToUse;
    public GameObject defaultPrefab;
    public GameObject flashToUse;
    public GameObject defaultFlash;

    private GameObject player;

    public string weaponType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coolDownTimer = 25;
        player = GameObject.Find("TempPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed && coolDownTimer >=coolDown)
        {
            if (weaponType == "Basic")
            {
                coolDownTimer=0;
                Quaternion rotation = transform.rotation;
                GameObject bullet = Instantiate(prefabToUse, transform.position, rotation);
                GameObject flash = Instantiate(flashToUse, transform.position, rotation);
                Rigidbody  bulletRb = bullet.GetComponent<Rigidbody>();
                if (Random.Range(0f, 1f) > 0.5)
                {
                    bulletRb.AddForce(transform.up * speed, ForceMode.Impulse);
                    //+ new Vector3(Random.Range(0f, 2f),0,Random.Range(0f, 2f))
                }
                else
                {
                    bulletRb.AddForce(transform.up * speed, ForceMode.Impulse);
                    //- new Vector3(Random.Range(0f, 2f),0,Random.Range(0f, 2f))
                }
            }
            else if (weaponType == "Spread")
            {
                coolDownTimer=0;
                Quaternion rotation = transform.rotation;
                GameObject flash = Instantiate(flashToUse, transform.position, rotation);
                for (int i = 0; i<20; i++)
                {
                    GameObject bullet = Instantiate(prefabToUse, transform.position, rotation);
                    Rigidbody  bulletRb = bullet.GetComponent<Rigidbody>();
                    if (Random.Range(0f, 1f) > 0.5)
                    {
                        bulletRb.AddForce(transform.up * speed + new Vector3(Random.Range(0f, 5f),0,Random.Range(0f, 5f)), ForceMode.Impulse);
                    }
                    else
                    {
                        bulletRb.AddForce(transform.up * speed - new Vector3(Random.Range(0f, 5f),0,Random.Range(0f, 5f)), ForceMode.Impulse);
                    }
                }
            }else if (weaponType == "PotionLauncher")
            {
                coolDownTimer=0;
                Quaternion rotation = transform.rotation;
                GameObject flash = Instantiate(flashToUse, transform.position, rotation);
                GameObject bullet = Instantiate(prefabToUse, transform.position, rotation);
                Rigidbody  bulletRb = bullet.GetComponent<Rigidbody>();

                Vector3 playerVelocity = player.GetComponent<Rigidbody>().linearVelocity;
                playerVelocity.y = 3;
                bulletRb.AddForce(transform.up * speed + playerVelocity, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        if (coolDownTimer < coolDown)
        {
            coolDownTimer++;
        }
    }
}