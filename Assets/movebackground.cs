using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebackground : MonoBehaviour
{
    private CameraScroll cameraScroll;
    // Start is called before the first frame update
    void Start()
    {
        // Grab CameraScroll from the MainCamera
        cameraScroll = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScroll>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the background to the left by half of the camera's speed
        transform.position.x -= cameraScroll.scrollSpeed / 2.0 * Time.deltaTime;
    }
}
