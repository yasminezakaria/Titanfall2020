using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    public int damage = 70;
    public string firingMode = "single shot";
    public int fireRate = 3;
    public int ammoCount = 12;
    public int range = 4;
    public float nextTimeToFire = 0f;

    public int count;

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammoCount = 6;
            ph.setAmmo(6, ammoCount);
        }
        if (Input.GetMouseButtonDown(0) && firingMode == "single shot")
        {
            if (ammoCount > 0)
            {
                count = fireRate;
                while (count > 0)
                {
                    shoot();
                    count--;
                }
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
