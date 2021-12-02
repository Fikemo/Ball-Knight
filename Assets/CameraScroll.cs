using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    private Transform player;
    private PlayerController playerController;
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
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Grab the PlayerController from the player
        playerController = player.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Grab velocity from characterController
        playerVelocity = playerController.velocity();

        // Get relative x difference between camera and player
        // If player is behind camera, this is negative
        // xDifference = player.transform.position.x - transform.position.x;

        // If the camera is now aligned with the camera in the y direction, record how far off alignment it is
        yDifference = Mathf.Abs(transform.position.y - player.position.y);
        // If the distance is large enough to put the player outside the deadzone
        if (yDifference >= verBoundary){
            // Move the camera toward the player in the y direction
            Vector3 yPos = new Vector3(transform.position.x, player.position.y,transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, yPos, ySpeed * Time.deltaTime);
        }
        // If the player is too far in the x direction
        if (playerVelocity > scrollSpeed && player.position.x - transform.position.x >= horBoundary){
            // Speed the camera up by the speedup factor
            scrollSpeed = playerVelocity;
        }
        // scroll on x axis
        if (scrollEnabled) transform.position += new Vector3(scrollSpeed, 0.0f, 0.0f) * Time.deltaTime;

        // follow player on y axis
        // transform.position = new Vector3(transform.position.x, follow.position.y, transform.position.z);

    }

    private void OnDrawGizmos() {
        Vector2 fromPosition = transform.position;
        fromPosition.x += horBoundary;
        fromPosition.y += 5;
        
        Vector2 toPosition = fromPosition;
        toPosition.y -= 10;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(fromPosition, toPosition);
    }
}
