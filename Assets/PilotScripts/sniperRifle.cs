using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sniperRifle : MonoBehaviour
{
    public int damage = 85;
    public string firingMode = "single shot";
    public int fireRate = 1;
    public int ammoCount = 6;
    public int range = 100;

    public float nextTimeToFire = 0f;
    private int count;

    private PilotHealth ph;
    // --------------------------------------

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    void Start()
    {
        ph = FindObjectOfType<PilotHealth>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ammoCount = 6;
            ph.setAmmo(6, ammoCount);
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire && firingMode == "single shot")
        {
            if (ammoCount > 0)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                shoot();
                Debug.Log("Ammo count is" + ammoCount);
            }
        }
    }
    void shoot()
    {
        muzzleFlash.Play();
        ammoCount -= 1;
        ph.setAmmo(6, ammoCount);
        RaycastHit hit;
        Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range);
        // Debug.Log(hit.transform.name);
        // Target target = hit.transform.GetComponent<Target>();
        // if(target!=null){
        //     target.TakeDamage(damage);
        // }
    }
}
