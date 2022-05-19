using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MoveEnem();
    }

    private void MoveEnem()
    {

        transform.Translate(Vector3.down * Time.deltaTime);

        
    }
}
