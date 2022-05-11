using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;

    Vector3 oldPos;

    void Update()
    {
        if(Physics.Linecast(oldPos, transform.position, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<OrcAi>(out OrcAi orc)) orc.healthSystem.Damage(50f);
        }


        oldPos = transform.position;
    }

    public void TakeDir(Vector3 Dir)
    {
        if(rb == null)
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        rb.velocity = Dir;
        oldPos = transform.position;
    }

}
