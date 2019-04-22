using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControlReworked : MonoBehaviour
{

    // Reworked Gravity code
    public float speed = 10f;
    public float jumpForce = 8f;
    public float gravity = 30f;
    public float sprintBoost = 2;
    public Vector3 moveDir = Vector3.zero;
    public Vector3 mouseWorldPosition;

    private CharacterController controller;
    static Animator anim;
    private Camera mainCamera;

    // Use this for initialization
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // reworked gravity and movement code
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            anim.SetFloat("Horizontal", moveDir.x); // grabs horizontal and sets it to x
            anim.SetFloat("Vertical", moveDir.z); // grabs vertical and sets it to z

            moveDir = transform.TransformDirection(moveDir);

            moveDir *= speed;
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsJumping", false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDir.y = jumpForce;
                anim.SetBool("IsJumping", true);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDir *= speed * sprintBoost;
                anim.SetBool("IsRunning", true);
            }
        }

        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue); //allows us to see where the mouse position is registered by the game

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}