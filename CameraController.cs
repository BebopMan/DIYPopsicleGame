using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 target1;
    public Vector3 target2;
    [HideInInspector]
    public int directionX;
    public int directionY;
    public int rotationX;
    bool point1 = false;
    bool point2 = false;
    float cameraSpeed = 5;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(point1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1, cameraSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(20, 0, 0), cameraSpeed * Time.deltaTime);
        }
        else if(point2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2, cameraSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), cameraSpeed * Time.deltaTime);
        }
        else if(directionX != 0 || directionY !=0)
        {
            transform.Translate(directionX * Time.deltaTime * cameraSpeed, directionY * Time.deltaTime * cameraSpeed, 0);
        }
        else if(rotationX != 0)
        {
            transform.Rotate(0, rotationX * Time.deltaTime * 15, 0);
        }
    }

    public void Movment(string name)
    {
        if (name == "Up")
        {
            directionY = 1;
        }
        else if (name == "Down")
        {
            directionY = -1;
        }
        else if (name == "Right")
        {
            directionX = 1;
        }
        else if (name == "Left")
        {
            directionX = -1;
        }
        else if (name == "CW")
        {
            rotationX = 1;
        }
        else if (name == "CCW")
        {
            rotationX = -1;
        }
        else if(name == "Stop")
        {
            directionX = 0;
            directionY = 0;
            rotationX = 0;
        }
    }
    public void GoPoint1()
    {
        point1 = true;
    }

    public void GoPoint2()
    {
        point1 = false;
        point2 = true;
    }
}
