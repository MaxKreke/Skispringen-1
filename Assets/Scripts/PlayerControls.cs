using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public bool havePissBoy;
    public bool haveGoblin;
    public bool haveMatheMann;

    //Opa = 0
    //Pissboy = 1
    //Goblin = 2
    //Mathemann = 3
    public int activeCharacter = 0;

    public LayerMask GroundLayers;
    public LayerMask HerzLayer;
    private Rigidbody body;
    public Camera ownCamera;

    public GameObject liebesHerz;

    public bool grounded = false;
    private static float maxSpeed = 15;
    private float jumpforce = 9;
    private float speed = 1;
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
        if (grounded) Move();
        else Move(true);
        ClampSpeed();
        Shoot();
    }

    //Wall Jump disabled
    private void GroundedCheck()
    {
        //Sphere is set so it only checks feet
        grounded = Physics.CheckSphere(transform.position + Vector3.down * .2f, .4f, GroundLayers);
        HerzCheck();
    }

    private void HerzCheck()
    {
        if (Physics.CheckSphere(transform.position + Vector3.down * .2f, .4f, HerzLayer))body.velocity = Vector3.ProjectOnPlane(body.velocity, Vector3.up) + Vector3.up * jumpforce * 1.8f;
    }

    private void JumpAndGravity()
    {
        if (grounded && Input.GetKeyDown("space"))
        {
            body.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    private void Move(bool air = false)
    {
        float horizontalRotation = ownCamera.GetComponent<CameraRotation>().horizontalRotation;
        Vector3 force = Vector3.zero;
        switch (Direction())
        {
            case 0:
                force = Vector3.forward * speed;
                break;
            case 1:
                force = (Vector3.forward + Vector3.right).normalized * speed;
                break;
            case 2:
                force = Vector3.right * speed;
                break;
            case 3:
                force = (Vector3.right + Vector3.back).normalized * speed;
                break;
            case 4:
                force = Vector3.back * speed;
                break;
            case 5:
                force = (Vector3.back + Vector3.left).normalized * speed;
                break;
            case 6:
                force = Vector3.left * speed;
                break;
            case 7:
                force = (Vector3.left + Vector3.forward).normalized * speed;
                break;
            default:
                if (!air) body.velocity /= 1.1f;
                break;
        }
        Vector3 rotatedForce = Quaternion.AngleAxis(horizontalRotation, Vector3.up) * force;
        float horizontalVelocity = new Vector2(body.velocity.x, body.velocity.z).magnitude;
        if (horizontalVelocity < 15) horizontalVelocity *= 4f;
        float currentSpeed = Vector3.ProjectOnPlane(body.velocity, Vector3.up).magnitude;
        float relativeSpeed = Vector3.Dot(rotatedForce, body.velocity);
        if (force != Vector3.zero)
        {
            body.velocity = Vector3.ClampMagnitude(rotatedForce.normalized * (currentSpeed + relativeSpeed) / 2, 150) + body.velocity.y * Vector3.up;
            if (!air) ApplyForce(rotatedForce * 8);
            else ApplyForce(rotatedForce * 2f);
        }
    }

    public void ApplyForce(Vector3 force)
    {
        body.AddForce(force);
    }

    /*  
     *  -1: none
     *  0: forward
     *  1: diagonal
     *  2: right
     *  3: diagonal
     *  4: back
     *  5: diagonal
     *  6: left
     *  7: diagonal
    */
    private int Direction()
    {
        bool forward = (Input.GetKey("w") || Input.GetKey("u") || Input.GetKey("up"));
        bool right = (Input.GetKey("d") || Input.GetKey("k") || Input.GetKey("right"));
        bool back = (Input.GetKey("s") || Input.GetKey("j") || Input.GetKey("down"));
        bool left = (Input.GetKey("a") || Input.GetKey("h") || Input.GetKey("left"));

        if (forward)
        {
            if (right && !left) return 1;
            if (!right && left) return 7;
            if (!back) return 0;
        }
        if (back)
        {
            if (right && !left) return 3;
            if (!right && left) return 5;
            if (!forward) return 4;
        }
        if (right && !left) return 2;
        if (!right && left) return 6;
        return -1;
    }

    private void ClampSpeed()
    {
        Vector3 velocity = body.velocity;
        Vector3 modifiedVelocity = Vector3.ProjectOnPlane(velocity, Vector3.up);
        //Horizontal
        float ratio = modifiedVelocity.magnitude / maxSpeed;
        if (ratio > 1) modifiedVelocity /= ratio;
        modifiedVelocity = new Vector3(modifiedVelocity.x, velocity.y, modifiedVelocity.z);
        //Vertical
        ratio = velocity.y / (maxSpeed * 4f);
        if (ratio > 1) modifiedVelocity.y /= ratio;
        body.velocity = modifiedVelocity;
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

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
            if (activeCharacter == 0 && grounded) SummonLiebesHeart();
    }

    private void SummonLiebesHeart()
    {
        liebesHerz.transform.rotation = Quaternion.identity;
        liebesHerz.transform.position = transform.GetChild(0).GetChild(0).position+ Camera.main.transform.forward*1.5f;
        liebesHerz.GetComponent<Rigidbody>().velocity = Vector3.zero;
        liebesHerz.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward*400);
    }
}
