using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    bool num;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider names)
    {
        num = true;
        Debug.Log(num);
    }
}
