using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public AudioSource bgMusic;
    public AudioSource powerupMusic;

    public Text healthCounterText;
    public int health = 3;
    public Material powerupMaterial;

    private Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver; //used in MoveLeft script
    public ParticleSystem explosionParticle;

    //sound effects
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public ParticleSystem dirtParticle;
    //get refernce to animator
    private Animator playerAnim;

    //ammo
    public GameObject ammoPrefab;
   

    // Start is called before the first frame update
    void Start()
    {
        //get rigid body componenet(have to do this because unlike transform, not all game objects havge rigid bodies
        //<> get type of something
        playerRB = GetComponent<Rigidbody>();
        
        //change gravity of our physics
        Physics.gravity *= gravityModifier;
        

        playerAnim = GetComponent<Animator>();


        //sound
        playerAudio = GetComponent<AudioSource>();

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) 
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //impulse adds force immeiately {acceleration, impluse,velocity change,Farce}
            isOnGround = false;
            //activate jump trigger animation
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();

            //sound

            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(ammoPrefab, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z), ammoPrefab.transform.rotation);

            //sound
        }

        if (this.CompareTag("Player"))
        {
            healthCounterText.text = "Health: " + health.ToString();
        }
        else if (this.CompareTag("PlayerPowerup"))
        {
            healthCounterText.text = "INFINITY!";
        }
        


        if (health < 1)
        {
            gameOver = true;

            //Death animation
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();

            //sound
            playerAudio.PlayOneShot(crashSound, 1.0f);
            bgMusic.Stop();
            powerupMusic.Stop();
            SceneManager.LoadScene("GameOverScene");
        }

    }


    private void OnCollisionEnter(Collision collision) 
    {
        

        if (collision.gameObject.CompareTag("Ground"))// when u collide with a game object, check if its ground
        {
            isOnGround = true; //allow player to jump only if they are on ground
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle")) // when u collide with a game object, check if its ground
        {
            Debug.Log("Game Over");
            gameOver = true;

            //Death animation
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();

            //sound
            playerAudio.PlayOneShot(crashSound, 1.0f);
            bgMusic.Stop();
            powerupMusic.Stop();
            SceneManager.LoadScene("GameOverScene");


        }

    }
}
