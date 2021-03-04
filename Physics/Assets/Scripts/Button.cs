using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    /// <summary>
    /// The platforms animator
    /// </summary>
    public Animator platformAnimator;

    /// <summary>
    /// Material to show that the switch has been activated
    /// </summary>
    public Material activateMaterial;

    /// <summary>
    /// Activate the platform
    /// </summary>
    public void Activate()
    {
        // Enable the platforms animator
        platformAnimator.enabled = true;

        // Change the material of the switch to show that is has been activated
        GetComponent<MeshRenderer>().material = activateMaterial;
    }
}
