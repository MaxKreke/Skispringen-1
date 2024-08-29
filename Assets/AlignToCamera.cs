using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToCamera : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Vector3 other = Camera.main.transform.position;
        Vector3 direction = (other - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.Rotate(90 * Vector3.right);
        transform.position = transform.parent.position;
    }
}
