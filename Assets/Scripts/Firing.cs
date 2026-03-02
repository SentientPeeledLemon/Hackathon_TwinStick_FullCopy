using UnityEngine;
using UnityEngine.InputSystem;

public class Firing : MonoBehaviour
{
    public float damage;
    public float speed;
    private int coolDownTimer;
    public int coolDown;
    public GameObject prefabToUse;

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
                Rigidbody  bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.up * speed, ForceMode.Impulse);
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
