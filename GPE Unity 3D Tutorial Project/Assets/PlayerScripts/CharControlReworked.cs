using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharControlReworked : MonoBehaviour
{

    // Reworked Gravity code
    public float speed = 10f;
    public float jumpForce = 8f;
    public float gravity = 30f;
    public float sprintBoost = 2;
    public Vector3 moveDir = Vector3.zero;
    public Vector3 mouseWorldPosition;
    public SpawnScript spawner;

    private CharacterController controller;
    public Animator anim;
    private Camera mainCamera;

    Playerhealth pHealth;

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
        if (controller.isGrounded) // tells us if we are on the ground
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            anim.SetFloat("Horizontal", moveDir.x); // grabs horizontal and sets it to x
            anim.SetFloat("Vertical", moveDir.z); // grabs vertical and sets it to z

            moveDir = transform.TransformDirection(moveDir);

            moveDir *= speed; // standard movement code
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsJumping", false);

            if (Input.GetKeyDown(KeyCode.Space)) // jump code
            {
                moveDir.y = jumpForce;
                anim.SetBool("IsJumping", true);
                anim.SetBool("IsRunning", false);
            }

            if (Input.GetKey(KeyCode.LeftShift)) // dash code
            {
                moveDir.x *= speed * sprintBoost;
                moveDir.z *= speed * sprintBoost;
                anim.SetBool("IsRunning", true);
            }
        }
        
        // gravitational pull
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);

        // mouse controls
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition); // Grabs the mouse position through the camera
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength); // finds raylength, which is the float tracking mouse position
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue); //allows us to see where the mouse position is registered by the game

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
    private void OnDestroy()
    {
        if (spawner)
        {
            spawner.remainingLives--;
            if (spawner.remainingLives <= 0)
            {
                SceneManager.LoadScene("gameover");
            }
        }
        else
        {
            Debug.LogError("Why?");
        }
    }
}