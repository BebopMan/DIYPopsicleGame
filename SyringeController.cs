using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeController : MonoBehaviour
{            
    public Transform nozzle;
    public GameObject liquid;
    public GameObject popsicle;
    Color color;
    float touchTime = 0;
    bool liquidDelay = false;
    float x; // check
    float y; // check       

    // Start is called before the first frame update
    void Start()
    {
        ChangeColor("#B70096");        
        //screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z));                
    }

    // Update is called once per frame
    void Update()
    {
        /*x = Input.GetAxis("Horizontal") * Time.deltaTime; // check
        y = Input.GetAxis("Vertical") * Time.deltaTime; // check
        transform.Translate(x, y, 0); // check        
        Vector3 pos = transform.position; // check
        pos.x = Mathf.Clamp(transform.position.x, -1.5f, 1.5f); // check
        transform.position = pos; // check
        if(Input.GetKeyDown(KeyCode.Space)) // check
        {
            StartCoroutine(PourLiquid());
        }*/

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);            
            if(touchTime == 0)
            {
                touchTime = Time.time;                
            }
            else if (Time.time - touchTime > 1 && !liquidDelay)
            {
                liquidDelay = true;
                StartCoroutine(PourLiquid());
            }
            if (touch.phase == TouchPhase.Moved)
            {
                float posx = touch.deltaPosition.x * Time.deltaTime;                
                transform.Translate(posx,0,0);
                Vector3 pos = transform.position;
                pos.x = Mathf.Clamp(transform.position.x, -1.1f, 1.1f);                
                transform.position = pos;
            }            
        }
        else
        {
            touchTime = 0;
        }
    }   

    IEnumerator PourLiquid()
    {
        GameObject temp = Instantiate(liquid, nozzle.position, transform.rotation);
        temp.GetComponent<Renderer>().material.color = color;
        temp.transform.parent = popsicle.transform;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ChangeLiquid(temp.GetComponent<Rigidbody>()));        
        liquidDelay = false;
    }

    public void ChangeColor(string hexColor)
    {                
        if(ColorUtility.TryParseHtmlString(hexColor, out color))
        {   
            transform.Find("Liquid").GetComponent<Renderer>().material.color =color;
        }
    }

    IEnumerator ChangeLiquid(Rigidbody liquidRB)
    {
        yield return new WaitForSeconds(2);
        liquidRB.isKinematic = true;
    }
}
