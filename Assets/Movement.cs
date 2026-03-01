using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private int dashTimer = 0;

    float dirX;
    float dirZ;

    public Vector3 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX =0;
        dirZ =0;

        if (Keyboard.current.wKey.isPressed)
        {
            dirZ = 1f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            dirZ = -1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            dirX = 1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            dirX = -1f;
        }

        Vector3 movementDir = new Vector3(dirX, 0, dirZ);
        movementDir.Normalize();
        rb.linearVelocity +=movementDir * 100f * Time.deltaTime;
        if (rb.linearVelocity.magnitude > 10f)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * 10f;
        }
    }

    void FixedUpdate()
    {
        dashTimer++;
        if (dashTimer >= 250)
        {
            Debug.Log("Dash Ready");
        }
        if (Keyboard.current.leftShiftKey.isPressed && dashTimer>=250)
        {
            rb.MovePosition(transform.position + new Vector3(dirX, 0, dirZ)*5f);
            dashTimer=0;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane groundPlane = new Plane(Vector3.up, transform.position);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 cursorPos = ray.GetPoint(distance);

            Vector3 direction = cursorPos - transform.position;
            direction.y = 0f;

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }


}
