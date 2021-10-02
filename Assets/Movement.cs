using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpheight = 3f;

    public Transform groundCheck;
    public float groundCheckSphereSize = .4f;
    public LayerMask groundMask;

    public GameObject Player;
    public GameObject Spawn;

    Vector3 velocity;
    bool grounded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y <= -50f) Death();
        else movement();
    }

    void Death()
    {
        velocity.y = -1f;
        transform.position = Spawn.transform.position;
        //transform.position = new Vector3(0f, 1f, 0f) ALSO WORKS, I want spawn in map so that i can send other stuff there easily
    }

    void movement()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundCheckSphereSize, groundMask);

        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //sprint
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = 18f;
        }
        else
        {
            speed = 12f;
        }

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
