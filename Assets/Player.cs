using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    public CharacterController controller;

    public Vector3 velocity;
    public float speed = 12f;
    public float gravity = -9.18f;
    public float JumpHeight = 3f;

    public Transform groundCheck;
    public bool isGrounded;
    public bool isGroundedS;
    public bool isGroundedF;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask StartGroundMask;
    public LayerMask FinishGroundMask;

    public Text text;
    public Text text2;
    private bool time;
    public float Timer;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isGroundedS = Physics.CheckSphere(groundCheck.position, groundDistance, StartGroundMask);
        isGroundedF = Physics.CheckSphere(groundCheck.position, groundDistance, FinishGroundMask);

       
        //Movement of the player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            //TODO make it below equation += somehow / discuss with the team
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);


        text.text = Timer.ToString();

        if (isGroundedS)
        {
            time = true;
           // Timer += Time.deltaTime;
        }
        if (time == true)
        {
            Timer += Time.deltaTime;
        }
        if (isGroundedF)
        {
            time = false;
            Time.timeScale = 0.0f;
            text2.text = Timer.ToString("Game Completed Time: " + Mathf.Floor(Timer) );
        }

    }

   
}


