using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rifle : MonoBehaviour
{
    public Transform spawnPoint;
    public float distance = 15f;

    public ParticleSystem muzzleFlash;
    public ParticleSystem impact;

    public Transform initialPos;
    public Transform aimPosition;

    private float score;
    public Text scoreText;

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
        else if (Input.GetButtonDown("Fire2") || ammoScript.needReload || ammoScript.magAnim.GetBool("Reloading"))
            UnAim();

        scoreText.text = "Score: " + score;
    }

    private void Shoot()
    {
        RaycastHit hit;

        ammoScript.currentAmmo--;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            if (hit.transform.tag == "Enemy")
            {
                Ragdoll r = hit.collider.gameObject.GetComponentInParent<Ragdoll>();
                if (r != null && !r.RagdollOn)
                {
                    r.RagdollOn = true;
                    score += 100;
                }
            }

            if (hit.transform.tag == "Button")
            {
                Button b = hit.collider.gameObject.GetComponentInParent<Button>();
                if (b != null)
                {
                    b.Activate();
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
