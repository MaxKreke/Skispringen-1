using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCube : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destructible")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
