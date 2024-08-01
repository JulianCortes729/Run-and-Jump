
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float forceJump = 0.5f;

    private Rigidbody playerRb;
    private bool suelo;

    void Start()
    {
        suelo = true;       
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }


    public void Jump(){
        if(suelo && Touchscreen.current.primaryTouch.press.isPressed){
            playerRb.AddForce(forceJump*Vector3.up,ForceMode.Impulse);
            suelo = false;
        }
    }

    void OnCollisionEnter() => suelo = true;

}
