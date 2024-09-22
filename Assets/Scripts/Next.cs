using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer vp;

    public string[] scenes;
    public UnityEngine.Video.VideoClip[] clips;

    private void Start()
    {
        vp.clip = clips[LevelTracker.level];
        vp.loopPointReached += loadNext;
    }

    void loadNext(UnityEngine.Video.VideoPlayer vp)
    {
        Skip();
    }

    public void Update()
    {
        vp.Play();
        if(Input.GetKey(KeyCode.Semicolon))Skip();
    }

    public void Skip()
    {
        LevelTracker.level++;
        SceneManager.LoadScene(scenes[LevelTracker.level]);
    }
}
