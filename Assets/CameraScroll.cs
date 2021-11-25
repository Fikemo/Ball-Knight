using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public Transform follow;
    public float scrollSpeed;
    public float trackingSpeed;
    private Vector3 moveTemp;
    public float xDifference;
    public float yDifference;
    public float horBoundary = 5;
    public float verBoundary = 3;

    public bool scrollEnabled = true;

    // Update is called once per frame
    void Update()
    {
        xDifference = follow.transform.position.x - transform.position.x;
        if (follow.transform.position.y < transform.position.y){
            yDifference = transform.position.y - follow.transform.position.y ;
        }else{
            yDifference = follow.transform.position.y - transform.position.y;
        }
        if (xDifference >= horBoundary || yDifference >= verBoundary){
            moveTemp = follow.transform.position;
            moveTemp.z = -10;
            transform.position = Vector3.MoveTowards(transform.position,moveTemp,trackingSpeed * Time.deltaTime);
        }

        // scroll on x axis
        if (scrollEnabled) transform.position += new Vector3(scrollSpeed, 0.0f, 0.0f) * Time.deltaTime;

        // follow player on y axis
        // transform.position = new Vector3(transform.position.x, follow.position.y, transform.position.z);

    }
}
