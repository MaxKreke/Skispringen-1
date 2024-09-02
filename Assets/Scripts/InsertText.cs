using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InsertText : MonoBehaviour
{

    public string[] text;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = text[LevelTracker.level];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
