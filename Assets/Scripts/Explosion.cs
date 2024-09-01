using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private int age;
    // Start is called before the first frame update
    void Start()
    {
        age = 12;
    }

    // Update is called once per frame
    void Update()
    {
        age--;
        if (age < 0) Destroy(this.gameObject);
    }
}
