using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed = 5f;
    public Joystick joystick;
    private float vertical;
    private float horizontal;
    public Transform BlockyShip_Fihter_;


    void Start()
    {

    }

    void FixedUpdate()
    {
        GetKeyInput();
        GetMobileInput();

    }

    // Управление с пк

    private void GetKeyInput()
    {
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * speed * Time.deltaTime * 2;

        float move1 = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, move1, 0) * speed * Time.deltaTime * 2;
    }

    // Управление с мобилки

    private void GetMobileInput()
    {
        vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;

        //Движение вверх
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
        //Движение вниз
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
        //Движение влево
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
        //Движение вправо
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