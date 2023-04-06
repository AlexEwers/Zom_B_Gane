using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;


    public Camera fpsCam; 
    public ParticleSystem muzzleflash;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 3f;
    private bool isReloading = false;

    private float nextTimeToFire = 2f;

    private UIManager UIManager;
    private GameObject ReloadingText;

    void Start()
    {
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        ReloadingText = GameObject.FindGameObjectWithTag("RELOADING");

        ReloadingText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            ReloadingText.SetActive(true);
            return;
            
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            shoot();
            
            
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            Debug.Log("Forced Reload");
            ReloadingText.SetActive(true);
        }
    }


    IEnumerator Reload ()
    {
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        UIManager.UpdateAmmo(currentAmmo);
        ReloadingText.SetActive(false);
        
    }



    void shoot()
    {
        muzzleflash.Play();
        RaycastHit hit;

        currentAmmo--;
        UIManager.UpdateAmmo(currentAmmo);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

           

            if (target!= null);
            {
                target.TakeDamage(damage);
            }

        }
    }
}
