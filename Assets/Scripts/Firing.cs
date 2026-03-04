using UnityEngine;
using UnityEngine.InputSystem;

public class Firing : MonoBehaviour
{
    public float damage;
    public float speed;
    private int coolDownTimer;
    public int coolDown;
    public GameObject prefabToUse;
    public GameObject flashToUse;

    public string weaponType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coolDownTimer = 25;
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
                bulletRb.AddForce(transform.up * speed, ForceMode.Impulse);
            }else if (weaponType == "Shotgun")
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
