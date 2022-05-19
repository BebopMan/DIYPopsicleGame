using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableColider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject, 3);
    }
}
