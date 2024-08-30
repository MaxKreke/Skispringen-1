using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tafel : MonoBehaviour
{

    public Material tafelSolved;
    public GameObject barricade;
    public GameObject[] fields;
    public AudioClip matheMann;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject field in fields)
        {
            if(!field.GetComponent<SignField>().getSolved())return;
        }
        SolveTafel();
    }

    private void SolveTafel()
    {
        if (barricade)
        {
            Destroy(barricade);
            AudioSource.PlayClipAtPoint(matheMann, transform.position);
        }
        GetComponent<MeshRenderer>().material = tafelSolved;
    }

}
