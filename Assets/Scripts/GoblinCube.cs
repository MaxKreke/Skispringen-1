using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCube : MonoBehaviour
{
    public AudioClip life;
    public AudioClip death;

    void Start()
    {
        AudioSource.PlayClipAtPoint(life, transform.position, 1f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destructible")
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(death, transform.position, .5f);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Feuer")
        {
            AudioSource.PlayClipAtPoint(death, transform.position, .5f);
            Destroy(this.gameObject);
        }
    }

}
