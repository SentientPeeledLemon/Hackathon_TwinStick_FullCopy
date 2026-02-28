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
        if (Keyboard.current.leftShiftKey.isPressed && dashTimer>250)
        {
            rb.MovePosition(transform.position + new Vector3(dirX, 0, dirZ)*5f);
            dashTimer=0;
        }

        mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.y=0f;
        mousePos.z +=9;
        transform.rotation = Quaternion.LookRotation(mousePos);
    }


}
