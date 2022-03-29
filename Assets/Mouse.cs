using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    public float mouseSensitivity = 400f;

    public Transform playerBody;
    private bool init = false;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //xRotation = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        //xRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // rotation of the player with the mouse position
        if (Input.GetMouseButtonDown(0))
        {
            init = true;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        if (init)
        {
            xRotation -= mouseY;
        }

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localEulerAngles = new Vector3(xRotation, transform.localRotation.y, transform.localRotation.z);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
