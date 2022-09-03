using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        transform.Rotate(0, 90f, 0, Space.Self);
        Debug.Log(other.name);
    }

    void OnTriggerExit(Collider other)
    {
        transform.Rotate(0, -90f, 0, Space.Self);
        
    }
}
