
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float forceJump = 0.5f;
    [SerializeField] private float speed = 10.0f;

    private Rigidbody playerRb;
    private bool suelo;
    public Joystick joystick;

    private Animator animator;

    void Start()
    {
        suelo = true;       
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(joystick.Horizontal<0 || joystick.Horizontal>0){
            Run();
            animator.SetBool("isRun",true);
        }else{
            animator.SetBool("isRun",false);
        }
    }

    public void Jump(){
        if(suelo){
            playerRb.AddForce(forceJump*Vector3.up,ForceMode.Impulse);
            suelo = false;
        }
    }

    public void Run(){
        float movH = joystick.Horizontal*speed;
        playerRb.AddForce(movH,0,0);
    }

    void OnCollisionEnter() => suelo = true;

}
