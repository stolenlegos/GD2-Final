using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 4f;
    private float startingSpeed;
    [SerializeField]
    private bool running; 
    private Animator animator;   
    
    Vector3 forward, right; 

    private void Start() { 
        //isometric movement
        running = false; 
        forward = Camera.main.transform.forward; 
        forward.y = 0;
        forward = Vector3.Normalize(forward); 
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
        startingSpeed = moveSpeed;  
        animator = GetComponent<Animator>(); 
    }

    private void Update () {
        //If you're holding left shift and nothing else, turn off running. Otherwise the dog plays Tokyo Drift. 
        if(Input.GetKey("left shift") && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) 
        || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))) {
            running = false; 
            moveSpeed = startingSpeed; 
        }
        //Play one bark animation. 
        if (Input.GetKey(KeyCode.F)) { 
            animator.Play("Bark"); 
        }
        //Allow doggo to sit. No reason. It's just cute. 
        if (Input.GetKeyDown(KeyCode.E)) {
            if (animator.GetBool("Sit_b")) {
                animator.SetBool("Sit_b", false);
                animator.Play("StandUp"); 
            }
            else {
                animator.SetBool("Sit_b", true);  
                animator.Play("SideDown"); 
            }
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {  
            //if you're idling, walking, or running, you may move. Prevents scoots and moving while parking or eating. 
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion")) {
                Move(); 
            }
        } else { //sets animation to idle if not moving; 
            animator.SetFloat("Speed_f", 0.0f);
        }
        //If you lift left shift outside of moving, you're running modifier is set to false. 
        if (Input.GetKeyUp("left shift")) {
            running = false; 
        }
    }

    private void Move() {
        //If you're not running, now you are.  
        if (Input.GetKey("left shift") && !running) {
            moveSpeed *= 2.5f; 
            running = true; 
            animator.SetFloat("Speed_f", 0.9f); //run forest run
        }
        //if you lift up left shift, you're not running. 
        if (Input.GetKeyUp("left shift")) {
            running = false; 
            moveSpeed = startingSpeed; 
            animator.SetFloat("Speed_f", 0.65f); //set run to walk animation
        }
        //If you're moving, and you're not running, you're walking. 
        if (!running) {
            moveSpeed = startingSpeed; 
            animator.SetFloat("Speed_f", 0.65f); //walk animation 
        }
        
        //Now Calculate Movement 
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey")); 
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey"); 
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        if (heading != Vector3.zero) {
            transform.forward = heading; 
            transform.position += rightMovement; 
            transform.position += upMovement;
        } else { //If you're not walking at all, you're not running.
            running = false; 
            animator.SetFloat("Speed_f", 0.0f);
        }
    }
}
