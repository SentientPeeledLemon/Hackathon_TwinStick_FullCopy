using UnityEngine;
using UnityEngine.InputSystem;

public class Firing : MonoBehaviour
{
    public int damage; //How much damage the shot does
    public float speed; //How fast the shot travels
    private int coolDownTimer; //A count of the iterations of FixedUpdate (the counting part of the timer)
    public int coolDown; //How many iterations of FixedUpdate have to pass before the player can fire
                         //The cool down time is equal to (50*coolDown) seconds
		                 //This is because FixedUpdate is not linked to framerate, and happens every 0.02 seconds by default
		                 //and therefore FixedUpdate happens 50 times per second
    public GameObject prefabToUse; //The prefab GameObject used to represent the shot
    public GameObject defaultPrefab; //The default representation of the shot
    public GameObject flashToUse; //The flash prefab to use when firing
    public GameObject defaultFlash; //The default flash prefab


    private GameObject player; //The player


    public string weaponType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coolDownTimer = 25; //Initializes the counter to be over the coolDown, so the player can fire immediately when they start the game
        player = GameObject.Find("TempPlayer"); //Initializes the player instance variable to be the player's GameObject
    }


    // Update is called once per frame
    void Update()
    {
        //YOUR TURN: fill out the blank for this outer if statement
        //  - If the player left clicks and cooldownTimer is more/equal to coolDown
        //Hint: Use Mouse.current.leftButton.isPressed
        if (                                                          )
        {
            if (weaponType == "Basic") //If the weaponType is the Basic one
            {
                //Creates a variable called rotation,
                // which represents the rotation of the player
                Quaternion rotation = transform.rotation;


                //YOUR TURN: make the firing code's variables
                // - reset coolDownTimer to 0, since the player just fired and shouldn't be able to fire again instantly
                // - Create a GameObject variable called bullet which = an instantiated prefab
                //      - Hint: For this purpose, instantiate prefabs with the constructor:
                //        Instantiate(GameObject prefab, transform.position, rotation)
                //        where the variable prefab is the prefab instance variable "to use"
                // - Create a GameObject variable called flash which = an instantiated prefab
                //      - Hint: Same constructor as last time! Use the flash prefab instance variable
                // - Create a Rigidbody called bulletRb, which equals the rigidbody component of bullet
                //      - Hint: use .GetComponent<Rigidbody>(); to get this component, called on bullet
                



                //YOUR TURN: add forces to make the shot move
                //  - use .AddForce()
                //  - Hint: .AddForce() has two parameters, a Vector3 and a force type
                //    for this, use transform.up * speed as the Vector
                //    and ForceMode.Impulse for the force type
                //  - call .AddForce() on the bullet's rigidbody (we made a variable for this!)

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