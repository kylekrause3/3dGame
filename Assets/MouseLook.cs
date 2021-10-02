using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100;

    public Transform player;

    float xRotation = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //up and down looking stuff
        xRotation -= mouseY; //+= does opposite for some reason
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //restricts rotation inside of 180 degress

        //up and down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //ROTATING JUST CAMERA ALONG X AXIS
        //side to side
        player.Rotate(Vector3.up * mouseX); // v3.up is the same as Vector3(0, 1, 0), ROTATING ALONG Y AXIS

    }
}
