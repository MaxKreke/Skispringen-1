using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinCube : MonoBehaviour
{
    public AudioClip life;
    public AudioClip death;
    public AudioClip kaboom;
    public GameObject explosion;

    void Start()
    {
        AudioSource.PlayClipAtPoint(life, transform.position, 1f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destructible")
        {
            Destroy(collision.gameObject);
            explode();
        }
        if (collision.gameObject.tag == "Feuer")
        {
            explode();
        }
    }

    private void explode()
    {
        AudioSource.PlayClipAtPoint(death, transform.position, .5f);
        AudioSource.PlayClipAtPoint(kaboom, transform.position, .5f);
        Vector3 other = Camera.main.transform.position;
        Vector3 direction = (other - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(-direction);
        GameObject splosion = Instantiate(explosion, transform.position, rotation);
        Destroy(this.gameObject);
    }

}
