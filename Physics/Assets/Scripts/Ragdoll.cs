using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    /// <summary>
    /// Ragdolls animator
    /// </summary>
    private Animator animator = null;

    /// <summary>
    /// Ragdolls rigidbodies
    /// </summary>
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    /// <summary>
    /// Turn on ragdoll mode
    /// </summary>
    public bool RagdollOn
    {
        get { return !animator.enabled; }
        set
        {
            animator.enabled = !value;
            foreach (Rigidbody rigidbody in rigidbodies)
            {
                rigidbody.isKinematic = !value;
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RagdollOn)
        {
            CharacterController characterController = GetComponent<CharacterController>();
            characterController.enabled = false;
        }
    }
}
