using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public Transform follow;
    public float scrollSpeed;

    public bool scrollEnabled = true;

    // Update is called once per frame
    void Update()
    {
        // scroll on x axis
        if (scrollEnabled) transform.position += new Vector3(scrollSpeed, 0.0f, 0.0f) * Time.deltaTime;

        // follow player on y axis
        transform.position = new Vector3(transform.position.x, follow.position.y, transform.position.z);
    }
}
