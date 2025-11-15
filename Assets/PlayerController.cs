using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 0.2f;
    public float WalkSpeed = 0.2f;
    public float SprintSpeed;
    public float gravity = -9.81f;

    Vector3 velocity;
    Vector3 move;

    bool Sprint;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Inputs
        Sprint = Input.GetKey("left shift");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Camera
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        //Movement
        move = (right * h + forward * v).normalized;
        controller.Move(move * speed * Time.deltaTime);
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        sprint();
    }

   
    
    void sprint()
    {
        if (Sprint)
        {
            speed = SprintSpeed;
        }
        else
        {
            speed = WalkSpeed;
        }
    }
}

