using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysObject : MonoBehaviour
{
    public Material awakeMat = null;
    public Material sleepingMat = null;

    private Rigidbody _rigidbody = null;

    private bool wasAsleep = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rigidbody.IsSleeping() && !wasAsleep && sleepingMat != null)
        {
            wasAsleep = true;
            GetComponent<MeshRenderer>().material = sleepingMat;
        }
        if (!_rigidbody.IsSleeping() && wasAsleep && awakeMat != null)
        {
            wasAsleep = false;
            GetComponent<MeshRenderer>().material = awakeMat;
        }

        if (Input.GetKey(KeyCode.Space) && name == "Sphere")
        {
            _rigidbody.AddForce(new Vector3(0, 0, 1) * 1000);
        }
    }
}
