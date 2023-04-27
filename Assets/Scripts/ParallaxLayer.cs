using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [Tooltip("The ratio that our background moves towards the camera")]
    public float parallaxFactorX = 1;
    public float parallaxFactorY = 1;

    Vector3 cameraStartPosition;
    Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        //the initial position of our layer
        startPosition = transform.position;

        //Camera.main - static refernce to the first camera in our hierachy labeled Main Camera
        cameraStartPosition = Camera.main.transform.position;   
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraDelta = Camera.main.transform.position - cameraStartPosition;

        transform.position = startPosition + new Vector3(cameraDelta.x * parallaxFactorX, 
                                                         cameraDelta.y * parallaxFactorY);
        
    }
}
