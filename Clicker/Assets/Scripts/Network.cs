using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Network.InitializeServer(5,25000, 192.168.31.22)
    }
}
