using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform leftCheck;
    [SerializeField] private Transform rightCheck;
    [SerializeField] private LayerMask ground;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float jumpHeight = 3f;

    private Vector3 velocity;
    private bool onGround;
    private bool besideWall;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = isGrounded();
        besideWall = isBesideWall();
        
        if (besideWall)
        {
            Debug.Log("Beside Wall!");
        }


        if (onGround && velocity.y < 0)
        {
            velocity.y = -1.5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && (onGround || besideWall))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1.5f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }

    private bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, ground);
    }

    private bool isBesideWall()
    {
        return Physics.CheckBox(leftCheck.position, new Vector3(1.2f, 0.5f, 1f), Quaternion.identity, ground)
            || Physics.CheckBox(rightCheck.position, new Vector3(1.2f, 0.5f, 1f), Quaternion.identity, ground);
    }
}
