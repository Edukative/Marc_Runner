using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;

    public float jumpForce; // the force the player jumps
    public float gravityModifier; // to modify the gravity, to earth one to a lunar one!

    public bool isOnGround = true; // is on the ground
    public bool isGameOver = false; // if the player is dead

    public int hp;

    private SpriteRenderer hp1;
    private SpriteRenderer hp2;
    private SpriteRenderer hp3;

    // Particles

    public ParticleSystem explosion; // the explosion Particle
    public ParticleSystem dirt; // the dirt particle when the player runs

    // Sounds

    private AudioSource playerAudio;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Get the Rigidbody component
        playerAnim = GetComponent<Animator>(); // Get the Animator component
        playerAudio = GetComponent<AudioSource>(); // Get the AudioSource component

        Physics.gravity *= gravityModifier; //Modify the default Unity gravity to your gravity!

        GameObject canvas = GameObject.Find("Canvas");
        hp1 = GameObject.Find("HP1").GetComponent<SpriteRenderer>();
        hp2 = GameObject.Find("HP2").GetComponent<SpriteRenderer>();
        hp3 = GameObject.Find("HP3").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver) //if you press space and is touching the ground
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Apply a impulse force up, to make it jump
            isOnGround = false; // no longer touches de ground

            // Animations
            playerAnim.SetTrigger("Jump_trig");

            // Particles
            dirt.Stop(); // stop playing the particle

            // Sounds
            playerAudio.PlayOneShot(jumpSound);
        }
    }

    void LoseHP ()
    {
        hp--;
        Debug.Log(hp);
        switch (hp) //hp cases
        {
            case 2: hp3.gameObject.SetActive(false); // if hp is 2
                break;
            case 1: hp2.gameObject.SetActive(false); // if hp is 1
                break;
            case 0: hp1.gameObject.SetActive(false); // if hp is 0
                isGameOver = true;
               
                // Animations
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
               
                // Particles
                explosion.Play(); // Play the explosion particle
                dirt.Stop(); // stop playing the particle

                // Sounds
                playerAudio.PlayOneShot(crashSound);

                break;
            default: hp3.gameObject.SetActive(true); // default case that is necessary
                     hp2.gameObject.SetActive(true);
                     hp1.gameObject.SetActive(true);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")) // or the player collides with the ground
        {
            isOnGround = true;
            dirt.Play(); // play again the particle
        }
        else if (collision.gameObject.CompareTag("Obstacle")) // or the player collides with an obstacle
        {
            LoseHP();
            Destroy(collision.gameObject);
            Debug.Log("Game Over F in the Chat");
        }
    }
}
