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
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    bool doubleJump;
    // respawn
    public Transform spawnPoint;
    public GameObject thePlayer;
    // pause menu
    public PauseMenu pm;
    public GameObject winCanvas;
    public GameObject pauseCanvas;

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
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -18f;
            doubleJump = true;
        }
        float hor = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hor, 0f, vert).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && isGrounded && pauseCanvas.activeSelf == false)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetButtonDown("Jump") && isGrounded == false && doubleJump == true && pauseCanvas.activeSelf == false)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            doubleJump = false;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (groundCheck.position.y < -20)
        {
            thePlayer.transform.position = spawnPoint.transform.position;
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
