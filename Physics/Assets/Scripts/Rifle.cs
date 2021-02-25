using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public Transform spawnPoint;
    public float distance = 15f;

    public ParticleSystem muzzleFlash;

    public Transform initialPos;
    public Transform aimPosition;

    bool isAiming;

    Camera camera;

    ReloadScript ammoScript;

    // Start is called before the first frame update
    void Start()
    {
        ammoScript = GetComponent<ReloadScript>();
        transform.position = initialPos.position;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !ammoScript.needReload)
            Shoot();

        if (Input.GetButtonDown("Fire2") && !isAiming && !ammoScript.needReload)
            Aim();
        else if (Input.GetButtonDown("Fire2") || ammoScript.needReload)
            UnAim();
    }

    private void Shoot()
    {
        RaycastHit hit;

        ammoScript.currentAmmo--;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Enemy")
            {
                Ragdoll r = hit.collider.gameObject.GetComponentInParent<Ragdoll>();
                if (r != null)
                {
                    r.RagdollOn = true;
                }
            }
        }

        muzzleFlash.Play();
    }

    void Aim()
    {
        transform.position = aimPosition.position;
        isAiming = true;
    }

    void UnAim()
    {
        transform.position = initialPos.position;
        isAiming = false;
    }
}
