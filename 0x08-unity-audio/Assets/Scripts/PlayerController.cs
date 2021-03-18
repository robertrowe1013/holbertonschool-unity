using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement
    public CharacterController controller;
    public float speed = 15f;
    // facing
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    // gravity
    public float gravity = -18f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    bool doubleJump;
    // respawn
    public Transform spawnPoint;
    public GameObject thePlayer;
    public bool lockmove = false;
    // pause menu
    public PauseMenu pm;
    public GameObject winCanvas;
    public GameObject pauseCanvas;
    // animation
    public Animator anim;
    // audio
    public AudioSource runningGrass;
    public AudioSource runningRock;
    public AudioSource splat;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && winCanvas.activeSelf == false)
        {
            if (pm.gameIsPaused)
            {
                pm.Resume();
            }
            else
            {
                pm.Pause();
            }
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        anim.SetBool("isGrounded", isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -18f;
            doubleJump = true;
            anim.SetBool("isLanding", true);
        }
        else
        {
            anim.SetBool("isLanding", false);
        }
        float hor = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hor, 0f, vert).normalized;
        if (direction.magnitude >= 0.1f && lockmove == false)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        if (Input.GetButtonDown("Jump") && isGrounded && pauseCanvas.activeSelf == false && lockmove == false)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            anim.SetTrigger("isJumping");
        }
        if (Input.GetButtonDown("Jump") && isGrounded == false && doubleJump == true && pauseCanvas.activeSelf == false && lockmove == false)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            doubleJump = false;
            anim.SetTrigger("isDoubleJumping");
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (thePlayer.transform.position.y < -20)
        {
            anim.SetBool("isFalling", true);
            thePlayer.transform.position = spawnPoint.transform.position;
            lockmove = true;
        }
        if (direction.magnitude >= 0.1f && lockmove == false && isGrounded && runningGrass.isPlaying == false)
        {
            runningGrass.Play();
        }
    }

    void OnTriggerEnter(Collider item)
    {
        if (item.tag == "Coin")
        {
            GetComponent<Timer>().timerValue -= 5f;
            item.gameObject.SetActive(false);
        }
    }
}
