using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public Material[] materials; 
    public void Activate(int number)
    {
        if (number < 0) GetComponent<MeshRenderer>().enabled  = false;
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshRenderer>().material = materials[number];
        }
    }

}
