using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGernade : MonoBehaviour
{
    /// <summary>
    /// Where should the grenade be thrown from?
    /// </summary>
    public Transform spawnPoint;

    /// <summary>
    /// Grenade prefab
    /// </summary>
    public GameObject grenade;

    /// <summary>
    /// PLayers rifle script
    /// </summary>
    public Rifle rifleScript;

    /// <summary>
    /// Range of the grenade throw
    /// </summary>
    float range = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Launch();
    }

    /// <summary>
    /// Throw a grenade
    /// </summary>
    private void Launch()
    {
        // Instantiate a gernade
        GameObject grenadeInstance = Instantiate(grenade, spawnPoint.position, spawnPoint.rotation);

        // Apply a force to the grenade
        grenadeInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
        grenadeInstance.GetComponent<Grenade>().rifleScript = rifleScript;
    }
}
