using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickControl : MonoBehaviour
{
    bool move = false;
    float speed = 5;
    public Vector3 target;    

    void Update()
    {
        if(Input.touchCount > 0 && !move)
        {
            move = true;
            FindObjectOfType<PopsicleMaker>().isStick = true;
        }
        if(move)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
        }
    }
}
