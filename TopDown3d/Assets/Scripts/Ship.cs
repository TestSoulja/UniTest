using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed = 5f;
    public Joystick joystick;
    private float vertical;
    private float horizontal;
    //bool rotateObjectBoolr;
    //bool rotateObjectBooll;
    public float rotationspeed = 100f;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        GetKeyInput();
        GetMobileInput();

        //Делал поворот вместе с движением
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    StartCoroutine(RotateObjectl());
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.D))
        //    {
        //        StartCoroutine(RotateObjectr());
        //    }
        //    else
        //    {
        //        StartCoroutine(RotateObjectdef());
        //    }
        //}

    }

    // Управление с пк
    private void GetKeyInput()
    {
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * speed * Time.deltaTime * 2;

        float move1 = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, move1, 0) * speed * Time.deltaTime * 2;
    }

    // Поворот вместе с движением
    //IEnumerator RotateObjectr()
    //{
    //    float moveSpeed = 1000f;
    //    Quaternion endingAngle = Quaternion.Euler(new Vector3(-90, -25, 0));
    //    //while (Vector3.Distance(transform.rotation.eulerAngles, endingAngle.eulerAngles) > 0.05f)
    //    //{
    //    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, endingAngle, moveSpeed * Time.deltaTime);
    //    //    yield return null;
    //    //}
    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, endingAngle, moveSpeed * Time.deltaTime);
    //    yield return null;
    //    transform.rotation = endingAngle;
    //}
    //IEnumerator RotateObjectl()
    //{
    //    float moveSpeed = 1000f;
    //    Quaternion endingAngle = Quaternion.Euler(new Vector3(-90, 25, 0));
    //    //while (Vector3.Distance(transform.rotation.eulerAngles, endingAngle.eulerAngles) > 0.05f)
    //    //{
    //    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, endingAngle, moveSpeed * Time.deltaTime);
    //    //    yield return null;
    //    //}
    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, endingAngle, moveSpeed * Time.deltaTime);
    //    yield return null;
    //    transform.rotation = endingAngle;
    //}
    //IEnumerator RotateObjectdef()
    //{
    //    float moveSpeed = 1000f;
    //    Quaternion endingAngle = Quaternion.Euler(new Vector3(-90, 0, 0));
    //    while (Vector3.Distance(transform.rotation.eulerAngles, endingAngle.eulerAngles) > 0.05f)
    //    {
    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, endingAngle, moveSpeed * Time.deltaTime);
    //        yield return null;
    //    }
    //    transform.rotation = endingAngle;
    //}

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

