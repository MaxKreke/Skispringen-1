using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    public bool isFinish = false;

    void OnCollisionEnter(Collision collision)
    {
        if (isFinish)
        {
            if (collision.gameObject.tag == "Player") FinishScene();
        }
        else if (collision.gameObject.tag == "Herz") FinishScene();

    }

    void FinishScene()
    {
        LevelTracker.level++;
        SceneManager.LoadScene("CutsceneScene");
    }

}
