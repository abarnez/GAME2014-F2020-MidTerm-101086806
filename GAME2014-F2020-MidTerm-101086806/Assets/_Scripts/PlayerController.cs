/* 
 Alexander Barnes 101086806
 GAME2014_MIDTERM_BARNES_ALEXANDER
 PLAYER CONTROLLER
 PLAYER RESPONDS TO TOUCH EVENTS, MOVING UP AND DOWN THE SCREEN AND BEING STATIC ON THE X
 FIRES BULLETS, FACING THE RIGHT
 I CHANGED THE MOVEMENT FUNCTION TO APPLY THE CHANGES TO THE Y INSTEAD OF X, AS WELL AS DOING THE BOUNARY CHECK ON THE Y INSTEAD OF X
 LAST MODIFIED 10/20/2020 ITS MY BRITHDAY TODAY C:
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float verticalBoundary;

    [Header("Player Speed")]
    public float verticalTValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

     private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Vertical") >= 0.1f) 
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.y != 0.0f)
        {
           transform.position = new Vector2(transform.position.x, (Mathf.Lerp(transform.position.y, m_touchesEnded.y, verticalTValue)));

            
        }
       
    }

    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.y >= verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundary,0.0f );
        }

        // check left bounds
        if (transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, -verticalBoundary, 0.0f);
        }

    }
}
