using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver; //used in MoveLeft script

    //get refernce to animator
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        //get rigid body componenet(have to do this because unlike transform, not all game objects havge rigid bodies
        //<> get type of something
        playerRB = GetComponent<Rigidbody>();
        
        //change gravity of our physics
        Physics.gravity *= gravityModifier;

        playerAnim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //impulse adds force immeiately {acceleration, impluse,velocity change,Farce}
            isOnGround = false;
            //activate jump trigger animation
            playerAnim.SetTrigger("Jump_trig");

        }



    }


    private void OnCollisionEnter(Collision collision) 
    {
        isOnGround = true; //allow player to jump only if they are on ground

        if (collision.gameObject.CompareTag("Ground"))// when u collide with a game object, check if its ground
        {
        }
        else if (collision.gameObject.CompareTag("Obstacle")) // when u collide with a game object, check if its ground
        {

            //Death animation
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);



            Debug.Log("Game Over");
            gameOver = true;

        }

    }
}
