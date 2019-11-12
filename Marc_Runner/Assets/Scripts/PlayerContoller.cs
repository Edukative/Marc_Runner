using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody playerRB;

    public float jumpForce; // the force the player jumps
    public float gravityModifier; // to modify the gravity, to earth one to a lunar one!

    public bool isOnGround = true; // is on the ground
    public bool isGameOver = false; // if the player is dead

    public int hp;

    public GameObject hp1;
    private GameObject hp2;
    private GameObject hp3;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Get the Rigidbody component

        Physics.gravity *= gravityModifier; //Modify the default Unity gravity to your gravity!


        hp1 = GameObject.Find("HP 1");
        hp2 = GameObject.Find("HP 2");
        hp3 = GameObject.Find("HP 3");
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver) //if you press space and is touching the ground
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Apply a impulse force up, to make it jump
            isOnGround = false; // no longer touches de ground
        }
    }

    void LoseHP ()
    {
        hp--;
        Debug.Log(hp);
        switch (hp) //hp cases
        {
            case 2: hp3.SetActive(false); // if hp is 2
                break;
            case 1: hp2.SetActive(false); // if hp is 1
                break;
            case 0: hp1.SetActive(false); // if hp is 0
                isGameOver = true;
                break;
            default: hp3.SetActive(true); // default case that is necessary
                     hp2.SetActive(true);
                     hp1.SetActive(true);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")) // or the player collides with the ground
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle")) // or the player collides with an obstacle
        {
            LoseHP();
            Destroy(collision.gameObject);
            Debug.Log("Game Over F in the Chat");
        }
    }
}
