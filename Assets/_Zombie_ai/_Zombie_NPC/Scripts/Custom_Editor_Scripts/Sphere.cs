using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float baseSize = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float animation = baseSize + Mathf.Sin(Time.time*8f) * baseSize / 7.0f;
        transform.localScale = Vector3.one * animation;
    }
}
