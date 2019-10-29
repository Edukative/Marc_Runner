using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; // position at the 

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // put start position as it's current one (same position to avoid hardcoding)
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x -50) // if it's too much to the left
        {
            transform.position = startPos; // put the current position to the start one
        }
    }
}
