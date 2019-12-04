using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assaultRifle : MonoBehaviour
{
    public int damage = 10;
    public string firingMode = "automatic";
    public int fireRate = 10;
    public int ammoCount = 35;
    public int range = 65;

    private float nextTimeToFire = 0f;


    // --------------------------------------

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private PilotHealth ph;

    void Start()
    {
        ph = FindObjectOfType<PilotHealth>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ammoCount = 35;
            ph.setAmmo(35, ammoCount);
        }
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && firingMode == "automatic")
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
        ph.setAmmo(35, ammoCount);
        RaycastHit hit;
        Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range);

        // Debug.Log(hit.transform.name);
        // Target target = hit.transform.GetComponent<Target>();
        // if(target!=null){
        //     target.TakeDamage(damage);
        // }
    }

}


    
