using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rifle : MonoBehaviour
{
    /// <summary>
    /// Where the raycast is shooting from
    /// </summary>
    public Transform spawnPoint;

    /// <summary>
    /// Distance of the raycast
    /// </summary>
    public float distance = 15f;

    /// <summary>
    /// Muzzle flash particles
    /// </summary>
    public ParticleSystem muzzleFlash;

    /// <summary>
    /// Particles when the raycast hit something
    /// </summary>
    public ParticleSystem impact;

    /// <summary>
    /// Initial position of gun
    /// </summary>
    public Transform initialPos;

    /// <summary>
    /// Aim position of gun
    /// </summary>
    public Transform aimPosition;

    /// <summary>
    /// Text that displays players current objective
    /// </summary>
    public Text objectiveText;

    /// <summary>
    /// How many bots the player has killed
    /// </summary>
    [HideInInspector]
    public float botsKilled;

    /// <summary>
    /// Is the player aiming?
    /// </summary>
    bool isAiming;

    /// <summary>
    /// Main camera
    /// </summary>
    Camera camera;

    /// <summary>
    /// The players reload script
    /// </summary>
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
        // If the player has ammo and has left click, then shoot gun
        if (Input.GetButtonDown("Fire1") && !ammoScript.needReload)
            Shoot();

        // If the player right clicks, is not currently aiming and has ammo
        if (Input.GetButtonDown("Fire2") && !isAiming && !ammoScript.needReload)
            Aim();
        else if (Input.GetButtonDown("Fire2") || ammoScript.needReload || ammoScript.magAnim.GetBool("Reloading"))
            UnAim();

        // If the player has not killed all the bots
        if (botsKilled < 19)
        {
            objectiveText.text = "Kill all the Ragdolls in the fastest time";
        }
        else if (botsKilled == 19)
        {
            objectiveText.text = "Find the exit";
        }
    }

    /// <summary>
    /// Shoot bullet
    /// </summary>
    private void Shoot()
    {
        // What did the raycast hit
        RaycastHit hit;

        // Take one ammo from the current ammo
        ammoScript.currentAmmo--;

        // If the raycast did hit something
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            // Play impact particles
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));

            // If the raycast hit an enemy
            if (hit.transform.tag == "Enemy")
            {
                // Get the objects ragdoll script
                Ragdoll r = hit.collider.gameObject.GetComponentInParent<Ragdoll>();

                // Turn it on
                if (r != null && !r.RagdollOn)
                {
                    r.RagdollOn = true;
                    botsKilled += 1;
                }
            }

            // If the raycast hit the button
            if (hit.transform.tag == "Button")
            {
                // Get the objects button script
                Button b = hit.collider.gameObject.GetComponentInParent<Button>();

                // Activate the platform
                if (b != null)
                {
                    b.Activate();
                }
            }
        }

        // Play the muzzle flash particles
        muzzleFlash.Play();
    }

    /// <summary>
    /// Move the gun to the aiming position
    /// </summary>
    void Aim()
    {
        transform.position = aimPosition.position;
        isAiming = true;
    }

    /// <summary>
    /// Move the gun to the initial position
    /// </summary>
    void UnAim()
    {
        transform.position = initialPos.position;
        isAiming = false;
    }
}
