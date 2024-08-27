using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public bool havePissBoy;
    public bool haveGoblin;
    public bool haveMatheMann;
    public bool havePissOrb;
    public bool haveGoblinOrb;
    public bool haveMinusOrb;

    //Opa = 0
    //Pissboy = 1
    //Goblin = 2
    //Mathemann = 3
    public int activeCharacter = 0;

    public bool grounded = false;
    public float jumpforce = 10;
    public LayerMask GroundLayers;
    private Rigidbody body;
    private Terminal terminal;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        terminal = GameObject.Find("Terminal").GetComponent<Terminal>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundedCheck();
        JumpAndGravity();
    }

    //Wall Jump enabled
    private void GroundedCheck()
    {
        grounded = Physics.CheckSphere(transform.position + Vector3.down * .1f, .6f, GroundLayers);
    }

    private void JumpAndGravity()
    {
        if (grounded && Input.GetKeyDown("space"))
        {
            body.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }


    public int MaxAvailableCharacter()
    {
        if (haveMatheMann) return 3;
        if (haveGoblin) return 2;
        if (havePissBoy) return 1;
        return 0;
    }

    private void SwitchCharacter(bool up)
    {
        if (up) activeCharacter++;
        else activeCharacter--;
        activeCharacter %= MaxAvailableCharacter();
    }
}
