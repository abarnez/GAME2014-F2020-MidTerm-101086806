/* 
 Alexander Barnes 101086806
 GAME2014_MIDTERM_BARNES_ALEXANDER
 BACKGROUND CONTROLLER
 SCROLLS BACKGROUND TO THE LEFT
 I CHANGED THE MOVEMENT FUNCTION TO APPLY THE CHANGES TO THE X INSTEAD OF Y, AS WELL AS DOING THE BOUNARY CHECK ON THE X INSTEAD OF Y
 LAST MODIFIED 10/20/2020 ITS MY BRITHDAY TODAY C:
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3(verticalBoundary, 0.0f);
    }

    private void _Move()
    {
        transform.position -= new Vector3(verticalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -verticalBoundary)
        {
            _Reset();
        }
    }
}
