using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private PlayerContoller playerControllerScript;
    private float leftBound = -15; // the limits of the game
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerContoller>();
        // find the player in the scene by it's name and retrieve its script
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.isGameOver) // if it's not GameOver
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // if the obstacle is beyond the limits of the game
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
