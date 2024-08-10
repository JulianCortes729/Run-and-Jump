
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float forceJump = 0.5f;
    [SerializeField] private float speed = 10.0f;
    private Rigidbody playerRb;
    private bool isGrounded;
    public Joystick joystick;
    private Animator animator;
    void Start()
    {
        isGrounded = true;       
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            Run();
    }

    public void Jump(){
        if(isGrounded){
            playerRb.AddForce(forceJump*Vector3.up,ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("isJump",true);
            animator.SetBool("isGrounded", false);
        } 
    }

    public void Run(){
        float movH = joystick.Horizontal;
        playerRb.AddForce(movH*speed,0,0, ForceMode.Acceleration);

        if (Mathf.Abs(movH) > 0.1f)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJump", false);
            animator.SetBool("isGrounded", true);
        }
    } 

}
