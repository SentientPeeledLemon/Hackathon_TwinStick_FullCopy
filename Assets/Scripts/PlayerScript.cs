using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;

    //dashTimer is an int, we will use it to count how much time has passed
    private int dashTimer;

    public Vector3 mousePos;

    //speed is set in the editor, which is possible since this is a public variable
    //it is simply being initialized here
    public float speed = 0f;

    public int health = 20;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb is a "rigidbody" instance variable, being initialized here to be the rigidbody on the player's GameObject


        //A rigidbody is a component which controls a object's position through physics simulation,
        //rather than having position directly and manually updated
        //Has properties such as mass, linearVelocity, position, rotation, angularVelocity, etc.

        dashTimer = 0;
    }


    //FixedUpdate runs every 0.02 seconds
    void FixedUpdate()
    {
        //float numbers are similar to "double" numbers in the usage of decimals (floating point numbers)
        //however, they use half the memory
        float dirX = Input.GetAxisRaw("Horizontal");
        //Input is Unity's class for handling player input through sources such as a keyboard
        //GetAxisRaw turns the input between, for "Horizontal", the A and D keys into a floating point number which represents the input
        //The variable name "dirX" is used to show that the input is on the X axis (horizontal, left to right)
       
        //YOUR TURN: Make the code for the W and S keys input (float variable)
        //  - If Unity 3D has 3 axes, the X axis (left to right), the Z axis (front to back), and the Y axis (up/down height)
        //    which one should be used in the variable name?
        //  - If A and D keys were "Horizontal" what axis name should be a parameter for W and S?
        


        //Vector3 is a representation of 3D vectors and points using a x, y, and z component
        //For our purposes, this is being used to represent a direction (the direction of the user input between W A S and D)
        //in the Vector3 movementDir
        Vector3 movementDir = new Vector3(dirX, 0, dirZ);
        
        //As mentioned, RigidBody's have a linearVelocity
        //by adding to the velocity of the player, we can make them move in the direction we want.
        //This is why we are adding using the movementDir variable, which represents the direction of the input
        //.normalized changes the x, y, and z components to make sure the magnitude of the Vector is 1
        //speed is a public variable we created to make the impact of the movement larger (a magnitude of 1 wouldn't be felt very much)
        //Time.deltaTime is a float value which represents the amount of seconds from the last frame to the current one.
        //since this is run every 0.02 seconds, deltaTime is quite small.
        rb.linearVelocity += movementDir.normalized * speed * Time.deltaTime;


        //QUESTION: Can you guess why we need to multiply by the time since the last frame
        // - Hint: Think about what changes if we do rb.linearVelocity += movementDir.normalized * speed; instead
        //Write your answer on this line:  


        //YOUR TURN: Make the code for a dash when left shift is pressed!
        //  - If dashTimer < 250, increase dashTimer by 1
        //  - Separately, if left shift is pressed and dashTimer >= 250
        //    do: rb.AddForce(new Vector3(dirX, 0, dirZ).normalized * 25f, ForceMode.VelocityChange);
        //    and reset dashTimer to 0;
        //Write your code below:





        //Rays are infinite lines starting at an origin point and going in a specified direction
        //Camera.main.ScreenPointToRay(Input.mousePosition); runs a ray through position of the mouse on your screen
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        //A Plane is an infinitely large, flat space in 3D space
        //Vector3.up is the default for a vector pointing directly up
        //transform.position returns the player's position
        Plane groundPlane = new Plane(Vector3.up, transform.position);


        //if the ray hits the plane
        if (groundPlane.Raycast(ray, out float distance))
        {
            //the cursor's position is the position where the ray intersects the plane
            Vector3 cursorPos = ray.GetPoint(distance);


            //This vector represents the direction from the player to the cursorPos
            Vector3 direction = cursorPos - transform.position;


            direction.y = 0f;


            transform.RotateAround(transform.position, Vector3.up, Vector3.SignedAngle(transform.forward, direction, Vector3.up));
        }
    }
}