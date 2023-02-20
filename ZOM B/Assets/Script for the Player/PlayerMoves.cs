using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float KBF = 50; //KnockbackForce
    Rigidbody rb1;
    public Vector3 moveDirectionPush;

    Vector3 velocity;
    bool isGrounded;




    private void Start()
    {
        rb1 = GetComponent<Rigidbody>();


    }

    void OnTriggerEnter(Collider Collision)
    {
        if (Collision.gameObject.tag == "Base_Enemy")
        {
            Debug.Log("Player Hit");
            Rigidbody rb1 = gameObject.GetComponent<Rigidbody>();

            if (rb1 != null)
            {
                velocity = rb1.transform.position - gameObject.transform.position;
                moveDirectionPush = Collision.transform.position - rb1.transform.position;
                rb1.AddForce(velocity.normalized * -500f);

            }


        }
    }


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


    }

}
