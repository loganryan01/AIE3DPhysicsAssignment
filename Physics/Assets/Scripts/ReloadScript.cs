using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScript : MonoBehaviour
{
    /// <summary>
    /// Players max ammo
    /// </summary>
    public int maxAmmo = 50;

    /// <summary>
    /// Players default ammo
    /// </summary>
    public int defaultAmmo = 10;

    /// <summary>
    /// Players current ammo
    /// </summary>
    [HideInInspector]
    public int currentAmmo;

    /// <summary>
    /// Players reload speed
    /// </summary>
    public float reloadSpeed = 2f;

    /// <summary>
    /// Text that displays players ammo
    /// </summary>
    public Text ammoText;

    /// <summary>
    /// The players need reload
    /// </summary>
    [HideInInspector]
    public bool needReload;

    /// <summary>
    /// Magazine animator
    /// </summary>
    public Animator magAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = defaultAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has run out of ammo, they need to reload
        if (currentAmmo <= 0)
            needReload = true;

        // Reload the gun if the player presses 'R'
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());

        ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }

    /// <summary>
    /// Reload the gun
    /// </summary>
    /// <returns></returns>
    private IEnumerator Reload()
    {
        magAnim.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadSpeed);
        currentAmmo = defaultAmmo;
        needReload = false;
        magAnim.SetBool("Reloading", false);
    }
}
