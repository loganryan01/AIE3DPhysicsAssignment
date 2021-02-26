using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadScript : MonoBehaviour
{
    public int maxAmmo = 50;
    public int defaultAmmo = 10;
    [HideInInspector]
    public int currentAmmo;

    public float reloadSpeed = 2f;

    public Text ammoText;

    [HideInInspector]
    public bool needReload;

    public Animator magAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = defaultAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo <= 0)
            needReload = true;

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());

        ammoText.text = "Ammo: " + currentAmmo + "/" + maxAmmo;
    }

    private IEnumerator Reload()
    {
        magAnim.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadSpeed);
        currentAmmo = defaultAmmo;
        needReload = false;
        magAnim.SetBool("Reloading", false);
    }
}
