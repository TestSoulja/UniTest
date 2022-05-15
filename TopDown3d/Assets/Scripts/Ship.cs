using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed = 1f;
    public Joystick joystick;
    private float vertical;
    private float horizontal;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        GetKeyInput();
        GetMobileInput();

    }


    private void GetKeyInput()
    {
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * speed * Time.deltaTime;

        float move1 = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, move1, 0) * speed * Time.deltaTime;
    }

    private void GetMobileInput()
    {
        vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;

        if (vertical >= 0.1)
        {
            if (vertical >= 0.5)
            {
                transform.position += new Vector3(0, 2, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
            }
        }
        if (vertical <= -0.1)
        {
            if (vertical <= -0.5)
            {
                transform.position += new Vector3(0, -2, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
            }
        }
        if (horizontal <= -0.1)
        {
            if (horizontal <= -0.5)
            {
                transform.position += new Vector3(-2, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
        }
        if (horizontal >= 0.1)
        {
            if (horizontal >= 0.5)
            {
                transform.position += new Vector3(2, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
            
        }
    }
}
