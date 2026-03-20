using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private int dashTimer = 0;

    public Vector3 mousePos;

    public float speed = 0f;

    public int health = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirZ = Input.GetAxisRaw("Vertical");

        Vector3 movementDir = new Vector3(dirX, 0, dirZ);
        rb.linearVelocity += movementDir.normalized * speed * Time.deltaTime;

        if (dashTimer<251)
        {
            dashTimer++;
        }
        if (Keyboard.current.leftShiftKey.isPressed && dashTimer>=250)
        {
            rb.AddForce(new Vector3(dirX, 0, dirZ).normalized * 25f, ForceMode.VelocityChange);
            dashTimer=0;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, transform.position);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 cursorPos = ray.GetPoint(distance);

            Vector3 direction = cursorPos - transform.position;
            direction.y = 0f;

            transform.RotateAround(transform.position, Vector3.up, Vector3.SignedAngle(transform.forward, direction, Vector3.up));
        }
    }
}
