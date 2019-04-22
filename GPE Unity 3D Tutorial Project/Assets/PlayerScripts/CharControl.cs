using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{

    //static Animator anim;
    //public float inputDelay = 0.1f;
    //public float forwardVel = 12;
    //public float rotateVel = 100;
    //public float dashMultiplier = 2;

    //private float verticalVelocity;
    //private float gravity = 14.0f;
    //private float jumpForce = 10.0f;

    //Quaternion targetRotation;
    //Rigidbody rBody;
    //float forwardInput, turnInput;

    // Use this for initialization
//    void Start()
//    {
//        anim = GetComponent<Animator>(); //
//        targetRotation = transform.rotation;
//        if (GetComponent<Rigidbody>())
//        {
//            rBody = GetComponent<Rigidbody>();
//        }
//        else
//        {
//            Debug.LogError("Character Rigidbody was not detected.");
//        }
//        forwardInput = turnInput = 0;
//    }

//    Update is called once per frame
//    void Update()
//    {
//        GetInput(); //obtains input from wasd to move character
//        Turn();
//        PlayerMovement();
//        Jump();


//    }

//    void GetInput()
//    {
//        forwardInput = Input.GetAxis("Vertical");
//        turnInput = Input.GetAxis("Horizontal");
//    }

//    void PlayerMovement()
//    {
//        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//        anim.SetFloat("Horizontal", movement.x); // grabs horizontal and sets it to x
//        anim.SetFloat("Vertical", movement.z); // does the same for vertical
//    }

//    void FixedUpdate()
//    {
//        Run();
//    }

//    void Run()
//    {
//        if (Mathf.Abs(forwardInput) > inputDelay)
//        {
//            move

//            rBody.velocity = transform.forward * forwardInput * forwardVel;
//            anim.SetTrigger("IsRunning");
//            anim.ResetTrigger("IsIdle");
//            if (Input.GetKey(KeyCode.LeftShift))
//            {
//                anim.SetBool("IsRunning", true);
//                rBody.velocity = transform.forward * forwardInput * forwardVel * dashMultiplier;

//                Debug.Log("Left shift registered.");
//            }

//        }


//        else
//        {
//            rBody.velocity = Vector3.zero;
//            anim.SetBool("IsRunning", false);

//            anim.SetTrigger("IsIdle");
//            anim.ResetTrigger("IsRunning");
//        }
//    }

//    void Turn()
//    {
//        if (Mathf.Abs(turnInput) > inputDelay)
//        {
//            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
//            transform.rotation = targetRotation;
//        }
//    }

//    void Jump()
//    {
//        if (rBody.isGrounded)
//        {
//            verticalVelocity = -gravity * Time.deltaTime;
//            if (Input.GetKeyDown(KeyCode.Space))
//            {
//                verticalVelocity = jumpForce;
//                Debug.Log("Space Input Detected.");
//            }
//            else
//            {
//                verticalVelocity -= gravity * Time.deltaTime;
//            }

//            Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
//            controller.Move(moveVector * Time.deltaTime);
//        }
//    }
}
