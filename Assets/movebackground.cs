using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebackground : MonoBehaviour
{
    private CameraScroll cameraScroll;
    public float parallaxFactor;
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
        transform.position = new Vector2(transform.position.x - cameraScroll.scrollSpeed / parallaxFactor * Time.deltaTime, transform.position.y);
    }
}
