using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Ragdoll r = collision.gameObject.GetComponentInParent<Ragdoll>();
        if (r != null)
        {
            r.RagdollOn = true;
        }
    }
}
