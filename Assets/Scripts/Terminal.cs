using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    //Opa = 0
    //Goblin = 1
    //Pissboy = 2
    //Mathemann = 3
    public int activeCharacter = 0;
    public GameObject[] characters;

    void Update()
    {
        GetCharacterSwitch();
    }

    private void GetCharacterSwitch()
    {
        bool next = (Input.GetKeyDown("e") || Input.GetKeyDown("i"));
        bool prev = (Input.GetKeyDown("q") || Input.GetKeyDown("z"));

        if (next) SwitchCharacter(true);
        else if (prev) SwitchCharacter(false);
    }

    public int MaxAvailableCharacter()
    {
        if (GameObject.Find("Mathemann")) return 3;
        if (GameObject.Find("Pissboy")) return 2;
        if (GameObject.Find("Goblin")) return 1;
        return 0;
    }

    private void SwitchCharacter(bool up)
    {
        if (MaxAvailableCharacter() == 0) return;

        characters[activeCharacter].GetComponent<PlayerControls>().Deactivate();
        if (up) activeCharacter++;
        else activeCharacter+=3;
        activeCharacter %= (MaxAvailableCharacter()+1);
        characters[activeCharacter].GetComponent<PlayerControls>().enabled = true;
        characters[activeCharacter].GetComponent<PlayerControls>().Activate();
    }




    // Start is called before the first frame update
    void Start()
    {
        Terminal.ToggleCursor(false);
        Application.targetFrameRate = 120;
        Physics.IgnoreLayerCollision(21,22);
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
