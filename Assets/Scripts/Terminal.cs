using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Terminal.ToggleCursor(false);
        Application.targetFrameRate = 120;
    }

    public static void ToggleCursor(bool cursor)
    {
        Cursor.visible = cursor;
        if (cursor) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

    }

    //Display Framerate
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), (1.0f / Time.smoothDeltaTime).ToString());
    }

}
