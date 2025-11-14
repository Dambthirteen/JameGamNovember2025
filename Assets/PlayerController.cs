using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Classes
    CharacterController characterController;

    //
    Vector3 move;

    //Settings
    public float Speed;
    public float SprintSpeed = 1;
    public float JumpHeight;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        characterController.Move(move * Speed * SprintSpeed);
    }
}
