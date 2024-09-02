using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public string[] scenes;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Skip()
    {
        LevelTracker.level++;
        SceneManager.LoadScene(scenes[LevelTracker.level]);
    }

}
