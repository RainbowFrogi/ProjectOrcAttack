using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    float speedAtStart;
    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;
    float x;
    float z;

    [Header ("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float  groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;


    Vector3 velocity;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        speedAtStart = speed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        CheckInput();

        MovePlayer();

    }

    void CheckInput()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    void MovePlayer()
    {
        Vector3 move = transform.right * x + transform.forward * z;
        if (z != 0 && x != 0)
        {
            speed = speedAtStart / 1.3f;
        }
        else speed = speedAtStart;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
