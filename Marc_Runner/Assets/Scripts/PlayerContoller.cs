using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody playerRB;

    public float jumpForce; // the force the player jumps
    public float gravityModifier; // to modify the gravity, to earth one to a lunar one!

    public bool isOnGround = true; // is on the ground
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); // Get the Rigidbody component

        Physics.gravity *= gravityModifier; //Modify the default Unity gravity to your gravity!
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround) //if you press space and is touching the ground
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Apply a impulse force up, to make it jump
            isOnGround = false; // no longer touches de ground
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;   
    }
}
