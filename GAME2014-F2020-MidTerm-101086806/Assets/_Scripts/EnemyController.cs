/* 
 Alexander Barnes 101086806
 GAME2014_MIDTERM_BARNES_ALEXANDER
 ENEMY CONTROLLER
 MOVES UP AND DOWN THE SCREEN, CHANGING DIRECTION WHEN IT HITS THE EDGE
 I CHANGED THE MOVEMENT FUNCTION TO APPLY THE CHANGES TO THE Y INSTEAD OF X, AS WELL AS DOING THE BOUNARY CHECK ON THE Y INSTEAD OF X
 LAST MODIFIED 10/20/2020 ITS MY BRITHDAY TODAY C:
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.y >= verticalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
}
