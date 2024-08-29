using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignField : MonoBehaviour
{

    public GameObject sign;
    public bool shouldBePlus;

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, .5f);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject == this.gameObject) continue;
            if (hitCollider.gameObject.tag == "Minus" || hitCollider.gameObject.tag == "Plus")
            {
                hitCollider.gameObject.transform.position = transform.position;
                sign = hitCollider.gameObject;
            }
        }
    }

    public bool getSolved()
    {
        if (shouldBePlus) if (getPositive() == 1) return true;
        if (!shouldBePlus) if (getPositive() == 0) return true;
        return false;
    }

    public int getPositive()
    {
        if (!sign) return -1;
        bool positive = sign.GetComponent<Minus>().positive;
        if (positive) return 1;
        return 0;
    }
}
