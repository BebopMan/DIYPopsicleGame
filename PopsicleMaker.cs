using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopsicleMaker : MonoBehaviour
{
    [HideInInspector]
    public bool isStick = false;
    float speed = 5;
    public Vector3 target1;
    public Vector3 target2;
    bool point1 = false;
    bool point2 = false;
    bool freez = false;
    bool done = false;

    private void Update()
    {
        if(isStick && Input.touchCount > 0 && !point1)
        {
            point1 = true;
        }
        else if(point1 && !point2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1, speed * Time.deltaTime);
        }
        else if(point2 && !point1 && !freez)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2, speed * Time.deltaTime);
        }
        if(transform.position == target1 && Input.touchCount > 0 && !freez)
        {
            point1 = false;
            point2 = true; 
        }
        else if(transform.position == target2 && Input.touchCount > 0)
        {            
            point1 = true;
            point2 = false;
            freez = true;
        }
        else if (transform.position == target1 && Input.touchCount > 0 && freez && !done)
        {
            transform.Rotate(180, 0, 0);
            done = true;
            FindObjectOfType<CameraController>().GoPoint2();
            
        }
        else if(done && Input.touchCount > 0)
        {
            if(transform.Find("Mold") != null)
            {
                Debug.Log("yup");
                Destroy(transform.Find("Mold").gameObject);
            }
        }
    }

    public void Melt()
    {
        foreach(Transform child in transform)
        {
            if(child.GetComponent<Rigidbody>() != null)
            {
                child.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }


}
