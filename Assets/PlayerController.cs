using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public CharacterController controller;
    public Transform cam;
    Animation animation;
    [SerializeField] AudioSource WalkSound;
    [SerializeField] AudioSource SprintSound;

    public float StartSpeed = 0.2f;
    public float speed = 0.2f;
    public float WalkSpeed = 0.2f;
    public float SprintSpeed;
    public float gravity = -9.81f;

    bool isMoving;

    Vector3 velocity;
    Vector3 move;

    bool Sprint;

    Coroutine fadeRoutine;
    
    [SerializeField] CinemachineCamera[] cameras;
    [SerializeField] CinemachineCamera startCamera;
    [SerializeField] CinemachineCamera normalCam;
    [SerializeField] CinemachineCamera zoomedCam;
    CinemachineCamera currentCamera;

    void Start()
    {   
        isMoving = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animation = GetComponentInChildren<Animation>();
        currentCamera = startCamera;
        SetPriorities();
    }

    void SetPriorities()
    {
        for (int i = 0; i < cameras.Length; i++)
            cameras[i].Priority = (cameras[i] == currentCamera) ? 20 : 10;
    }

    public void ChangeCamera(CinemachineCamera cam)
    {
        currentCamera = cam;
        SetPriorities();
    }

    void Update()
    {
        if(gameManager.CountDown <= 0 || gameManager.isDead)
        {
            WalkSound.Stop();
            SprintSound.Stop();
        }
        WalkSound.pitch = Random.Range(0.9f, 1.1f);
        SprintSound.pitch = Random.Range(0.9f, 1.1f);
        Sprint = Input.GetKey("left shift");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Camera Movement
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;
        forward.y = 0; right.y = 0;
        forward.Normalize(); right.Normalize();

        move = (right * h + forward * v).normalized;
        controller.Move(move * speed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isMoving = move.magnitude > 0.1f && controller.isGrounded;
        sprint();

        HandleFootstepsAndAnimation();

        if (Input.GetMouseButtonDown(1)) ChangeCamera(zoomedCam);
        if (Input.GetMouseButtonDown(0)) ChangeCamera(normalCam);
    }

    void sprint()
    {
        speed = Sprint ? SprintSpeed : WalkSpeed;
    }

    // 🔊 MAIN SOUND/ANIM LOGIC (compact & clean)
    void HandleFootstepsAndAnimation()
    {
        if (!isMoving)
        {
            animation.Stop();
            FadeTo(null, 0.3f);
            return;
        }

        // Choose correct sound & animation
        AudioSource target = Sprint ? SprintSound : WalkSound;
        string animName = Sprint ? "HeadBobbingSprint" : "HeadBobbing";

        animation.Play(animName);

        if (target.isPlaying) return;

        target.pitch = Random.Range(0.9f, 1.1f);
        FadeTo(target, 0.12f);
    }

    // 🎧 Single Crossfade Coroutine for both sounds
    void FadeTo(AudioSource target, float time)
    {
        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeRoutine(target, time));
    }

    IEnumerator FadeRoutine(AudioSource target, float time)
    {
        AudioSource[] sources = { WalkSound, SprintSound };
        float t = 0f;

        // ensure starting volumes
        foreach (var s in sources)
        {
            if (s == target) s.volume = 0f;
        }

        if (target != null && !target.isPlaying) target.Play();

        while (t < time)
        {
            t += Time.deltaTime;
            float k = t / time;

            foreach (var s in sources)
            {
                if (s == target)
                    s.volume = Mathf.Lerp(0f, 1f, k);
                else
                    s.volume = Mathf.Lerp(s.volume, 0f, k);
            }

            yield return null;
        }

        foreach (var s in sources)
        {
            if (s != target)
            {
                s.Stop();
                s.volume = 1f;
            }
        }
    }
}
