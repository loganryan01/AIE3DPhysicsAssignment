using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosionEffect;
    public float delay = 3f;

    public float explosionForce = 10f;
    public float radius = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", delay);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();
            Ragdoll rag = near.GetComponent<Ragdoll>();

            if (rig != null)
                rig.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);

            if (rag != null)
                rag.RagdollOn = true;
        }

        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
