using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    private Transform player;
    private CharacterController characterController;
    private float playerVelocity;
    public float scrollSpeed;
    public float xSpeedup;
    public float ySpeed;
    private float xDifference;
    private float yDifference;
    public float horBoundary = 5;
    public float verBoundary = 3;
    public bool scrollEnabled = true;

    void Start()
    {
        // Grab the object with the tag player
        player = GameObject.FindGameObjectWithTag("Player");
        // Grab the CharacterController from the player
        characterController = player.GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Grab velocity from characterController
        playerVelocity = characterController.velocity.x;

        // Get relative x difference between camera and player
        // If player is behind camera, this is negative
        // xDifference = player.transform.position.x - transform.position.x;

        // If the camera is now aligned with the camera in the y direction, record how far off alignment it is
        yDifference = Mathf.Abs(transform.position.y - player.transform.position.y);
        // If the distance is large enough to put the player outside the deadzone
        if (yDifference >= verBoundary){
            // Move the camera toward the player in the y direction
            Vector2 yPos = new Vector2(transform.position.x, player.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, yPos, ySpeed * Time.deltaTime);
        }
        // If the player is too far in the x direction
        if (playerVelocity > scrollSpeed){
            // Speed the camera up by the speedup factor
            scrollSpeed = playerVelocity;
        }
        // scroll on x axis
        if (scrollEnabled) transform.position += new Vector3(scrollSpeed, 0.0f, 0.0f) * Time.deltaTime;

        // follow player on y axis
        // transform.position = new Vector3(transform.position.x, follow.position.y, transform.position.z);

    }
}
