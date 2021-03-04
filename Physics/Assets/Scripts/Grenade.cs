using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    /// <summary>
    /// Explosion particle effect
    /// </summary>
    public GameObject explosionEffect;

    /// <summary>
    /// Players rifle cript
    /// </summary>
    [HideInInspector]
    public Rifle rifleScript;

    /// <summary>
    /// How long to wait before grenade explodes
    /// </summary>
    public float delay = 3f;

    /// <summary>
    /// How much force should be applied to the object that was within range of the grenades explosion
    /// </summary>
    public float explosionForce = 10f;

    /// <summary>
    /// Radius of the grenades explosion
    /// </summary>
    public float radius = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", delay);
    }

    /// <summary>
    /// The grenade is exploding
    /// </summary>
    private void Explode()
    {
        // Get all the colliders that are within range of the grenades explosion
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        // For each collider
        foreach (Collider near in colliders)
        {
            // Get the rigidbody and Ragdoll script
            Rigidbody rig = near.GetComponent<Rigidbody>();
            Ragdoll rag = near.GetComponent<Ragdoll>();

            // If there is a rigidbody, then apply an explosion force
            if (rig != null)
                rig.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);

            // If there is a ragdoll script, then activate the ragdoll and add 1 to the amount of bots killed
            if (rag != null)
            {
                rag.RagdollOn = true;
                rifleScript.botsKilled += 1;
            }
        }

        // Instantiate the explosion particle effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Destroy the grenade
        Destroy(gameObject);
    }
}
