using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissOnFire : MonoBehaviour
{
    public AudioClip zisch;

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Feuer")
        {
            AudioSource.PlayClipAtPoint(zisch, other.transform.position, 1);
            Destroy(other);
        }

    }
}
