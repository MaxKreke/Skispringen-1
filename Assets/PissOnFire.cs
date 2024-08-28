using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissOnFire : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Feuer")Destroy(other);
    }
}
