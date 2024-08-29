using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minus : MonoBehaviour
{
    public Vector3 direction;
    public LayerMask collisionLayers;

    public GameObject minus;
    public GameObject plus;
    public bool positive = false;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += direction;
        if (Physics.CheckSphere(transform.position, .05f, collisionLayers)) direction = Vector3.zero;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, .15f);
        foreach(Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject == this.gameObject) continue;
            if(hitCollider.gameObject.tag == "Minus")
            {
                bool result = ComputeResult(false);
                SpawnReplace(result, hitCollider.gameObject);
                break;
            } else if (hitCollider.gameObject.tag == "Plus")
            {
                bool result = ComputeResult(true);
                SpawnReplace(result, hitCollider.gameObject);
                break;
            }
        }
    }

    private bool ComputeResult(bool positiveOther)
    {
        if (positiveOther && positive) return true;
        if(positiveOther || positive) return false;
        return true;
    }

    private void SpawnReplace(bool positive, GameObject other)
    {
        Vector3 otherPos = other.transform.position;
        Destroy(other);

        Transform container = GameObject.Find("MinusContainer").transform;
        GameObject minusProjectile;
        if(positive) minusProjectile = Instantiate(plus, otherPos, transform.rotation);
        else minusProjectile = Instantiate(minus, otherPos, transform.rotation);
        minusProjectile.name = "Zeichen";
        minusProjectile.transform.SetParent(container);
        minusProjectile.GetComponent<Minus>().direction = Vector3.zero;

        Destroy(this.gameObject);
    }


}
