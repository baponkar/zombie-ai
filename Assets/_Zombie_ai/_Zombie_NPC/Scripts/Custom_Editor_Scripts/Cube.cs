using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
This script will generate random colors for the cubes.
*/

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GenerateColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateColor()
    {
        //Generate random color
        // int r = (int) Random.Range(0 , 255);
        // int g = (int) Random.Range(0, 255);
        // int b = (int) Random.Range(0, 255);
        // float a = Random.Range(0.0f, 1.0f);
        

        //Color color = new Color(r, g, b, a);

        //Set color
        //GetComponent<Renderer>().material.color = color;

        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public void ResetColor()
    {
        //Reset color
        GetComponent<Renderer>().sharedMaterial.color = Color.white;
    }

}
