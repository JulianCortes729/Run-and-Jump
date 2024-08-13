
using TMPro;
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

    private TextMeshPro face;

    void Start()
    {
        isGrounded = true;       
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        face = GetComponentInChildren<TextMeshPro>();

    }

    void FixedUpdate()
    {
            Run();
    }

    public void Jump(){
        if(isGrounded){
            playerRb.AddForce(forceJump*Vector3.up,ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("isJump",true);
            animator.SetBool("isGrounded", false);
            face.text = ":o";
        } 
    }

    public void Run(){
        float movH = joystick.Horizontal;

        // Asegurarse de que el movimiento sea en la dirección deseada y con la velocidad constante
        Vector3 movement = new Vector3(movH * speed, playerRb.velocity.y, 0);
        
        // Asignar directamente la velocidad al Rigidbody
        playerRb.velocity = movement;
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJump", false);
            animator.SetBool("isGrounded", true);
            face.text = ":)";
        }
    } 

}
