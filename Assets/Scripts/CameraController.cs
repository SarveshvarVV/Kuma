using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform target;

    [Space(20)]
    //the minimum value in the x and y directions
    public Vector2 MinXY;
    //the maximum values in the x and y directions
    public Vector2 MaxXY;
    // Start is called before the first frame update

    [Space(20)]

    public Vector2 EasingFactor;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tempX= target.position.x;
        float tempY= target.position.y;
        
        //if (tempX > MaxXY.x)
        //{
        //    tempX= MaxXY.x;
        //}
        //else if (tempX < MinXY.x)
        //{
        //    tempX=-MinXY.x;
        //}

        tempX = Mathf.Clamp(tempX, MinXY.x, MaxXY.x);
        tempY = Mathf.Clamp(tempY, MinXY.y, MaxXY.y); 
        
        //lerp (linear Interpolation)
        //(B-A)*t +A
        //Mathf.Lerp(A,B,t)

        tempX = Mathf.Lerp(transform.position.x, tempX, EasingFactor.x);
        tempY = Mathf.Lerp(transform.position.y, tempY, EasingFactor.y);   


        transform.position = new Vector3(tempX, tempY, transform.position.z);
        
    }
}
