using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = transform.GetChild(0).position;
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}
