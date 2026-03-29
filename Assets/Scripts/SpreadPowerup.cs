using UnityEngine;

public class SpreadPowerup : MonoBehaviour
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
        //Initializes the private variable to be the player's wand
        weapon = GameObject.Find("Wand");
    }


    //OnTriggerEnter is a default Unity method (which people can add their own code into)
    //it gets run if there is a collision between the colliders of two gameObjects, where at least one has their
    //collider set to be a "trigger"
    void OnTriggerEnter(Collider other)
    {
        //Since the player is tagged as "Player" in the editor, this will run when
        //the player collides with the powerup
        if (other.CompareTag("Player"))
        {
            //gets the Firing script from the player's wand
            Firing firingScript = weapon.GetComponent<Firing>();


            //YOUR TURN: Code the functionality of the powerup:
            //  - The firingScript component has public variables:
            //      - prefabToUse
            //      - damage
            //      - speed
            //      - coolDown
            //      - flashToUse
            //      - weaponType
            //  - Create a powerup with
            //      - the prefab GameObject variables in this powerup script
            //      - damage of 10
            //      - speed of 20
            //      - coolDown of 35
            //      - weaponType "Spread"
            //Write your code below:









            //stops the powerup from being rendered (visible)
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            //turns of the collider, so it can't be triggered again
            gameObject.GetComponent<Collider>().enabled = false;
            //Sets the powerup to be active (will be important in FixedUpdate)
            isActive = true;
        }
    }


    void FixedUpdate()
    {
        //YOUR TURN: Change the firing script back to normal after 5 seconds:
        //  Hint: Remember the instance variables at the top!
        //  - Use two if statements, one inside the other
        //  - if the powerup is active
        //      - if timer >= duration * 50 (which is 5 seconds,
        //        since duration is set to 5 and there are 50 iterations of fixed update in a second)
        //          - reset the firing script to
        //          - damage of 20
        //          - speed of 20
        //          - coolDown of 5
        //          - weaponType "Basic"
        //          - firingScript.defaultPrefab and firingScript.defaultFlash for the prefab/flash to use
        //      increase timer by one (inside the outer if statement)
       












    }
}