using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator platformAnimator;

    public Material activateMaterial;

    public void Activate()
    {
        platformAnimator.enabled = true;
        GetComponent<MeshRenderer>().material = activateMaterial;
    }
}
